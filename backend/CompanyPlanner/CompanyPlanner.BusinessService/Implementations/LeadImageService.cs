using CompanyPlanner.BusinessService.Interfaces;
using CompanyPlanner.DataService.Repositories.Interfaces;
using CompanyPlanner.Infrastructure.Entitities;

namespace CompanyPlanner.BusinessService.Implementations
{
    public class LeadImageService : ILeadImageService
    {
        private readonly ILeadDataService _leadDataService;
        private const int MaxImages = 10;

        public LeadImageService(ILeadDataService leadDataService)
        {
            _leadDataService = leadDataService;
        }

        public async Task<Lead?> GetLeadAsync(int leadId)
        {
            return await _leadDataService.GetLeadWithImagesAsync(leadId);
        }

        public async Task<bool> UploadImagesAsync(int leadId, List<string> base64Images)
        {
            var lead = await _leadDataService.GetLeadWithImagesAsync(leadId);
            if (lead == null) return false;

            if (lead.Images.Count + base64Images.Count > MaxImages)
                throw new InvalidOperationException($"Max {MaxImages} images allowed.");

            var newImages = base64Images.Select(b => new LeadImage { Base64Data = b });
            _leadDataService.AddLeadImagesAsync(lead, newImages);
            await _leadDataService.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteImageAsync(int imageId)
        {
            var image = await _leadDataService.GetLeadImageByIdAsync(imageId);
            if (image == null) return false;

            _leadDataService.RemoveLeadImageAsync(image);
            await _leadDataService.SaveChangesAsync();

            return true;
        }

    }
}
