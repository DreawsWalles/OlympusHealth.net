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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name, "roles_name_index").IsUnique();
            builder.Property(e => e.Name).IsRequired();

            builder.HasMany(e => e.Medic)
                .WithOne(e => e.Role)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
