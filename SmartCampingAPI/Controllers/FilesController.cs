using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCampingAPI.Data;
using SmartCampingAPI.Dto;

namespace SmartCampingAPI.Controllers
{
    [Route("smartcamping/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FilesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0) 
            {
                return BadRequest();
            }

            // Specify the folder where you want to store the image
            var imagePath = "Fotos";

            // Generate a unique file name or use the original file name
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Combine the folder path and the file name
            var filePath = Path.Combine(imagePath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            var response = new { FilePath = filePath };

            return Ok(response);
        }
    }
}
