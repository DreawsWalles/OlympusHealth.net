using Business.Enties.PatientModel.DescriptionModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.PatientModel.DescriptionModel
{
    public class ProcessDynamicsConfiguration : IEntityTypeConfiguration<ProcessDynamics>
    {
        public void Configure(EntityTypeBuilder<ProcessDynamics> builder)
        {
            builder.ToTable("process_dynamicses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name, "process_dynamicses_name_index").IsUnique();
            builder.HasMany(e => e.Descriptions)
                .WithOne(e => e.ProcessDynamics)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
