using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Sevice;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;

namespace HW_18.Infrastructure.Service
{
    public class InspectionRequestService : IInspectionRequestService
    {
        private readonly IInspectionRequestRepository _InspectionRequestRepository;

        public InspectionRequestService(IInspectionRequestRepository InspectionRequestRepository)
        {
            _InspectionRequestRepository = InspectionRequestRepository;
        }

        public bool AddInspectionRequest(string PhoneNumber, string codeMeli, int Number2, StringNumberEnum StringNumber, int Number3, Car Car, CarModel CarModel)
        {
            var result = _InspectionRequestRepository.AddInspectionRequest(PhoneNumber, codeMeli, Number2, StringNumber, Number3, Car, CarModel);
            return result;
        }
    }
}