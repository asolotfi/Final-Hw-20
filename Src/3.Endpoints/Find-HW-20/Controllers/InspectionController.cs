using HW_18.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Find_HW_20.Controllers
{
    public class InspectionController : Controller
    {
        private readonly InspectionRequestService _inspectionService;

        public InspectionController(InspectionRequestService inspectionService)
        {
            _inspectionService = inspectionService;
        }

        public IActionResult RequestForm(DateTime requestDate)
        {
            int capacity = _inspectionService.GetCapacityForDay(requestDate);

            // استفاده از ظرفیت برای محدود کردن تعداد درخواست‌ها
            ViewData["Capacity"] = capacity;
            return View();
        }
    }
}
