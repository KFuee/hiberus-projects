namespace SocialRich.Migrations
{
    using SocialRich.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialRich.Models.SocialContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SocialRich.Models.SocialContext";
        }

        protected override void Seed(SocialRich.Models.SocialContext context)
        {
            // Añade usuarios de prueba con el Seeder
            List<User> users = new List<User>
            {
               new User { Name = "Alfonso", Surname = "Garcia" },
               new User { Name = "Pedro", Surname = "Perez" },
               new User { Name = "Marta", Surname = "Sancho" }
            };
            users.ForEach((user) => context.Users.AddOrUpdate(user));

            // Añade redes sociales de prueba con el Seeder
            List<SocialNetwork> socialNetworks = new List<SocialNetwork>
            {
                new SocialNetwork { Name = "WhatsApp", Url = "https://whatsapp.com" },
                new SocialNetwork {Name = "Instagram", Url = "https://instagram.com" },
                new SocialNetwork {Name = "Snapchat", Url = "https://snapchat.com" }
            };
            socialNetworks.ForEach((socialNetwork) => context.SocialNetworks.AddOrUpdate(socialNetwork));
        }
    }
}
