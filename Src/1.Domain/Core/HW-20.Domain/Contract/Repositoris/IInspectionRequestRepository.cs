using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;

namespace HW_20.Domain.Contract.Repositoris
{
    public interface IInspectionRequestRepository
    {
        //DateTime RequestDate, string PhoneNumber , string codeMeli, int Number2,StringNumberEnum StringNumber, int Number3, bool IsApproved, bool IsRejected, int UserId, int CarId, Car Car, int CarModelId, CarModel CarModel
        bool AddInspectionRequest(string PhoneNumber , string codeMeli, int Number2,StringNumberEnum StringNumber, int Number3,Car Car,CarModel CarModel);
    }
}
