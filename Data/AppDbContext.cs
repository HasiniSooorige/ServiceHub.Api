using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Models;

namespace ServiceHub.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceHub.Api.Models.ServiceProvider> ServiceProviders { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}