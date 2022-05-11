using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialRich.Models
{
    public class User
    {
        public long UserId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public long? FavouriteSocialNetworkId { get; set; }
        [ForeignKey("FavouriteSocialNetworkId")]
        public virtual SocialNetwork FavouriteSocialNetwork { get; set; }

        public virtual ICollection<SocialNetwork> SocialNetworks { get; set; }
    }
}
