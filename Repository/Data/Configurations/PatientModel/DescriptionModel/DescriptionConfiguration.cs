using Business.Enties.PatientModel.DescriptionModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.PatientModel.DescriptionModel
{
    public class DescriptionConfiguration : IEntityTypeConfiguration<Description>
    {
        public void Configure(EntityTypeBuilder<Description> builder)
        {
            builder.ToTable("descriptions");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.DateCreation).IsRequired();

            builder.HasOne(e => e.ResearchArea)
                .WithMany(e => e.Descriptions)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("research_area_id");

            builder.HasOne(e => e.HeadOfDepartment)
                .WithMany(e => e.DesctioptionHeadOfDepartment)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("head_of_department_id");

            builder.HasOne(e => e.Doctor)
                .WithMany(e => e.Descriptions)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("doctor_id");

            builder.HasOne(e => e.Device)
                .WithMany(e => e.Descriptions)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("device_id");

            builder.HasOne(e => e.Method)
                .WithMany(e => e.Descriptions)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("method_id");

            builder.HasOne(e => e.SubDescription);

            builder.HasOne(e => e.ResultIllness)
                .WithMany(e => e.Descriptions)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("result_illness_id");

            builder.HasOne(e => e.ProcessDynamics)
                .WithMany(e => e.Descriptions)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("process_dynamics_id");

            builder.HasMany(e => e.StatusOfTheAttributes)
                .WithMany(e => e.Descriptions);
        }
    }
}
