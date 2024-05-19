namespace MVC.PL.Helpers
{
    public static class DocumentSetting
    {
        public static string UploadFile(IFormFile file, string FolderName)
        {

            // string FolderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Files\\{FolderName}";
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "\\wwwroot\\Files", FolderName);
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            var FileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string FilePath = Path.Combine(FolderPath, FileName);

            using var FileStream = new FileStream(FilePath, FileMode.Create);

            file.CopyTo(FileStream);

            return FileName;
        }
        public static void Delete(string fileName, string folderName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "\\wwwroot\\Files", folderName);
            var filePath = Path.Combine(folderPath, fileName);

            if(File.Exists(filePath))
                File.Delete(filePath);
            

        }
    }

  
}