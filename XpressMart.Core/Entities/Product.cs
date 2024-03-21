using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressMart.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name {  get; set; }
        public string Description {  get; set; }
        public decimal Price { get; set; }
        public int quantity { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
    }
}
