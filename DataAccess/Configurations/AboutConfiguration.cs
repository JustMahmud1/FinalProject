using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
	public class AboutConfiguration : IEntityTypeConfiguration<About>
	{
		public void Configure(EntityTypeBuilder<About> builder)
		{
			builder.Property(a => a.Title).IsRequired().HasMaxLength(50);
			builder.Property(a => a.Image1).IsRequired();
			builder.Property(a => a.ImageDescription).IsRequired().HasMaxLength(30);
			builder.Property(a => a.ImageSubDescription).IsRequired().HasMaxLength(20);
			builder.Property(a => a.DescriptionHeader).IsRequired().HasMaxLength(40);
			builder.Property(a => a.Description).IsRequired().HasMaxLength(255);
			builder.Property(a => a.Image2).IsRequired();
		}
	}
}
