using PostsService.Interface;
using PostsService.Models.db;
using PostsService.ViewModels.PostServiceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostsService.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly PostsServiceContext _db;
        private readonly IImageUploadService _imageUpload;

        public PostService(PostsServiceContext db, IImageUploadService imageUpload)
        {
            _db = db;
            _imageUpload = imageUpload;
        }

        public string Create(PostRequest data)
        {
            if(data != null)
            {
                var user = _db.Users.FirstOrDefault(u => u.Username == data.Name);
                if(user != null)
                {
                    //Add post to database
                    string postId = Guid.NewGuid().ToString();
                    Post post = new Post
                    {
                        Id = postId,
                        UserId = user.Id,
                        Detail = data.detail
                    };
                    _db.Posts.Add(post);

                    //Add images to database
                    List<string> filesName = _imageUpload.UploadPost(data.imagesList);
                    foreach(var fileName in filesName)
                    {
                        PostsImage postsImage = new PostsImage
                        { 
                            PostId = postId,
                            ImageName = fileName,
                        };
                        _db.PostsImages.Add(postsImage);
                    }

                    _db.SaveChanges();
                    return postId;
                }
            }
            return string.Empty;
        }
    }
}
