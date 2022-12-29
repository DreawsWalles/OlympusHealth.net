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
    public class SpecializationConfoguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.ToTable("specialization");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name, "specialization_name_index").IsUnique();

            builder.HasMany(e => e.PlaceOfStudies)
                .WithOne(e => e.Specialization)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
