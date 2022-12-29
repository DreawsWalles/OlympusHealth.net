using Business.Enties.MedicModel.InstitutionModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.MedicModel.InsitutionModel
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("devices");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.Corpus)
                .WithMany(e => e.Devices)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey("corpus_id");

            builder.HasMany(e => e.Descriptions)
                .WithOne(e => e.Device)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
