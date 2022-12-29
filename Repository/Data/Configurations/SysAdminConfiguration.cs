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
    public class SysAdminConfiguration : IEntityTypeConfiguration<SysAdmin>
    {
        public void Configure(EntityTypeBuilder<SysAdmin> builder)
        {
            builder.ToTable("sys_admin");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Login, "index_sys_admin_login").IsUnique();
            builder.Property(e => e.Login).IsRequired();
            builder.Property(e => e.Login);
            builder.Property(e => e.Password).IsRequired();
        }
    }
}
