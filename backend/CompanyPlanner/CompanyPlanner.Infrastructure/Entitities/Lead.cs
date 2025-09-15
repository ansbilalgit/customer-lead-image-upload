namespace CompanyPlanner.Infrastructure.Entitities
{
    public class Lead
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        public ICollection<LeadImage> Images { get; set; } = [];
    }
}
