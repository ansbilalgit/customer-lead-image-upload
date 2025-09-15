using CompanyPlanner.Infrastructure.Entitities.Interfaces;

namespace CompanyPlanner.Infrastructure.Entitities
{
    public class Lead : IProfile<LeadImage>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // May have some other properties specific to Lead
        public ICollection<LeadImage> Images { get; set; } = new List<LeadImage>();
    }
}
