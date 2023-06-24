using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartCampingAPI.Controllers
{
    [Route("smartcampingweb/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FilesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0) 
            {
                return BadRequest();
            }

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Fotos");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            string imageUrl = "/Fotos/" + uniqueFileName;

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { imageUrl });
        }

    }
}
