namespace HW_20.Domain.Entites.Car
{
    public class CarModel
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region NavigationProperties
        public List<Car> Cars { get; set; }
        #endregion
    }
}
