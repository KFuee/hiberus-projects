using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Restaurantes.Models;

[assembly: OwinStartup(typeof(Restaurantes.Startup))]
namespace Restaurantes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndUsers();
        }

        // Crea los roles y usuarios por defecto
        public void createRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            string userDefaultPassword = "Pass123123+";

            // Comprueba si existe el rol admin
            if (!roleManager.RoleExists("Admin"))
            {
                // Crea el rol administrador
                IdentityRole adminRole = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(adminRole);

                // Crea el usuario admin sin privilegios de borrado
                ApplicationUser adminUser = new ApplicationUser
                {
                    UserName = "admin@restaurante.com",
                    Email = "admin@restaurante.com"
                };

                var createAdminUser = userManager.Create(adminUser, userDefaultPassword);
                if(createAdminUser.Succeeded)
                {
                    userManager.AddToRole(adminUser.Id, "Admin");
                }

                // Crea el usuario superadmin
                ApplicationUser superadminUser = new ApplicationUser
                {
                    UserName = "superadmin@restaurante.com",
                    Email = "superadmin@restaurante.com"
                };

                var createSuperAdminUser = userManager.Create(superadminUser, userDefaultPassword);
                if (createSuperAdminUser.Succeeded) {
                    userManager.AddToRole(superadminUser.Id, "Admin");
                }
            }

            // Comprueba si existe el rol develop
            if (!roleManager.RoleExists("Develop")) {
                // Crea el rol develop
                IdentityRole developRole = new IdentityRole
                {
                    Name = "Develop"
                };
                roleManager.Create(developRole);

                // Crea el usuario develop
                ApplicationUser developUser = new ApplicationUser
                {
                    UserName = "developuser@restaurante.com",
                    Email = "developuser@restaurante.com"
                };

                var createDevelopUser = userManager.Create(developUser, userDefaultPassword);
                if(createDevelopUser.Succeeded)
                {
                    userManager.AddToRole(developUser.Id, "Develop");
                }
            }
        }
    }
}
