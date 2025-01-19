using HW_20.Domain.Enum;

namespace HW_20.Domain.Entites.Car
{
    public class Car
    {
        #region Properties
        public int Id { get; set; }
        //شماره پلاک خودرو 
        public int Number2 { get; set; }
        public StringNumberEnum StringNumber { get; set; }
        public int Number3 { get; set; }
        // مدل خودرو
        public int ModelId { get; set; }
        public CarModel Model { get; set; }
        // تولیدکننده خودرو
        public int ManufacturerId { get; set; }
        public CarManufacturer Manufacturer { get; set; }
        //سال تولید خودرو.
        public int ProductionYear { get; set; }
        #endregion
        #region NavigationProperties
        public ICollection<InspectionRequest> InspectionRequests { get; set; }
        #endregion
    }
}
