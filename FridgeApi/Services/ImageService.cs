using Application.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using System;
using FridgeApi.Options;

namespace FridgeApi.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ImageServiceOptions _options;
        private readonly IFileSystem _fileSystem;

        public ImageService(IWebHostEnvironment webHostEnvironment, IOptions<ImageServiceOptions> options, IFileSystem fileSystem)
        {
            _environment = webHostEnvironment;
            _fileSystem = fileSystem;
            _options = options.Value;
        }

        public Task DeleteImage(string ImagePath)
        {
            ImagePath = ImagePath.Replace(_options.AppUrl, _environment.WebRootPath+"\\").Replace("/", "\\");
            if (_fileSystem.File.Exists(ImagePath))
            {
                _fileSystem.File.Delete(ImagePath);
            }
            return Task.FromResult(0);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            if (image == null)
            {
                throw new ArgumentException("Image can't be null", nameof(image));
            }

            string folderToSave = Path.Combine(_environment.WebRootPath, _options.FolderToSave);

            string filename = $"{Path.GetRandomFileName()}{Path.GetExtension(image.FileName)}";

            await using (var stream = _fileSystem.File.Create(Path.Combine(folderToSave, filename)))
            {
                await image.CopyToAsync(stream);
            }

            return $"{_options.AppUrl}{_options.FolderToSave}/{filename}";
        }
    }
}
