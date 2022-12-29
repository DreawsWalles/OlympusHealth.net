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
    public class HightSchoolConfiguration : IEntityTypeConfiguration<HightSchool>
    {
        public void Configure(EntityTypeBuilder<HightSchool> builder)
        {
            builder.ToTable("hight_schools");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name, "hight_schools_name_index").IsUnique();
            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.Street)
                .WithMany(e => e.HightSchools)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("street_id");

            builder.HasMany(e => e.PlaceOfStudies)
                .WithOne(e => e.HightSchools)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
