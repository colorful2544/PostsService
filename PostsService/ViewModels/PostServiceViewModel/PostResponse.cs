using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.ViewModels.PostServiceViewModel
{
    public class PostResponse
    {
        public string name { get; set; }
        public List<string> imagesList { get; set; }
        public int likesCount { get; set; }
    }
}
