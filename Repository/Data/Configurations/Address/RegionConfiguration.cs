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
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("regions");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();

            //builder.HasOne(e => e.Country)
            //    .WithMany(e => e.Regions)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .HasForeignKey("country_id");

            builder.HasMany(e => e.Citys)
                .WithOne(e => e.Region)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
