using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Vacations.BLL.Models;
using Vacations.BLL.Services;
using Vacations.DAL.Models;

namespace Vacations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        CloudBlobContainer _blobContainer;
        IUsersService _usersService;
        IMapper _mapper;
        private UserManager<User> _userManager;
        private IImagesService _imagesService;

        public ImagesController(
            IConfiguration configuration,
            IUsersService usersService,
            IMapper mapper,
            UserManager<User> userManager,
            IImagesService imagesService
            )
        {
            _usersService = usersService;
            _mapper = mapper;
            _userManager = userManager;
            _imagesService = imagesService;
            try
            {

                var storageConnectionString = configuration.GetConnectionString("StorageConnectionString");

                var storageAccount = CloudStorageAccount.Parse(storageConnectionString);

                // We are going to use Blob Storage, so we need a blob client.
                var blobClient = storageAccount.CreateCloudBlobClient();

                // Data in blobs are organized in containers.
                // Here, we create a new, empty container.
                _blobContainer = blobClient.GetContainerReference("images");
                _blobContainer.CreateIfNotExistsAsync();

                // We also set the permissions to "Public", so anyone will be able to access the file.
                // By default, containers are created with private permissions only.
                _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("upload")]
        public async Task<IActionResult> Post()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                var file = Request.Form.Files[0];
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    var fileContent = binaryReader.ReadBytes((int)file.Length);
                    var blockBlob = _blobContainer.GetBlockBlobReference(file.Name);

                    await blockBlob.UploadFromByteArrayAsync(fileContent, 0, fileContent.Length);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}