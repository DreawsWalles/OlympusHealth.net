using Business.Enties.MedicModel.PlaceOfStudyModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.MedicModel.PlaceOfStudyModel
{
    public class IntershipConfiguration : IEntityTypeConfiguration<Intership>
    {
        public void Configure(EntityTypeBuilder<Intership> builder)
        {
            builder.ToTable("interships");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name, "interships_name_index").IsUnique();
            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.Street)
                .WithMany(e => e.Interships)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("street_id");
        }
    }
}
