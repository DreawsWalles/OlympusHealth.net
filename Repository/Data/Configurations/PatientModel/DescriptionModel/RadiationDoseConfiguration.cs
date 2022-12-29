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
    public class RadiationDoseConfiguration : IEntityTypeConfiguration<RadiationDose>
    {
        public void Configure(EntityTypeBuilder<RadiationDose> builder)
        {
            builder.ToTable("radiation_dose");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Dose).IsRequired();

            builder.HasOne(e => e.Method)
                .WithMany(e => e.RadiationDose)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("method_id");
        }
    }
}
