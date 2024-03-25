using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressMart.Core.Entities
{
    public class OrderItem : BaseEntity<string>
    {
        public OrderItem()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
