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
    public class MedicConfiguration : IEntityTypeConfiguration<Medic>
    {
        public void Configure(EntityTypeBuilder<Medic> builder)
        {
            builder.ToTable("medics");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Login).IsRequired();
            builder.HasIndex(e => e.Login, "medics_login_index").IsUnique();

            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Surname).IsRequired();
            builder.Property(e => e.DateEmployment).IsRequired();

            builder.HasIndex(e => e.Email, "medics_email_index").IsUnique();
            builder.HasIndex(e => e.PhoneNumber, "medic_phome_number_index").IsUnique();

            builder.HasOne(e => e.Gender)
                .WithMany(e => e.Medics)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("gender_id");

            builder.HasOne(e => e.Role)
                .WithMany(e => e.Medic)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("role_id");

            builder.HasOne(e => e.Address)
                .WithMany(e => e.Medics)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("address_id")
                .IsRequired(false);

            builder.HasMany(e => e.Files)
                .WithOne(e => e.Medic)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.PlaceOfStudies)
                .WithOne(e => e.Medic)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.HeadOfDepartment)
                .WithOne(e => e.ChiefsOfDepartment)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.Doctors)
                .WithMany(e => e.Medics)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("doctor_id")
                .IsRequired(false);

            builder.HasOne(e => e.MedicRegistrator)
                .WithMany(e => e.MedicRegistrators)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("medic_registrator_id")
                .IsRequired(false);

            builder.HasMany(e => e.DesctioptionHeadOfDepartment)
                .WithOne(e => e.HeadOfDepartment)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Descriptions)
                .WithOne(e => e.Doctor)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Corpuses)
                .WithOne(e => e.Medics)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.AccessRights)
                .WithMany(e => e.Medics);
        }
    }
}
