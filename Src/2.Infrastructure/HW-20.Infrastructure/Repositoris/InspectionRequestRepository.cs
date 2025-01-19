using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Enum;
using HW_20.Infrastructure.DB;
using System.Diagnostics;

namespace HW_20.Infrastructure.Repositoris
{
    public class InspectionRequestRepository : IInspectionRequestRepository
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();
        public bool AddInspectionRequest(string PhoneNumber, string codeMeli, int Number2, StringNumberEnum StringNumber, int Number3, Car Car, CarModel CarModel)
        {
            //try
            //{
            //    if (PhoneNumber == null || price <= 0 || categoryId == null)
            //    {
            //        return false;
            //    }
            //    var productNew = new Product
            //    {
            //        Name = name,
            //        Price = price,
            //        CategoryId = categoryId,
            //    };
            //    _appDbContext.Products.Add(productNew);
            //    _appDbContext.SaveChanges();
                return true;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw new ApplicationException("خطا در زمان ثبت کالا", ex);
            //}
        }
    }
}




