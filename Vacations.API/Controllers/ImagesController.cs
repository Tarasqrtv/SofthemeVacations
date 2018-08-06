using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacations.BLL.Services;

namespace Vacations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesService _imagesService;

        public ImagesController(
            IImagesService imagesService
            )
        {
            _imagesService = imagesService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("upload")]
        public async Task<IActionResult> Post()
        {
            var file = Request.Form.Files[0];

            if (file == null)
            {
                return BadRequest();
            }

            await _imagesService.UploadAsync(file);

            return Ok();
        }
    }
}