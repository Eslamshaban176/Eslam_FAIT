using Microsoft.AspNetCore.Http;

namespace FAIT.Application.Abstraction;

public interface IFileServices
{
    Task<string> Upload(IFormFile file);
}