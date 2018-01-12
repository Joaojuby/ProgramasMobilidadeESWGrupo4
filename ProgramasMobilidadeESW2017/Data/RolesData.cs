using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProgramasMobilidadeESW2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramasMobilidadeESW2017.Data
{
    public static class RolesData
    {
        private static readonly string[] Roles = new string[]
        {
            "Administrador","Utilizador"
        };

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                await dbContext.Database.MigrateAsync();

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                foreach (var role in Roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
        }

        public static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var user = await userManager.FindByNameAsync("admin@grupo4.esw");
                if (user == null)
                {
                    var admin = new ApplicationUser()
                    {
                        UserName = "admin@grupo4.esw",
                        PrimeiroNome = "Admin",
                        UltimoNome = "Admin",
                        Email = "admin@grupo4.esw",
                        SecurityStamp = Guid.NewGuid().ToString(),
                    };
                    await userManager.CreateAsync(admin, "AdminGrupo4");
                    admin.EmailConfirmed = true;

                    var appUser = await userManager.FindByNameAsync("admin@grupo4.esw");
                    await userManager.AddToRoleAsync(appUser, "Administrador");
                }

                user = await userManager.FindByNameAsync("user@grupo4.esw");
                if (user == null)
                {
                    var testUser = new ApplicationUser()
                    {
                        UserName = "user@grupo4.esw",
                        PrimeiroNome = "André",
                        UltimoNome = "Zeferino",
                        Email = "user@grupo4.esw",
                        SecurityStamp = Guid.NewGuid().ToString(),
                    };
                    await userManager.CreateAsync(testUser, "UserGrupo4");
                    testUser.EmailConfirmed = true;

                    var appUser = await userManager.FindByNameAsync("user@grupo4.esw");
                    await userManager.AddToRoleAsync(appUser, "Utilizador");
                }
            }
        }
    }
}
