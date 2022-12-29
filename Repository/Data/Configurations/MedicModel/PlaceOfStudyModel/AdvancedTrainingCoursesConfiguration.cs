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
    public class AdvancedTrainingCoursesConfiguration : IEntityTypeConfiguration<AdvancedTrainingCourses>
    {
        public void Configure(EntityTypeBuilder<AdvancedTrainingCourses> builder)
        {
            builder.ToTable("advanced_training_courses");
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Name, "advanced_training_courses_name_index");
            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.Street)
                .WithMany(e => e.AdvancedTrainingCourses)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("street_id");

            builder.HasMany(e => e.PlaceOfStudies)
                .WithOne(e => e.AdvancedTrainingCourses)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
