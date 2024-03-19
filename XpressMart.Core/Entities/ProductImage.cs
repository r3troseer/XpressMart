using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressMart.Core.Entities
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string ImageUrl { get; set; }
        public long FileSize { get; set; }
    }
}
