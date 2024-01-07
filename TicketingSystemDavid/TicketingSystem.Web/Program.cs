using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Data;
using TicketingSystem.Data.Models;
using TicketingSystem.Web.Infrastructure;
using TicketingSystem.Data.Common;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.Services;

namespace TicketingSystemDavid
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            builder.Services.AddDbContext<TicketingSystemDbContext>(options =>
                options.UseSqlServer(connectionString));


            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TicketingSystemDbContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            builder.Services.AddMemoryCache();
            builder.Services.AddResponseCaching();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.SeedAdminAndSupport(DataConstants.AdminEmail, DataConstants.SupportEmail);

            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                    name: "areas",
                    pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                config.MapControllerRoute(
                    name: "ProtectingUrlRoute",
                    pattern: "/{controller}/{action}/{id}/{information}",
                    defaults: new { Controller = "Project", Action = "All" });

                config.MapDefaultControllerRoute();

                config.MapRazorPages();
            });

            app.Run();
        }
    }
}