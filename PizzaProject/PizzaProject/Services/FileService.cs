using PizzaProject.Services.Interfaces;

namespace PizzaProject.Services
{
    public class FileService : IFileService
    {
        public async Task<string> UploadAsync(IFormFile file, string rootPath, string folderName, int maxSizeKB = 600)
        {
            if (file == null) return null;

            if (file.Length / 1024 > maxSizeKB)
                throw new Exception($"File size must be max {maxSizeKB} KB");

            if (!file.ContentType.StartsWith("image/"))
                throw new Exception("Invalid file type");

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string folderPath = Path.Combine(rootPath, folderName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
