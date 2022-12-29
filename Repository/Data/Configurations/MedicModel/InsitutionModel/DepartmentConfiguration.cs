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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.Corpus)
                .WithMany(e => e.Departments)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("corpus_id");

            builder.HasOne(e => e.ChiefsOfDepartment)
                .WithMany(e => e.HeadOfDepartment)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("chiefs_of_department_id");

            builder.HasMany(e => e.Medics)
                .WithOne(e => e.Doctors)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.MedicRegistrators)
                .WithOne(e => e.MedicRegistrator)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
