using Business.Enties.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.Address
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("city");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();

            //builder.HasOne(e => e.Region)
            //    .WithMany(e => e.Citys)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .HasForeignKey("region_id");

            builder.HasMany(e => e.Streets)
                .WithOne(e => e.City)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
