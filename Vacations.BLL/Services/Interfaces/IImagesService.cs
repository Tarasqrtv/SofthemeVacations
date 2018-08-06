using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacations.BLL.Models;

namespace Vacations.BLL.Services
{
    public interface IImagesService
    {
        Task<string> GetUrlAsync(string imgName);

        Task UploadAsync(IFormFile file);
    }
}