using CompanyPlanner.BusinessService.Interfaces;
using CompanyPlanner.DataService.Repositories.Interfaces;
using CompanyPlanner.Infrastructure.Entitities;

namespace CompanyPlanner.BusinessService.Implementations
{
    public class CustomerImageService : ICustomerImageService
    {
        private readonly ICustomerDataService _dataService;
        private const int MaxImages = 10;

        public CustomerImageService(ICustomerDataService dataService) => _dataService = dataService;

        public async Task<Customer?> GetCustomerAsync(int customerId)
        {
            return await _dataService.GetCustomerWithImagesAsync(customerId);
        }

        public async Task<bool> UploadImagesAsync(int customerId, List<string> base64Images)
        {
            var customer = await _dataService.GetCustomerWithImagesAsync(customerId);
            if (customer == null) return false;

            if (customer.Images.Count + base64Images.Count > MaxImages)
                throw new InvalidOperationException($"Max {MaxImages} images allowed.");

            var newImages = base64Images.Select(b => new CustomerImage { Base64Data = b });
            _dataService.AddCustomerImagesAsync(customer, newImages);
            await _dataService.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteImageAsync(int imageId)
        {
            var image = await _dataService.GetCustomerImageByIdAsync(imageId);
            if (image == null) return false;

            _dataService.RemoveCustomerImageAsync(image);
            await _dataService.SaveChangesAsync();
            return true;
        }
    }
}
