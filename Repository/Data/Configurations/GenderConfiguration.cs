using Business.Enties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("genders");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name, "genders_name_index").IsUnique();
            builder.Property(e => e.Name).IsRequired();

            builder.HasMany(e => e.Patients)
                .WithOne(e => e.Gender)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Medics)
                .WithOne(e => e.Gender)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
