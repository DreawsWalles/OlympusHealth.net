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
    public class HistoryNodeConfiguration : IEntityTypeConfiguration<HistoryNode>
    {
        public void Configure(EntityTypeBuilder<HistoryNode> builder)
        {
            builder.ToTable("history_nodes");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Text).IsRequired();
            builder.Property(e => e.DateCreation).IsRequired();

            builder.HasOne(e => e.SysAdmin)
                .WithMany(e => e.HistoryNodes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey("sys_admin_id");

            builder.HasOne(e => e.Patient)
                .WithMany(e => e.HistoryNodes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey("patient_id");

            builder.HasOne(e => e.Medic)
                .WithMany(e => e.HistoryNodes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey("medic_id");
        }
    }
}
