﻿namespace HW_20.Domain.Entites.Car
{
    public class InspectionRequest
    {
        #region Properties
        //درخواست معاینه فنی شامل اطلاعات درخواست معاینه فنی است، از جمله تاریخ درخواست، خودرو و اطلاعات مالک.
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        #endregion
    }
}
