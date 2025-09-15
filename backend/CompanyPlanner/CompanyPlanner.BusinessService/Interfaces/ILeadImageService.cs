using CompanyPlanner.Infrastructure.Entitities;

namespace CompanyPlanner.BusinessService.Interfaces
{
    public interface ILeadImageService
    {
        Task<Lead?> GetLeadAsync(int leadId);
        Task<bool> UploadImagesAsync(int leadId, List<string> base64Images);
        Task<bool> DeleteImageAsync(int imageId);
    }
}
