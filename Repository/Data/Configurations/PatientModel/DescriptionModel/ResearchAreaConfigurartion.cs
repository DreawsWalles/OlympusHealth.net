using Business.Enties.PatientModel;
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
    public class ResearchAreaConfigurartion : IEntityTypeConfiguration<ResearchArea>
    {
        public void Configure(EntityTypeBuilder<ResearchArea> builder)
        {
            builder.ToTable("research_areas");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name, "research_areas_name_index").IsUnique();

            builder.HasOne(e => e.Patient)
                .WithMany(e => e.ResearchAreas)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("patient_id");

            builder.HasMany(e => e.Descriptions)
                .WithOne(e => e.ResearchArea)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.Methods)
                .WithOne(e => e.ResearchArea)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.OutpatientCard)
                .WithOne(e => e.ResearchArea)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<OutpatientCard>("outpatient_card_id");
        }
    }
}
