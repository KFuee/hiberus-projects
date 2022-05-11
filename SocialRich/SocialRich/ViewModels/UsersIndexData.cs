using SocialRich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialRich.ViewModels
{
    public class UsersIndexData
    {
        public long UserId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public SocialNetwork FavouriteSocialNetwork { get; set; }

        public int SocialNetworksCount { get; set; }
    }
}