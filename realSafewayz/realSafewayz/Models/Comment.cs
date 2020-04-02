using System;
using System.Collections.Generic;
using System.Text;

namespace realSafewayz.Models
{
    public class Comment
    {
        public UserProfile UserWhoCommented { get; set; }
        public string UsersComment { get; set; }
        public DateTime DateOfComment { get; set; }
        public int CommentUpvotes { get; set; }
    }
}
