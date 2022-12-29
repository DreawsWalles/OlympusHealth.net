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
    public class MethodConfiguration : IEntityTypeConfiguration<Method>
    {
        public void Configure(EntityTypeBuilder<Method> builder)
        {
            builder.ToTable("methods");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NameFieldMethod).IsRequired();
            builder.Property(e => e.NameTitle).IsRequired();

            builder.HasOne(e => e.ResearchArea)
                .WithMany(e => e.Methods)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("research_area_id");

            builder.HasMany(e => e.Descriptions)
                .WithOne(e => e.Method)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.RadiationDose)
                .WithOne(e => e.Method)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ResearchCategory)
                .WithMany(e => e.Methods)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("research_category_id");

            builder.HasMany(e => e.Illnesses)
                .WithMany(e => e.Methods);

            builder.HasMany(e => e.DescriptionOfSigns)
                .WithMany(e => e.Methods);
        }
    }
}
