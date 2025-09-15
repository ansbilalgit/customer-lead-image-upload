using CompanyPlanner.BusinessService.Interfaces;
using CompanyPlanner.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPlanner.API.Controllers
{
    [ApiController]
    [Route("api/leads")]
    public class LeadController : ControllerBase
    {
        private readonly ILeadImageService _imageService;

        public LeadController(ILeadImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("{leadId}/images")]
        public async Task<IActionResult> UploadImages(int leadId, [FromBody] ImageUploadDto dto)
        {
            try
            {
                var success = await _imageService.UploadImagesAsync(leadId, dto.Base64Images);
                return !success
                    ? NotFound(ApiResponse<string>.Fail("lead not found"))
                    : Ok(ApiResponse<string>.Ok(null, "Images uploaded successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }

        [HttpGet("{leadId}/images")]
        public async Task<IActionResult> GetImages(int leadId)
        {
            var lead = await _imageService.GetLeadAsync(leadId);
            if (lead == null)
                return NotFound(ApiResponse<IEnumerable<object>>.Fail("Lead not found"));

            var images = lead.Images.Select(i => new { i.Id, i.Base64Data });
            return Ok(ApiResponse<IEnumerable<object>>.Ok(images));
        }

        [HttpDelete("{leadId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage(int leadId, int imageId)
        {
            var lead = await _imageService.GetLeadAsync(leadId);
            if (lead == null)
                return NotFound(ApiResponse<string>.Fail("Lead not found"));

            var image = lead.Images.FirstOrDefault(i => i.Id == imageId);
            if (image == null)
                return NotFound(ApiResponse<string>.Fail("Image not found"));

            await _imageService.DeleteImageAsync(imageId);
            return Ok(ApiResponse<string>.Ok(null, "Image deleted successfully"));
        }
    }
}
