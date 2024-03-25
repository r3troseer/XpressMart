using System.ComponentModel.DataAnnotations.Schema;

namespace XpressMart.Core.Entities
{
    public class Order : BaseEntity<string>
    {
        public Order()
        {
            Id = Ulid.NewUlid().ToString();
        }
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
