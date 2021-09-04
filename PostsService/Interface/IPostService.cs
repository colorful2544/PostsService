using PostsService.ViewModels.PostServiceViewModel;

namespace PostsService.Interface
{
    public interface IPostService
    {
        public string Create(PostRequest data);
    }
}
