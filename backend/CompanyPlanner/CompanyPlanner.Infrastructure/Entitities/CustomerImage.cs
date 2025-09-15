using CompanyPlanner.Infrastructure.Entitities.Interfaces;

namespace CompanyPlanner.Infrastructure.Entitities
{
    public class CustomerImage : IProfileImage
    {
        public int Id { get; set; }
        public string Base64Data { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
