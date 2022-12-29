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
    public class CorpusConfiguration : IEntityTypeConfiguration<Corpus>
    {
        public void Configure(EntityTypeBuilder<Corpus> builder)
        {
            builder.ToTable("corpuses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.Institution)
                .WithMany(e => e.Corpuses)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("institution_id");

            builder.HasOne(e => e.Street)
                .WithMany(e => e.Corpuses)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("street_id");

            builder.HasMany(e => e.Devices)
                .WithOne(e => e.Corpus)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Departments)
                .WithOne(e => e.Corpus)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.Medics)
                .WithMany(e => e.Corpuses)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("medics_id");
        }
    }
}
