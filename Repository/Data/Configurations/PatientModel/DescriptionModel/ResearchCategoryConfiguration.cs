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
    public class ResearchCategoryConfiguration : IEntityTypeConfiguration<ResearchCategory>
    {
        public void Configure(EntityTypeBuilder<ResearchCategory> builder)
        {
            builder.ToTable("research_categories");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name, "research_categories_name_index").IsUnique();

            builder.HasMany(e => e.Methods)
                .WithOne(e => e.ResearchCategory)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
