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
    public class AccessConfiguration : IEntityTypeConfiguration<Access>
    {
        public void Configure(EntityTypeBuilder<Access> builder)
        {
            builder.ToTable("accesses");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name, "accesses_name_index").IsUnique();

            builder.HasMany(e => e.Medics)
                .WithMany(e => e.AccessRights);
        }
    }
}
