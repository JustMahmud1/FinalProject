
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PropertyAmenity> PropertyAmenities { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<About> Abouts { get; set; }
    }
}
