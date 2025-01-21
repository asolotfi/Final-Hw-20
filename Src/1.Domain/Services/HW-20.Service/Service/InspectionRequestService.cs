using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Sevice;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;
using HW_20.Domain.Models;

namespace HW_18.Infrastructure.Service
{
    public class InspectionRequestService : IInspectionRequestService
    {
        private readonly IInspectionRequestRepository _InspectionRequestRepository;
        private readonly AppSettings _appSettings;

        public InspectionRequestService(IInspectionRequestRepository InspectionRequestRepository , AppSettings appSettings)
        {
            _InspectionRequestRepository = InspectionRequestRepository;
            _appSettings = appSettings;
        }

        public bool AddInspectionRequest(string PhoneNumber, string codeMeli, int Number2, StringNumberEnum StringNumber, int Number3, Car Car, CarModel CarModel)
        {
            int result = GetCapacityForDay(DateTime.Now);
            if (result != 0)
            {
                var resultF = _InspectionRequestRepository.AddInspectionRequest(PhoneNumber, codeMeli, Number2, StringNumber, Number3, Car, CarModel);
                return resultF;
            }
            return false;
        }
        public int GetCapacityForDay(DateTime requestDate)
        {
            if (requestDate.Day % 2 == 0)
            {
                return _appSettings.EvenDayCapacity; // ظرفیت روزهای زوج
            }
            else
            {
                return _appSettings.OddDayCapacity;  // ظرفیت روزهای فرد
            }
        }
    }
}