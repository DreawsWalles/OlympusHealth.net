using Business.Enties.MedicModel.PlaceOfStudyModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.MedicModel.PlaceOfStudyModel
{
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.ToTable("specialities");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name, "specialities_name_index");

            builder.HasOne(e => e.Street)
                .WithMany(e => e.Specialities)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("street_id");

            builder.HasMany(e => e.PlaceOfStudies)
                .WithOne(e => e.Specialities)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
