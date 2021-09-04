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
            List<string> fileNames= new List<string>();
            if(files !=  null)
            {
                foreach(IFormFile file in files)
                {
                    string fileName = Upload(file);
                    fileNames.Add(fileName);
                }
                return fileNames;
            }
            return null;
        }

        public string UploadProfile(IFormFile file)
        {
            throw new NotImplementedException();
        }

        private string Upload(IFormFile file)
        {
            if(file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var fileExt = Path.GetExtension(fileName);
                var tmpName = Guid.NewGuid().ToString();
                var newFileName = $"{tmpName}{fileExt}";
                var path = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images")).Root + $@"\{newFileName}";
                
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    stream.CopyTo(stream);
                    stream.Flush();
                }
                return newFileName;
            }
            return string.Empty;
        }
    }
}
