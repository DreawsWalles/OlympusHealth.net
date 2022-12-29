using Business.Enties.MedicModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.MedicModel
{
    public class FilesConfiguration : IEntityTypeConfiguration<Files>
    {
        public void Configure(EntityTypeBuilder<Files> builder)
        {
            builder.ToTable("files");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Content).IsRequired();

            builder.HasOne(e => e.Medic)
                .WithMany(e => e.Files)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("medic_id");
        }
    }
}
