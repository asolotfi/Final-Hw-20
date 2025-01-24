using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Sevice;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;
using HW_20.Infrastructure.DB;
using Microsoft.AspNetCore.Mvc;

namespace Find_HW_20.Controllers
{
    public class CarModelController : Controller
    {

        private readonly ICarModelSevice _CarModelSevice;
        private readonly AppDbContext _appDbContext;

        public CarModelController(ICarModelSevice CarModelSevice, AppDbContext appDbContext)
        {
            _CarModelSevice = CarModelSevice;
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult CarModel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCarModel()
        {
            return View();
        }
        public IActionResult EditCarModel()
        {
            return View();
        }
        public IActionResult DeleteCarModel()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddCarModel(string name)
        {
            var cardModel = new CarModel
            {
              Name = name,
            };
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "لطفاً داده‌ها را به صورت صحیح وارد کنید.";
                return View("Index", cardModel);
            }

            TempData["SuccessMessage"] = "درخواست معاینه فنی ثبت شد.";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteCarModel(int id)
        {
            try
            {
                var request = _appDbContext.InspectionRequests.Find(id);
                if (request == null)
                {
                    TempData["ErrorMessage"] = "درخواست معاینه پیدا نشد.";
                    return RedirectToAction("Index");
                }

                request.Status = RequestStatusEnum.Approved;
                _appDbContext.SaveChanges();
                TempData["SuccessMessage"] = "درخواست معاینه تأیید شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطایی در تأیید درخواست رخ داد.";
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            try
            {
                var request = _appDbContext.InspectionRequests.Find(id);
                if (request != null)
                {
                    request.Status = RequestStatusEnum.Rejected;
                    _appDbContext.SaveChanges();
                    TempData["SuccessMessage"] = "درخواست معاینه رد شد.";
                }
                else
                {
                    TempData["ErrorMessage"] = "درخواست معاینه پیدا نشد.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطایی در رد درخواست رخ داد.";
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Get(RequestStatusEnum status)
        {
            var result = _InspectionRequestService.Get(status);
            if (result == null)
            {
                TempData["ErrorMessage"] = "درخواستی وجود ندارد.";
                return RedirectToAction("Show");
            }
            else
                return View(result);
        }


        public IActionResult Success()
        {
            return View();
        }

    }
}
