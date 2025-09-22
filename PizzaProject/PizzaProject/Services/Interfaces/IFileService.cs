namespace PizzaProject.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file, string rootPath, string folderName, int maxSizeKB = 600);
        void Delete(string filePath);
    }
}
