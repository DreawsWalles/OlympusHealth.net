using Business.Enties.PatientModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.PatientModel
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("patients");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Login).IsRequired();
            builder.HasIndex(e => e.Login, "patients_login_index");

            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Surname).IsRequired();

            builder.HasIndex(e => e.Email, "patients_email_index").IsUnique();
            builder.HasIndex(e => e.PhoneNumber, "patients_phone_number_index").IsUnique();

            builder.HasOne(e => e.Gender)
                .WithMany(e => e.Patients)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("gender_id");

            builder.HasMany(e => e.HistoryNodes)
                .WithOne(e => e.Patient)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.OutpatientCards)
                .WithOne(e => e.Patient)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.ResearchAreas)
                .WithOne(e => e.Patient)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
