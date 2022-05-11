using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SocialRich.Models
{
    public class SocialContext : DbContext
    {
        // Entities
        public DbSet<User> Users { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }


    }
}