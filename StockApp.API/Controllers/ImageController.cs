using Microsoft.AspNetCore.Mvc;

namespace StockApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file");

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok(new { fileName = uniqueFileName, filePath = "/uploads/" + uniqueFileName });
        }

        [HttpGet("files")]
        public IActionResult GetFiles()
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                return Ok(new string[] { });

            var files = Directory.GetFiles(uploadsFolder)
                                 .Select(file => new
                                 {
                                     fileName = Path.GetFileName(file),
                                     filePath = "/uploads/" + Path.GetFileName(file)
                                 });

            return Ok(files);
        }
    }
}