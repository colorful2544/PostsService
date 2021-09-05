using Microsoft.EntityFrameworkCore;
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
        public List<PostResponse> Get()
        {
            List<PostResponse> response = new List<PostResponse>();

            var posts = GetPosts();
            foreach (var post in posts)
            {
                var images = GetImages(post.Id);
                var likesCount = GetLikesCount(post.Id);

                PostResponse item = new PostResponse 
                { 
                    name = post.User.Username,
                    imagesList = images,
                    likesCount = likesCount,
                };
                response.Add(item);
            }
            
            return response;
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
        private List<Post> GetPosts()
        {
            var post = _db.Posts.Include(u => u.User).OrderByDescending(p => p.Created).ToList();
            return post;
        }
        private List<string> GetImages(string id)
        {
            var images = _db.PostsImages.Where(u => u.PostId == id).Select(i => i.ImageName).ToList();
            return images;
        }
        private int GetLikesCount(string id)
        {
            var likesCount = _db.PostsLikes.Where(p => p.PostId == id).Count();
            return likesCount;
        }
    }
}
