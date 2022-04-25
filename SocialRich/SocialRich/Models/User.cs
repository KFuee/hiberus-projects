using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialRich.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public SocialNetwork[] Networks { get; set; }
    }
}
