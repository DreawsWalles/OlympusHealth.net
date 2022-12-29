using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.PatientModel.DescriptionModel.IllnessModel
{
    public class ResultIllnessConfiguration : IEntityTypeConfiguration<ResultIllness>
    {
        public void Configure(EntityTypeBuilder<ResultIllness> builder)
        {
            builder.ToTable("result_illnesses");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name, "result_illnesses_name_index").IsUnique();

            builder.HasOne(e => e.SignsOfResearch)
                .WithMany(e => e.ResultIllnesses)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("signs_of_researh_id");

            builder.HasMany(e => e.Descriptions)
                .WithOne(e => e.ResultIllness)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
