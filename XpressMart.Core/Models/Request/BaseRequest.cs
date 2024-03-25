using System.ComponentModel.DataAnnotations;

namespace XpressMart.Core.Models.Request
{
    public abstract class BaseRequest<TKey>
    {
        public TKey Id { get; set; }
    }
}
