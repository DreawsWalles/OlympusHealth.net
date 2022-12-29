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
    public class PlaceOfStudyConfiguration : IEntityTypeConfiguration<PlaceOfStudy>
    {
        public void Configure(EntityTypeBuilder<PlaceOfStudy> builder)
        {
            builder.ToTable("place_of_stydies");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.StartEducation).IsRequired();

            builder.HasOne(e => e.Medic)
                .WithMany(e => e.PlaceOfStudies)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("medic_id");

            builder.HasOne(e => e.Specialization)
                .WithMany(e => e.PlaceOfStudies)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("specialization_id");

            builder.HasOne(e => e.AdvancedTrainingCourses)
                .WithMany(e => e.PlaceOfStudies)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("advanced_training_courses_id");

            builder.HasOne(e => e.HightSchools)
                .WithMany(e => e.PlaceOfStudies)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("hight_school_id");

            builder.HasOne(e => e.Interships)
                .WithMany(e => e.PlaceOfStudies)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("interships_id");

            builder.HasOne(e => e.Specialities)
                .WithMany(e => e.PlaceOfStudies)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("specialities_id");
        }
    }
}
