namespace Eapproval.Helpers
{
    public class FileHandler
    {
        public string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 8)
                + Path.GetExtension(fileName);
        }

        public async Task<string> SaveFile(string path, string filename, IFormFile file)
        {

            var filePath = Path.Combine(path, filename);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
              await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
