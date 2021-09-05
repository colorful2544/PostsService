using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using PostsService.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Services.ImageUploadService
{
    public class ImageUploadService : IImageUploadService
    {
        public List<string> UploadPost(List<IFormFile> files)
        {
            List<string> fileNames = new List<string>();

                foreach(IFormFile file in files)
                {
                    string fileName = Upload(file);
                    fileNames.Add(fileName);
                    Console.WriteLine(fileName);
                }
            
            if (fileNames.Count == 0) return null;
            return fileNames;
        }

        public string UploadProfile(IFormFile file)
        {
            throw new NotImplementedException();
        }

        private string Upload(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var fileExt = Path.GetExtension(fileName);
            var tmpName = Guid.NewGuid().ToString();
            var newFileName = string.Concat(tmpName, fileExt);
            var path = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images")).Root + $@"\{newFileName}";

            using (FileStream fs = File.Create(path))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            Console.WriteLine(newFileName);
            return newFileName;
        }
    }
}
