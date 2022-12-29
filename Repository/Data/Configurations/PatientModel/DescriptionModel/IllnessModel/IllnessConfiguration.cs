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
    public class IllnessConfiguration : IEntityTypeConfiguration<Illness>
    {
        public void Configure(EntityTypeBuilder<Illness> builder)
        {
            builder.ToTable("illnesses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name, "illnesses_name_index").IsUnique();

            builder.HasMany(e => e.Methods)
                .WithMany(e => e.Illnesses);

            builder.HasMany(e => e.SignsOfResearches)
                .WithOne(e => e.Illness)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
