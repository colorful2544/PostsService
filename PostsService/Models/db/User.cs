using System;
using System.Collections.Generic;

#nullable disable

namespace PostsService.Models.db
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
            PostsComments = new HashSet<PostsComment>();
            PostsLikes = new HashSet<PostsLike>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public string ImageName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostsComment> PostsComments { get; set; }
        public virtual ICollection<PostsLike> PostsLikes { get; set; }
    }
}
