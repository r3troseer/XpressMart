using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressMart.Core.Entities
{
    public class Delivery : BaseEntity
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public string DeliveryStatus { get; set; }
    }
}
