using HW_20.Domain.Contract.AppService;
using HW_20.Domain.Contract.Sevice;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;

namespace HW_20.Service.AppService
{
    public class InspectionRequestAppService : IInspectionRequestAppService
    {
        private readonly IInspectionRequestService _InspectionRequestService;

        public InspectionRequestAppService(IInspectionRequestService InspectionRequestService)
        {
            _InspectionRequestService = InspectionRequestService;
        }

        public bool AddInspectionRequest(string PhoneNumber, string codeMeli, int Number2, StringNumberEnum StringNumber, int Number3, Car Car, CarModel CarModel)
        {
            var result = _InspectionRequestService.AddInspectionRequest(PhoneNumber, codeMeli, Number2, StringNumber, Number3, Car, CarModel);
            return result;
        }
    }
}
