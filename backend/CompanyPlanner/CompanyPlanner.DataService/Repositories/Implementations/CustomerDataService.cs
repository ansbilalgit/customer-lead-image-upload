using CompanyPlanner.DataService.DBContext;
using CompanyPlanner.DataService.Repositories.Interfaces;
using CompanyPlanner.Infrastructure.Entitities;
using Microsoft.EntityFrameworkCore;

namespace CompanyPlanner.DataService.Repositories.Implementations
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly AppDbContext _context;

        public CustomerDataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetCustomerWithImagesAsync(int customerId)
        {
            return await _context.Customers
                .Include(c => c.Images)
                .FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task<List<CustomerImage>> GetCustomerImagesAsync(int customerId)
        {
            return await _context.CustomerImages
                .Where(i => i.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<CustomerImage?> GetCustomerImageByIdAsync(int imageId)
        {
            return await _context.CustomerImages.FindAsync(imageId);
        }

        public void AddCustomerImagesAsync(Customer customer, IEnumerable<CustomerImage> images)
        {
            foreach (var img in images)
                customer.Images.Add(img);
        }

        public void RemoveCustomerImageAsync(CustomerImage image)
        {
            _context.CustomerImages.Remove(image);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
