using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressMart.Core.Entities
{
    public class ProductImage : BaseEntity<string>
    {
        public ProductImage() 
        {
            Id = Guid.NewGuid().ToString();
        }
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public string ImageUrl { get; set; }
        public long FileSize { get; set; }
    }
}
