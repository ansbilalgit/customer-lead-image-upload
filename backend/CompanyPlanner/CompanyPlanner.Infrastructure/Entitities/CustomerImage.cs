namespace CompanyPlanner.Infrastructure.Entitities
{
    public class CustomerImage
    {
        public int Id { get; set; }
        public string Base64Data { get; set; } = string.Empty;

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
