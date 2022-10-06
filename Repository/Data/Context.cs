using Business.Enties;
using Business.Enties.Address;
using Business.Enties.MedicModel;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Enties.MedicModel.PlaceOfStudyModel;
using Business.Enties.PatientModel;
using Business.Enties.PatientModel.DescriptionModel;
using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class Context : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Corpus> Corpuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<PlaceOfStudy> PlaceOfStudies { get; set; }
        public DbSet<AdvancedTrainingCourses> AdvancedTrainingCourses { get; set; }
        public DbSet<Corpus_Medic> Corpus_Medics { get; set; }
        public DbSet<HightSchool> HightSchools { get; set; }
        public DbSet<Intership> Interships { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<OutpatientCard> OutpatientCards { get; set; }
        public DbSet<ResearchArea> ResearchAreas { get; set; }
        public DbSet<ResearchCategory> ResearchCategories { get; set; }
        public DbSet<RadiationDose> RadiationDoses { get; set; }
        public DbSet<ProcessDynamics> ProcessDynamics { get; set; }
        public DbSet<Method> Methods { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<HistoryNode> HistoryNodes { get; set; }
        public DbSet<SysAdmin> SysAdmins { get; set; }
        public DbSet<Description_StatusOfTheAttribute> Description_StatusOfTheAttributes { get; set; }
        public DbSet<DescriptionOfSigns> DescriptionOfSigns { get; set; }
        public DbSet<Method_DescriptionOfSigns> Method_DescriptionOfSigns { get; set; }
        public DbSet<StatusOfTheAttribute> StatusOfTheAttributes { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<Illness_Method> Illness_Methods { get; set; }
        public DbSet<ResultIllness> ResultIllnesses { get; set; }
        public DbSet<SignsOfResearch> SignsOfResearch { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //ConfigureSchema(builder);

            //base.OnModelCreating(builder);
        }
        private void ConfigureSchema(ModelBuilder builder)
        {
            ConfigureUnits(builder);
        }

        private void ConfigureUnits(ModelBuilder builder)
        {

            #region Address
            builder.Entity<Country>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Countries");
                entity.HasIndex(e => e.Name).HasName("CountryNameIndex").IsUnique();
                entity.HasMany<Region>().WithOne().HasForeignKey(e => e.Country).IsRequired();
            });

            builder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Regions");
                entity.HasMany<City>().WithOne().HasForeignKey(e => e.Region).IsRequired();
            });

            builder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Cities");
                entity.HasMany<Street>().WithOne().HasForeignKey(e => e.City).IsRequired();
            });

            builder.Entity<Street>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Streets");
                entity.HasMany<AdvancedTrainingCourses>().WithOne(e => e.Street);
                entity.HasMany<HightSchool>().WithOne(e => e.Street);
                entity.HasMany<Intership>().WithOne(e => e.Street);
                entity.HasMany<Speciality>().WithOne(e => e.Street);
                entity.HasMany<Corpus>().WithOne(e => e.Street);
                entity.HasMany<Medic>().WithOne(e => e.Address);
            });

            #endregion
            #region PlaceOfStudy

            builder.Entity<AdvancedTrainingCourses>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("AdvancedTrainingCourses");
                entity.HasIndex(e => e.Name).HasName("AdvancedTrainingCoursesNameIndex").IsUnique();
                
            });

            builder.Entity<HightSchool>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("HightSchools");
                entity.HasIndex(e => e.Name).HasName("HightSchoolsNameIndex").IsUnique();
               
            });

            builder.Entity<Intership>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Interships");
                entity.HasIndex(e => e.Name).HasName("IntershipsNameIndex").IsUnique();
                
            });

            builder.Entity<Speciality>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Specialities");
                entity.HasIndex(e => e.Name).HasName("SpecialitiesNameIndex").IsUnique();
                
            });

            builder.Entity<PlaceOfStudy>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("PlaceOfStudies");

                
            });

            builder.Entity<Specialization>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Specializations");
                entity.HasIndex(e => e.Name).HasName("SpecializationsNameIndex").IsUnique();
                entity.HasMany<PlaceOfStudy>().WithOne().HasForeignKey(e => e.Specialization);
            });
            #endregion

            builder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Roles");
                entity.HasIndex(e => e.Name).HasName("RolesNameIndex").IsUnique();
                entity.HasMany<Medic>().WithOne().HasForeignKey(e => e.Role);
            });
            #region Institution
            builder.Entity<Institution>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Institutions");
                entity.HasIndex(e => e.Name).HasName("InstitutionsNameIndex").IsUnique();
                entity.HasMany<Corpus>().WithOne().HasForeignKey(e => e.Institution);
            });

            builder.Entity<Corpus>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Corpuses");
                entity.HasMany<Corpus_Medic>().WithOne().HasForeignKey(e => e.Corpus);
                entity.HasMany<Department>().WithOne().HasForeignKey(e => e.Corpus);
                entity.HasMany<Device>().WithOne().HasForeignKey(e => e.Corpus);
            });

            builder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Departments");
                entity.HasMany<Medic>().WithOne().HasForeignKey(e => e.Doctors);
            });
            #endregion

            builder.Entity<SysAdmin>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Login });
                entity.ToTable("SysAdmins");
                entity.HasMany<HistoryNode>().WithOne().HasForeignKey(e => e.SysAdmin);
            });

            builder.Entity<HistoryNode>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("HistoryNodes");
            });

            builder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Files");
            });

            builder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Name });
                entity.ToTable("Genders");

                entity.HasMany<Medic>().WithOne().HasForeignKey(e => e.Gender);
                entity.HasMany<Patient>().WithOne().HasForeignKey(e => e.Gender);
            });

            builder.Entity<Medic>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Medics");
                entity.HasIndex(e => e.Login).HasName("MedicLoginIndex").IsUnique();
                entity.HasIndex(e => e.Email).HasName("MedicEmaicIndex").IsUnique();
                entity.HasIndex(e => e.PhoneNumber).HasName("MedicPhoneNumber").IsUnique();

                entity.HasMany<Corpus_Medic>().WithOne().HasForeignKey(e => e.Medic);
                entity.HasMany<Department>().WithOne().HasForeignKey(e => e.ChiefsOfDepartment);
                entity.HasMany<Department>().WithOne().HasForeignKey(e => e.MedicRegistrators);
                entity.HasMany<HistoryNode>().WithOne().HasForeignKey(e => e.Medic);
                entity.HasMany<PlaceOfStudy>().WithOne().HasForeignKey(e => e.Medic);
                entity.HasMany<Files>().WithOne().HasForeignKey(e => e.Medic);
                entity.HasMany<Description>().WithOne().HasForeignKey(e => e.HeadOfDepartment);
                entity.HasMany<Description>().WithOne().HasForeignKey(e => e.Doctor);
            });

            builder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Patients");
                entity.HasIndex(e => e.Login).HasName("PatientLoginIndex").IsUnique();
                entity.HasIndex(e => e.Email).HasName("PatientEmailIndex").IsUnique();
                entity.HasIndex(e => e.PhoneNumber).HasName("PatientPhoneNumber").IsUnique();

                entity.HasMany<HistoryNode>().WithOne().HasForeignKey(e => e.Patient);
                entity.HasMany<OutpatientCard>().WithOne().HasForeignKey(e => e.Patient);
                entity.HasMany<ResearchArea>().WithOne().HasForeignKey(e => e.Patient);
            });
            #region Description
            builder.Entity<RadiationDose>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("RadiationDoses");
            });

            builder.Entity<ResearchArea>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("ResearchAreas");
                entity.HasIndex(e => e.Name).HasName("ResearchAreaNameIndex").IsUnique();

                entity.HasMany<Description>().WithOne().HasForeignKey(e => e.ResearchArea);
                entity.HasMany<Method>().WithOne().HasForeignKey(e => e.ResearchArea);
            });

            builder.Entity<ResearchCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("ResearchCategories");
                entity.HasIndex(e => e.Name).HasName("ResearchCategoryNameIndex").IsUnique();

                entity.HasMany<Method>().WithOne().HasForeignKey(e => e.ResearchCategory);
            });

            builder.Entity<Method>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Methods");

                entity.HasIndex(e => e.NameFieldMethod).HasName("MethodNameFieldMethodIndex").IsUnique();
                entity.HasIndex(e => e.NameTitle).HasName("MethodNameTitleIndex").IsUnique();

                entity.HasMany<RadiationDose>().WithOne().HasForeignKey(e => e.Method);
                entity.HasMany<Description>().WithOne().HasForeignKey(e => e.Method);
                entity.HasMany<Method_DescriptionOfSigns>().WithOne().HasForeignKey(e => e.MethodId);
                entity.HasMany<Illness_Method>().WithOne().HasForeignKey(e => e.MethodId);
            });

            builder.Entity<Illness>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Illnesses");
                entity.HasIndex(e => e.Name).HasName("IllnessNameIndex").IsUnique();
                entity.HasMany<SignsOfResearch>().WithOne().HasForeignKey(e => e.Illness);
            });

            builder.Entity<Illness_Method>(entity =>
            {
                entity.ToTable("Illness_Methods");
                entity.HasKey(e => new { e.IllnessId, e.MethodId });
            });

            builder.Entity<SignsOfResearch>(entity =>
            {
                entity.ToTable("SignsOfResearches");
                entity.HasKey(e => e.Id);
                entity.HasMany<ResultIllness>().WithOne().HasForeignKey(e => e.SignsOfResearch);
            });

            builder.Entity<ResultIllness>(entity =>
            {
                entity.ToTable("ResultIllnesses");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Descriptions).HasName("ResultIllnessDescriptionIndex").IsUnique();

                entity.HasMany<Description>().WithOne().HasForeignKey(e => e.ResultIllness);
            });

            builder.Entity<ProcessDynamics>(entity =>
            {
                entity.ToTable("ProcessDynamicses");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).HasName("ProcessDynamicsNameIndex").IsUnique();

                entity.HasMany<Description>().WithOne().HasForeignKey(e => e.ProcessDynamics);
            });

            builder.Entity<DescriptionOfSigns>(entity =>
            {
                entity.ToTable("DescriptionsOfSigns");
                entity.HasKey(e => e.Id);

                entity.HasMany<StatusOfTheAttribute>().WithOne().HasForeignKey(e => e.DescriptionOfSigns);
            });

            builder.Entity<Method_DescriptionOfSigns>(entity =>
            {
                entity.ToTable("Method_DescriptionsOfSigns");
                entity.HasKey(e => new { e.MethodId, e.DescriptionOfSighsId });
            });

            builder.Entity<StatusOfTheAttribute>(entity =>
            {
                entity.ToTable("StatusOfTheAttribute");
                entity.HasKey(e => e.Id);

                entity.HasMany<Description_StatusOfTheAttribute>().WithOne().HasForeignKey(e => e.StatusOfTheAttributeId);
            });

            builder.Entity<Description_StatusOfTheAttribute>(entity =>
            {
                entity.ToTable("Description_StatusOfTheAttribute");
                entity.HasKey(e => new { e.StatusOfTheAttributeId, e.DescriptionId });
            });

            builder.Entity<Description>(entity =>
            {
                entity.ToTable("Descriptions");
                entity.HasKey(e => e.Id);

                entity.HasOne<Description>().WithOne();
            });
            #endregion
        }
    }
    
}
