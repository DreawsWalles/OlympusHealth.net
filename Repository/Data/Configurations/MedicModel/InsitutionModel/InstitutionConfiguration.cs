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
    public class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.ToTable("institutions");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name, "institution_name_index").IsUnique();

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Avatar).IsRequired();

            builder.HasMany(e => e.Corpuses)
                .WithOne(e => e.Institution)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
