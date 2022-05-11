using SocialRich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialRich.ViewModels
{
    public class SocialNetworksIndexData
    {
        public long SocialNetworkId { get; set; }

        public string Name { get; set; }
        public string Url { get; set; }

        public int UsersCount { get; set; }
    }
}