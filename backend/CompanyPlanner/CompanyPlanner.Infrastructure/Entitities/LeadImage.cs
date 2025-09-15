using CompanyPlanner.Infrastructure.Entitities.Interfaces;

namespace CompanyPlanner.Infrastructure.Entitities
{
    public class LeadImage : IProfileImage
    {
        public int Id { get; set; }
        public string Base64Data { get; set; }

        public int LeadId { get; set; }
        public Lead Lead { get; set; }
    }
}
