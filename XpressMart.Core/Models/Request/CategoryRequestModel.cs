namespace XpressMart.Core.Models.Request
{
    public class CategoryRequestModel : BaseRequest<int?>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
