using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Configurations.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public class DescriptionOfSignsConfiguration : IEntityTypeConfiguration<DescriptionOfSigns>
    {
        public void Configure(EntityTypeBuilder<DescriptionOfSigns> builder)
        {
            builder.ToTable("descriptiones_of_signses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.SerialNumber).IsRequired();

            builder.HasMany(e => e.Methods)
                .WithMany(e => e.DescriptionOfSigns);

            builder.HasMany(e => e.StatusOfTheAttributes)
                .WithOne(e => e.DescriptionOfSigns)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
