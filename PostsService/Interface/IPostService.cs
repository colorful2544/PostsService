using PostsService.ViewModels.PostServiceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.Interface
{
    public interface IPostService
    {
        public void Create(PostRequest data);
    }
}
