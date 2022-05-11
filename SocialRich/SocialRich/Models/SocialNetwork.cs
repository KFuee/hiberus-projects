using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialRich.Models
{
    public class SocialNetwork
    {
        public long SocialNetworkId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }

        [InverseProperty("SocialNetworks")]
        public virtual ICollection<User> Users { get; set; }
    }
}
