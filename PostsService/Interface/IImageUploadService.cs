using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Interface
{
    public interface IImageUploadService
    {
        List<string> UploadPost(List<IFormFile> files);
        string UploadProfile(IFormFile file);
    }
}
