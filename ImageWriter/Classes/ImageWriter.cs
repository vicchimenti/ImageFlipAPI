using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ImageFlipAPI.ImageWriter.Interface;
using ImageFlipAPI.ImageWriter.Helper;
using Microsoft.AspNetCore.Http;

namespace ImageFlipAPI.ImageWriter.Classes
{
    public class ImageWriter : IImageWriter
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }

            return "Invalid image file";
        }

        // ensure that the file is an image
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file?.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            return WriteHelper.GetImageFormat(fileBytes) != WriteHelper.ImageFormat.unknown;
        }
        
        // Write file to disk
        public async Task<string> WriteFile(IFormFile file)
        {
            string filename;
            try
            {
                var extension = "." + file.FileName.Split('.')
                                     [file.FileName.Split('.').Length];
                
                filename = Guid.NewGuid().ToString() + extension;
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", filename);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return filename;
        }
    }
}