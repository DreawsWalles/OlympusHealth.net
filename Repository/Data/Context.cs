using Business.Enties;
using Business.Enties.Address;
using Business.Enties.MedicModel;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Enties.MedicModel.PlaceOfStudyModel;
using Business.Enties.PatientModel;
using Business.Enties.PatientModel.DescriptionModel;
using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repository.Data.Configurations;
using Repository.Data.Configurations.Address;
using Repository.Data.Configurations.MedicModel;
using Repository.Data.Configurations.MedicModel.InsitutionModel;
using Repository.Data.Configurations.MedicModel.PlaceOfStudyModel;
using Repository.Data.Configurations.PatientModel;
using Repository.Data.Configurations.PatientModel.DescriptionModel;
using Repository.Data.Configurations.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Repository.Data.Configurations.PatientModel.DescriptionModel.IllnessModel;
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
        public DbSet<DescriptionOfSigns> DescriptionOfSigns { get; set; }
        public DbSet<StatusOfTheAttribute> StatusOfTheAttributes { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<ResultIllness> ResultIllnesses { get; set; }
        public DbSet<SignsOfResearch> SignsOfResearch { get; set; }
        public DbSet<Access> Accesses { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) 
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SysAdminConfiguration());
            builder.ApplyConfiguration(new HistoryNodeConfiguration());
            builder.ApplyConfiguration(new GenderConfiguration());

            #region Address

            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new RegionConfiguration());
            builder.ApplyConfiguration(new StreetConfiguration());
            #endregion

            #region Medic
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new MedicConfiguration());
            builder.ApplyConfiguration(new FilesConfiguration());
            builder.ApplyConfiguration(new AccessConfiguration());

            #region Institution
            builder.ApplyConfiguration(new CorpusConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new DeviceConfiguration());
            builder.ApplyConfiguration(new InstitutionConfiguration());
            #endregion

            #region PlaceOfStudy
            builder.ApplyConfiguration(new AdvancedTrainingCoursesConfiguration());
            builder.ApplyConfiguration(new HightSchoolConfiguration());
            builder.ApplyConfiguration(new IntershipConfiguration());
            builder.ApplyConfiguration(new PlaceOfStudyConfiguration());
            builder.ApplyConfiguration(new SpecialityConfiguration());
            builder.ApplyConfiguration(new SpecializationConfoguration());
            #endregion
            #endregion

            #region Patient
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new OutpatientCardConfiguration());

            #region DescriptionModel
            builder.ApplyConfiguration(new ResearchCategoryConfiguration());
            builder.ApplyConfiguration(new ResearchAreaConfigurartion());
            builder.ApplyConfiguration(new RadiationDoseConfiguration());
            builder.ApplyConfiguration(new ProcessDynamicsConfiguration());
            builder.ApplyConfiguration(new MethodConfiguration());
            builder.ApplyConfiguration(new DescriptionConfiguration());

            #region Illness
            builder.ApplyConfiguration(new SignsOfResearchConfiguration());
            builder.ApplyConfiguration(new ResultIllnessConfiguration());
            builder.ApplyConfiguration(new SignsOfResearchConfiguration());
            #endregion

            #region DescriptionOfSignsModel
            builder.ApplyConfiguration(new DescriptionOfSignsConfiguration());
            builder.ApplyConfiguration(new StatusOfTheAttributeConfiguration());
            #endregion
            #endregion
            #endregion
        }


    }
    
}
