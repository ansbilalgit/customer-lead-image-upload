using CompanyPlanner.Infrastructure.Entitities;

namespace CompanyPlanner.DataService.Repositories.Interfaces
{
    public interface ICustomerDataService
    {
        Task<Customer?> GetCustomerWithImagesAsync(int customerId);
        Task<List<CustomerImage>> GetCustomerImagesAsync(int customerId);
        Task<CustomerImage?> GetCustomerImageByIdAsync(int imageId);
        void AddCustomerImagesAsync(Customer customer, IEnumerable<CustomerImage> images);
        void RemoveCustomerImageAsync(CustomerImage image);
        Task SaveChangesAsync();
    }
}
