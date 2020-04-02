using System;
using System.Collections.Generic;
using System.Text;

namespace realSafewayz.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string Email { get; set; }
        public long UserToken { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public long UserPoints { get; set; }
        public string Password { get; set; }
    }
}
