using PostsService.ViewModels.PostServiceViewModel;
using System.Collections.Generic;

namespace PostsService.Interface
{
    public interface IPostService
    {
        public List<PostResponse> Get();
        public string Create(PostRequest data);
    }
}
