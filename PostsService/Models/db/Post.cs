using System;
using System.Collections.Generic;

#nullable disable

namespace PostsService.Models.db
{
    public partial class Post
    {
        public Post()
        {
            PostsComments = new HashSet<PostsComment>();
            PostsImages = new HashSet<PostsImage>();
            PostsLikes = new HashSet<PostsLike>();
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
        public string Detail { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PostsComment> PostsComments { get; set; }
        public virtual ICollection<PostsImage> PostsImages { get; set; }
        public virtual ICollection<PostsLike> PostsLikes { get; set; }
    }
}
