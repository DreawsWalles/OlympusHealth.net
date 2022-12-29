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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("countries");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name, "country_name_index").IsUnique();
            builder.Property(e => e.Name).IsRequired();

            builder.HasMany(e => e.Regions)
                .WithOne(e => e.Country)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
