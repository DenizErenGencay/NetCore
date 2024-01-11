using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto requestDto)
        {
            ValidateFileUpload(requestDto);
            if(ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = requestDto.File,
                    FileExtension = Path.GetExtension(requestDto.File.FileName),
                    FileSizeInBytes = requestDto.FileName.Length,
                    FileName = requestDto.FileName,
                    FileDescription = requestDto.FileDescription,
                };

                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto requestDto)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(requestDto.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsopported file extension");
            }

            if(requestDto.File.Length > 10485760) 
            {
                ModelState.AddModelError("file", "Please upload a file smaller then 10mb");
            }
        }
    }
}
