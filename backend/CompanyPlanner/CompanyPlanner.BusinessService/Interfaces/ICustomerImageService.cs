using CompanyPlanner.Infrastructure.Entitities;

namespace CompanyPlanner.BusinessService.Interfaces
{
    public interface ICustomerImageService
    {
        Task<Customer?> GetCustomerAsync(int customerId);
        Task<bool> UploadImagesAsync(int customerId, List<string> base64Images);
        Task<bool> DeleteImageAsync(int imageId);
    }
}
