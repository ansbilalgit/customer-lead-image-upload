using CompanyPlanner.Infrastructure.Entitities;

namespace CompanyPlanner.DataService.Repositories.Interfaces
{
    public interface ILeadDataService
    {
        Task<Lead?> GetLeadWithImagesAsync(int leadId);
        Task<List<LeadImage>> GetLeadImagesAsync(int leadId);
        Task<LeadImage?> GetLeadImageByIdAsync(int imageId);
        void AddLeadImagesAsync(Lead lead, IEnumerable<LeadImage> images);
        void RemoveLeadImageAsync(LeadImage image);
        Task SaveChangesAsync();
    }
}
