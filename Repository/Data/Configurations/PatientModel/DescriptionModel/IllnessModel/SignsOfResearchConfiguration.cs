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
    public class SignsOfResearchConfiguration : IEntityTypeConfiguration<SignsOfResearch>
    {
        public void Configure(EntityTypeBuilder<SignsOfResearch> builder)
        {
            builder.ToTable("signs_of_researches");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.Illness)
                .WithMany(e => e.SignsOfResearches)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("illness_id");

            builder.HasMany(e => e.ResultIllnesses)
                .WithOne(e => e.SignsOfResearch)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
