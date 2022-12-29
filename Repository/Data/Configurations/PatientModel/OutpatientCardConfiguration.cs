using Business.Enties.PatientModel;
using Business.Enties.PatientModel.DescriptionModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.PatientModel
{
    public class OutpatientCardConfiguration : IEntityTypeConfiguration<OutpatientCard>
    {
        public void Configure(EntityTypeBuilder<OutpatientCard> builder)
        {
            builder.ToTable("outpatient_card");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DateLastAdmission).IsRequired();
            builder.HasOne(e => e.Patient)
                .WithMany(e => e.OutpatientCards)
                .HasForeignKey("patient_id");

            builder.HasOne(e => e.ResearchArea)
                .WithOne(e => e.OutpatientCard)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey<ResearchArea>("research_area_id");
        }
    }
}
