using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Data.Configuration;
using TicketingSystem.Data.Models;

namespace TicketingSystem.Data
{
    public class TicketingSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public TicketingSystemDbContext(DbContextOptions<TicketingSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; } = null!;

        public DbSet<Project> Projects { get; set; } = null!;

        public DbSet<Ticket> Tickets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            EntitySeedDataConfiguration.Seed(builder);

            base.OnModelCreating(builder);
        }
    }
}
