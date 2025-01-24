using Azure.Core;
using Find_HW_20.Models;
using HW_20.Domain.Contract.Service;
using HW_20.Domain.Contract.Sevice;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;
using HW_20.Infrastructure.DB;
using HW_20.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace Find_HW_20.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInspectionRequestService _InspectionRequestService;
        private readonly AppDbContext _appDbContext;
        private readonly IAuthenticationAppService _AuthenticationAppService;

        public HomeController(ILogger<HomeController> logger, IInspectionRequestService InspectionRequestService, AppDbContext appDbContext, IAuthenticationAppService AuthenticationAppService)
        {
            _logger = logger;
            _InspectionRequestService = InspectionRequestService;
            _appDbContext = appDbContext;
            _AuthenticationAppService = AuthenticationAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult signin()
        {
            return View();
        }
             public IActionResult Show()
        {
            var requests = _appDbContext.InspectionRequests.ToList();
            return View(requests);
        }
        public IActionResult Get()
        {
            // دریافت درخواست‌ها و برگرداندن به ویو
            var inspectionRequests = _appDbContext.InspectionRequests.ToList();
            return View(inspectionRequests);
        }
        public IActionResult Approve()
        {
            return View();
        }
        public IActionResult Reject()
        {
            return View();
        }
        public IActionResult CreateOldInspectionRequest()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
  
        [HttpGet]
        public IActionResult createInspection(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string companyt)
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateInspectionRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate)
        {
            var InspectionRequestq = new InspectionRequest
            {
                PhoneNumber = PhoneNumber,
                CodeMeli = codeMeli,
                PlateNumber = PlateNumber,
                Car = Car,
                Company = company,
                ProductionDate = ProductionDate,

            };
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "لطفاً داده‌ها را به صورت صحیح وارد کنید.";
                return View(InspectionRequestq);
            }

            else if (!_InspectionRequestService.AddInspectionRequest(PhoneNumber, codeMeli, PlateNumber, Car, company, ProductionDate))
            {
                TempData["ErrorMessage"] = "درخواست معاینه ثبت نشد.";
                return RedirectToAction("Index");
            }

            TempData["SuccessMessage"] = "درخواست معاینه فنی ثبت شد.";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult CreateOldInspectionRequest(string PhoneNumber, string codeMeli, string PlateNumber, string Car, string company, DateTime ProductionDate)
        {
            var InspectionRequestq = new InspectionRequest
            {
                PhoneNumber = PhoneNumber,
                CodeMeli = codeMeli,
                PlateNumber = PlateNumber,
                Car = Car,
                Company = company,
                ProductionDate = ProductionDate,
            };
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "لطفاً داده‌ها را به صورت صحیح وارد کنید.";
                return View(InspectionRequestq);
            }

            else if (!_InspectionRequestService.AddInspectionRequest(PhoneNumber, codeMeli, PlateNumber, Car, company, ProductionDate))
            {
                TempData["ErrorMessage"] = "درخواست معاینه فنی در قسمت قدیمی ثبت نشد.";
                return RedirectToAction("Index");
            }

            TempData["SuccessMessage"] = "درخواست معاینه فنی ثبت شد.";
            return RedirectToAction("Index");
        }
        // متد تأیید درخواست
        [HttpPost]
        public IActionResult Approve(int id)
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
            // بازگشت به صفحه‌ی اصلی لیست
            return RedirectToAction("Show");
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
            return RedirectToAction("Show");
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
                return View("Show",result);
        }
        public IActionResult Success()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string userName, string password)
        {
            if (_AuthenticationAppService.Login(userName, password))
            {
                return RedirectToAction("Show", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "ورود به سیستم ناموفق بود";
                return View("Show");
            }
        }

    }
}
