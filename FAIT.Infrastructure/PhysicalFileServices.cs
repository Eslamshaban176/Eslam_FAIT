using FAIT.Application.Abstraction;
using Microsoft.AspNetCore.Http;

namespace FAIT.Infrastructure;

public class PhysicalFileServices : IFileServices
{
    private readonly string _dir = @"C:\Users\Mahmoud\OneDrive\Desktop\New folder (2)";

    public async Task<string> Upload(IFormFile file)
    {
        if (Directory.Exists(_dir) == false)
            Directory.CreateDirectory(_dir);
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(_dir, fileName);
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);
        return Path.Combine(fileName);
    }
}