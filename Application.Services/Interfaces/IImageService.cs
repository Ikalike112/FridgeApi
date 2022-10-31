using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IImageService
    {
        Task<string> SaveImage(IFormFile image);
        Task DeleteImage(string ImagePath);
    }
}
