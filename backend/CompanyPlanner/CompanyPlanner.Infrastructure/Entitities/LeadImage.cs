namespace CompanyPlanner.Infrastructure.Entitities
{
    public class LeadImage
    {
        public int Id { get; set; }
        public string Base64Data { get; set; } = string.Empty;
        public int LeadId { get; set; }
        public Lead? Lead { get; set; }
    }
}
