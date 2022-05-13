namespace Restaurantes.Migrations
{
    using Restaurantes.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Restaurantes.RestaurantContext";
        }

        protected override void Seed(RestaurantContext context)
        {
            if (context.Restaurants.Count() > 0)
            {
                return;
            }

            var restaurantsToAdd = new List<Restaurant>()
            {
                new Restaurant { Name="Comiditas", City="Zaragoza", Country= "Espa�a" },
                new Restaurant { Name="Aperitivitos", City="Madrid", Country= "Espa�a" },
                new Restaurant { Name="Dominos", City="Valencia", Country= "Espa�a" },
                new Restaurant { Name="Pizza-Hut", City="Cordoba", Country= "Espa�a" },
                new Restaurant { Name="Telepizza", City="Medellin", Country= "Colombia" },
                new Restaurant { Name="WOK", City="Milan", Country= "Italia" },
                new Restaurant { Name="BO-WOK", City="Paris", Country= "Francia" },
                new Restaurant { Name="Tagliatella", City="Caceres", Country= "Espa�a" },
                new Restaurant { Name="Ribs", City="Santander", Country= "Espa�a" },
                new Restaurant { Name="Casco", City="Teruel", Country= "Espa�a" },
                new Restaurant { Name="Tinker", City="Huesca", Country= "Espa�a" },
                new Restaurant { Name="Kebab", City="Zaragoza", Country= "Espa�a" },
                new Restaurant { Name="Muerde la pasta", City="Budapest", Country= "Hungria" },
                new Restaurant { Name="Tommy Mels", City="Zaragoza", Country= "Espa�a" },
                new Restaurant { Name="Don jorge", City="Vigo", Country= "Espa�a" },
                new Restaurant { Name="Papa Jhons", City="Sevilla", Country= "Espa�a" },
                new Restaurant { Name="El rincon", City="Malaga", Country= "Espa�a" },
                new Restaurant { Name="Da Claudio", City="Zaragoza", Country= "Espa�a" },
                new Restaurant { Name="Japones", City="Cartagena", Country= "Espa�a" },
                new Restaurant { Name="Vips", City="Lorca", Country= "Espa�a" },
                new Restaurant { Name="Burguer King", City="Cadiz", Country= "Espa�a" },
                new Restaurant { Name="Mcdonalds", City="Granada", Country= "Espa�a" },
                new Restaurant { Name="KFC", City="Almeria", Country= "Espa�a" },
                new Restaurant { Name="Los pollos hermanos", City="Zaragoza", Country= "Espa�a" },
                new Restaurant { Name="Pizza Planet", City="Antequera", Country= "Espa�a" },
                new Restaurant { Name="Taco Bell", City="Zaragoza", Country= "Espa�a" },
                new Restaurant { Name="Sakura", City="Huelva", Country= "Espa�a" },
                new Restaurant { Name="Thai", City="Madrid", Country= "Espa�a" },
                new Restaurant { Name="Udon", City="Barcelona", Country= "Espa�a" },
                new Restaurant { Name="Giros", City="Zaragoza", Country= "Espa�a" },
                new Restaurant { Name="J85", City="Caracas", Country= "Venezuela" }
            };

            context.Restaurants.AddRange(restaurantsToAdd);
            context.SaveChanges();
        }
    }
}
