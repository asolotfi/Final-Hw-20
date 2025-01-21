using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;
using HW_20.Infrastructure.DB;

namespace HW_20.Infrastructure.Repositoris
{
    public class InspectionRequestRepository : IInspectionRequestRepository
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();
        public bool AddInspectionRequest(string PhoneNumber, string codeMeli, int Number2, StringNumberEnum StringNumber, int Number3, Car Car, CarModel CarModel)
        {
            try
            {
                if (PhoneNumber == null || codeMeli.Length != 10 || Number2 == null || StringNumber == null || Number3 == null || Car == null || CarModel == null)
                {
                    return false;
                }
                var InspectionRequest = new InspectionRequest
                {
                    PhoneNumber = PhoneNumber,
                    codeMeli = codeMeli,
                    Number2 = Number2,
                    StringNumber = StringNumber,
                    Number3 = Number3,
                    Car = Car,
                    CarModel = CarModel,
                    RequestDate = DateTime.Now,
                                    };
                _appDbContext.Add(InspectionRequest);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException("خطا در زمان ثبت درخواست", ex);
            }
        }
    }
}




