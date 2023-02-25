using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(p=>p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.Description).IsRequired();
            builder.Property(p=>p.Location).IsRequired();
            builder.Property(p=>p.Price).IsRequired();
            builder.Property(p=>p.Area).IsRequired();
            builder.Property(p=>p.Rooms).IsRequired();
        }
    }
}
