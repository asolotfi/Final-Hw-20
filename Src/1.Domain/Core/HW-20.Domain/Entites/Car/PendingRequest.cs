namespace HW_20.Domain.Entites.Car
{
    public class PendingRequest
    {
        #region Properties
        //درخواست‌های معلق
        public int Id { get; set; }
        public int InspectionRequestId { get; set; }
        public InspectionRequest InspectionRequest { get; set; }
        public DateTime CreatedAt { get; set; }
        #endregion
    }
}
