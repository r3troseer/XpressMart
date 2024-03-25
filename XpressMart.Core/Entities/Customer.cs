namespace XpressMart.Core.Entities
{
    public class Customer:BaseEntity<string>
    {
        public Customer()
        {
            Id = Guid.NewGuid().ToString();   
        }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
