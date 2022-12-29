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
    public class StreetConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.ToTable("streets");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name);

            //builder.HasOne(e => e.City)
            //    .WithMany(e => e.Streets)
            //    .OnDelete(DeleteBehavior.SetNull)
            //    .HasForeignKey("city_id");

            builder.HasMany(e => e.Medics)
                .WithOne(e => e.Address)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.AdvancedTrainingCourses)
                .WithOne(e => e.Street)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.HightSchools)
                .WithOne(e => e.Street)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Interships)
                .WithOne(e => e.Street)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Specialities)
                .WithOne(e => e.Street)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Corpuses)
                .WithOne(e => e.Street)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
