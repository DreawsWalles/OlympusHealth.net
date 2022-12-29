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
    public class StatusOfTheAttributeConfiguration : IEntityTypeConfiguration<StatusOfTheAttribute>
    {
        public void Configure(EntityTypeBuilder<StatusOfTheAttribute> builder)
        {
            builder.ToTable("status_of_the_attributes");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.DescriptionOfSigns)
                .WithMany(e => e.StatusOfTheAttributes)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey("description_of_signs_id");

            builder.HasMany(e => e.Descriptions)
                .WithMany(e => e.StatusOfTheAttributes);
        }
    }
}
