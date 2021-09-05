using System;
using System.Collections.Generic;

#nullable disable

namespace PostsService.Models.db
{
    public partial class PostsLike
    {
        public int Id { get; set; }
        public string PostId { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
