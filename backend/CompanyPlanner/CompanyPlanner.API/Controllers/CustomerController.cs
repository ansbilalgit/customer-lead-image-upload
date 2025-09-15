using CompanyPlanner.BusinessService.Interfaces;
using CompanyPlanner.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPlanner.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerImageService _imageService;

        public CustomerController(ICustomerImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("{customerId}/images")]
        public async Task<IActionResult> UploadImages(int customerId, [FromBody] ImageUploadDto dto)
        {
            try
            {
                var success = await _imageService.UploadImagesAsync(customerId, dto.Base64Images);
                return !success
                    ? NotFound(ApiResponse<string>.Fail("Customer not found"))
                    : Ok(ApiResponse<string>.Ok(null, "Images uploaded successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }

        [HttpGet("{customerId}/images")]
        public async Task<IActionResult> GetImages(int customerId)
        {
            var customer = await _imageService.GetCustomerAsync(customerId);
            if (customer == null)
                return NotFound(ApiResponse<IEnumerable<object>>.Fail("Customer not found"));

            var images = customer.Images.Select(i => new { i.Id, i.Base64Data });
            return Ok(ApiResponse<IEnumerable<object>>.Ok(images));
        }

        [HttpDelete("{customerId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage(int customerId, int imageId)
        {
            var customer = await _imageService.GetCustomerAsync(customerId);
            if (customer == null)
                return NotFound(ApiResponse<string>.Fail("Customer not found"));

            var image = customer.Images.FirstOrDefault(i => i.Id == imageId);
            if (image == null)
                return NotFound(ApiResponse<string>.Fail("Image not found"));

            await _imageService.DeleteImageAsync(imageId);
            return Ok(ApiResponse<string>.Ok(null, "Image deleted successfully"));
        }

    }
}
