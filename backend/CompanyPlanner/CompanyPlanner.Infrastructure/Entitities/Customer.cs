namespace CompanyPlanner.Infrastructure.Entitities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<CustomerImage> Images { get; set; } = [];
    }
}
