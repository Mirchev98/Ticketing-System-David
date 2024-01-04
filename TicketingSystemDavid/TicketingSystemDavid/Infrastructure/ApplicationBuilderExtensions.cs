using Microsoft.AspNetCore.Identity;
using TicketingSystem.Data.Common;
using TicketingSystem.Data.Models;

namespace TicketingSystem.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdminAndSupport(this IApplicationBuilder app, string adminEmail, string supportEmail)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(DataConstants.AdminRoleName))
                    {
                        return;
                    }

                    var roleAdmin = new IdentityRole { Name = DataConstants.AdminRoleName };

                    await roleManager.CreateAsync(roleAdmin);

                    if (await roleManager.RoleExistsAsync(DataConstants.SupportRoleName))
                    {
                        return;
                    }

                    var roleSupport = new IdentityRole { Name = DataConstants.SupportRoleName };

                    await roleManager.CreateAsync(roleSupport);

                    ApplicationUser adminUser = await userManager.FindByEmailAsync(adminEmail);
                    ApplicationUser supportUser = await userManager.FindByEmailAsync(supportEmail);

                    await userManager.AddToRoleAsync(adminUser, DataConstants.AdminRoleName);
                    await userManager.AddToRoleAsync(supportUser, DataConstants.SupportRoleName);
                }
                )
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
