using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.ViewModels.PostServiceViewModel
{
    public class PostRequest
    {
        public string Name { get; set; }
        public List<IFormFile> imagesList { get; set; }
        public string detail {  get; set; }
    }
}
