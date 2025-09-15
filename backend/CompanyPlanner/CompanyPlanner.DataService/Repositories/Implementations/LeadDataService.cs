using CompanyPlanner.DataService.DBContext;
using CompanyPlanner.DataService.Repositories.Interfaces;
using CompanyPlanner.Infrastructure.Entitities;
using Microsoft.EntityFrameworkCore;

namespace CompanyPlanner.DataService.Repositories.Implementations
{

    public class LeadDataService : ILeadDataService
    {
        private readonly AppDbContext _context;

        public LeadDataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Lead?> GetLeadWithImagesAsync(int leadId)
        {
            return await _context.Leads
                .Include(l => l.Images)
                .FirstOrDefaultAsync(l => l.Id == leadId);
        }

        public async Task<List<LeadImage>> GetLeadImagesAsync(int leadId)
        {
            return await _context.LeadImages
                .Where(i => i.LeadId == leadId)
                .ToListAsync();
        }

        public async Task<LeadImage?> GetLeadImageByIdAsync(int imageId)
        {
            return await _context.LeadImages.FindAsync(imageId);
        }

        public void AddLeadImagesAsync(Lead lead, IEnumerable<LeadImage> images)
        {
            foreach (var img in images)
                lead.Images.Add(img);
        }

        public void RemoveLeadImageAsync(LeadImage image)
        {
            _context.LeadImages.Remove(image);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
