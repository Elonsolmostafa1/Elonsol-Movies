using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace UserApp.PL.Helpers
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            // 1- get located folder path
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            // 2- get file name and make it unique
            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            // 3- get file path
            string filePath = Path.Combine(folderPath, fileName);

            // 4- save file as streams
            using var fs = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fs);

            return fileName;


        }

        public static void DeleteFile(string fileName, string folderName)
        {
            if (folderName is not null && fileName is not null)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName, fileName);

                if (File.Exists(filePath))
                    File.Delete(filePath);
            }

        }
    }
}
