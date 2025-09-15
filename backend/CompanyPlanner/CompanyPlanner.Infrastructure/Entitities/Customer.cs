using CompanyPlanner.Infrastructure.Entitities.Interfaces;

namespace CompanyPlanner.Infrastructure.Entitities
{
    public class Customer : IProfile<CustomerImage>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CustomerImage> Images { get; set; } = new List<CustomerImage>();
    }
}
