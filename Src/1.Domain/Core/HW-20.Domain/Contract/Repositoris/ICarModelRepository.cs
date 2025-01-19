

using HW_20.Domain.Entites.Car;

namespace HW_20.Domain.Contract.Repositoris
{
    public interface ICarModelRepository
    {
        List<CarModel> GetCarModels();
    }
}
