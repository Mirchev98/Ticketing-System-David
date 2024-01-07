using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;
using TicketingSystem.Data.Common;
using TicketingSystem.Data.Models;

namespace TicketingSystem.Data.Configuration
{
    public class EntitySeedDataConfiguration
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasData(
                new ApplicationUser
                {
                    Id = "AdminUser",
                    Email = DataConstants.AdminEmail,
                    NormalizedEmail = DataConstants.AdminEmail,
                    UserName = DataConstants.AdminEmail,
                    NormalizedUserName = DataConstants.AdminEmail,
                    FirstName = DataConstants.FirstNameAdmin,
                    LastName = DataConstants.LastNameAdmin,
                    PasswordHash = Crypto.HashPassword(DataConstants.Password),
                    IsAdmin = true,
                    IsAuthorized = true
                },
                new ApplicationUser
                {
                    Id = "SupportUser",
                    Email = DataConstants.SupportEmail,
                    NormalizedEmail = DataConstants.SupportEmail,
                    UserName = DataConstants.SupportEmail,
                    NormalizedUserName = DataConstants.SupportEmail,
                    FirstName = DataConstants.FirstNameSupport,
                    LastName = DataConstants.LastNameSupport,
                    PasswordHash = Crypto.HashPassword(DataConstants.Password),
                    IsAuthorized = true,
                    IsSupport = true
                },
                new ApplicationUser
                {
                    Id = "NormalUser",
                    Email = DataConstants.UserEmail,
                    NormalizedEmail = DataConstants.UserEmail,
                    UserName = DataConstants.UserEmail,
                    NormalizedUserName = DataConstants.UserEmail,
                    FirstName = DataConstants.FirstNameUser,
                    LastName = DataConstants.LastNameUser,
                    PasswordHash = Crypto.HashPassword(DataConstants.Password),
                    IsAuthorized = true
                });

            modelBuilder.Entity<Project>()
                .HasData(
                new Project
                {
                    Id = 1,
                    Name = "Test Project One",
                    Description = "Just for testing"
                },
                new Project
                {
                    Id = 2,
                    Name = "Super Cool Project",
                    Description = "It's a fun project to work on"
                },
                new Project
                {
                    Id = 3,
                    Name = "Lorem Ispum",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce eu pretium nunc. Nulla porttitor et mauris tristique commodo. Ut ac lectus eget purus commodo dapibus vel vel arcu. Sed mattis, tortor a dignissim scelerisque, ex justo hendrerit tortor, vel tincidunt lectus erat eget magna."
                });

            modelBuilder.Entity<Ticket>()
                .HasData(
                new Ticket
                {
                    Id = 1,
                    ProjectId = 1,
                    CreatorEmail = DataConstants.UserEmail,
                    CreatorId = "NormalUser",
                    Type = "Bug Report",
                    State = "New",
                    Heading = "Bug Found",
                    Description = "Very bad bug found"
                },
                new Ticket
                {
                    Id = 2,
                    ProjectId = 1,
                    CreatorEmail = DataConstants.UserEmail,
                    CreatorId = "NormalUser",
                    Type = "Feature Request",
                    State = "Work In Progress",
                    Heading = "Feature Idea",
                    Description = "A very nice feature to add"
                });

            modelBuilder.Entity<Message>()
                .HasData(
                new Message
                {
                    Id = 1,
                    CreatorEmail = DataConstants.SupportEmail,
                    CreatorId = "SupportUser",
                    State = "Posted",
                    Content = "Testing message",
                    TicketId = 1
                },
                new Message
                {
                    Id = 2,
                    CreatorEmail = DataConstants.UserEmail,
                    CreatorId = "NormalUser",
                    State = "Posted",
                    Content = "Second Message",
                    TicketId = 1
                });
        }
    }
}
