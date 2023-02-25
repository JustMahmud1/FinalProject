using Microsoft.AspNetCore.Http;

namespace Business.Utilities.Extensions
{
    public static class CreateFileExtension
    {
        public static string CreateFile(this IFormFile file, string environment, string path)
        {
            string imagename = Guid.NewGuid() + file.FileName;
            string fullPath = Path.Combine(environment, path, imagename);
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return imagename;
        }
    }
}
