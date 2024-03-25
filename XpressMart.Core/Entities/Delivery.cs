namespace XpressMart.Core.Entities
{
    public class Delivery : BaseEntity<string>
    {
        public Delivery()
        {
            Id = Ulid.NewUlid().ToString();
        }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public string DeliveryStatus { get; set; }
    }
}
