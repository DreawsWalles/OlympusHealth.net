using AutoMapper;
using Business.Repository.DataRepository;
using Business.Repository.DataRepository.Address;
using Business.Repository.DataRepository.MedicModel;
using Business.Repository.DataRepository.MedicModel.InstitutionModel;
using Business.Repository.DataRepository.MedicModel.PlaceOfStudyModel;
using Business.Repository.DataRepository.PatientModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel.IllnessModel;
using Business.Service;
using Business.Service.Address;
using Business.Service.MedicModel;
using Business.Service.MedicModel.InstitutionModel;
using Business.Service.MedicModel.PlaceOfStudyModel;
using Business.Service.PatientModel;
using Business.Service.PatientModel.DescriptionModel;
using Business.Service.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Service.PatientModel.DescriptionModel.IllnessModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Address;
using Repository.Repositories.MedicModel;
using Repository.Repositories.MedicModel.InstitutionModel;
using Repository.Repositories.MedicModel.PlaceOfStudyModel;
using Repository.Repositories.PatientModel;
using Repository.Repositories.PatientModel.DescriptionModel;
using Repository.Repositories.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Repository.Repositories.PatientModel.DescriptionModel.IllnessModel;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(
    options => options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")),
    contextLifetime: ServiceLifetime.Scoped,
    optionsLifetime: ServiceLifetime.Transient);


#region Service

#region Address

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IStreetService, StreetService>();

#endregion

#region MedicModel
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IMedicService, MedicService>();
builder.Services.AddScoped<IFilesService, FilesService>();
builder.Services.AddScoped<IAccessService, AccessService>();

#region InstitutionModel

builder.Services.AddScoped<ICorpusService, CorpusService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IInstitutionService, InstitutionService>();

#endregion

#region PlaceOfStudyModel

builder.Services.AddScoped<ISpecializationService, SpecializationService>();
builder.Services.AddScoped<IPlaceOfStudyService, PlaceOfStudyService>();

#region AdvancedTrainingCoursesModel

builder.Services.AddScoped<IAdvancedTrainingCourcesService, AdvancedTrainingCourcesService>();

#endregion

#region HightSchoolModel

builder.Services.AddScoped<IHightSchoolService, HightSchoolService>();

#endregion

#region IntershipModel

builder.Services.AddScoped<IIntershipService, IntershipService>();

#endregion

#region SpecialityModel

builder.Services.AddScoped<ISpecialityService, SpecialityService>();

#endregion

#endregion

#endregion

#region PatientModel

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IOutpatientCardService, OutpatientCardService>();

#region DescriptionModel

builder.Services.AddScoped<IResearchCategoryService, ResearchCategoryService>();
builder.Services.AddScoped<IResearchAreaService, ResearchAreaService>();
builder.Services.AddScoped<IRadiationDoseService, RadiationDoseService>();
builder.Services.AddScoped<IProcessDynamicsService, ProcessDymanicsService>();
builder.Services.AddScoped<IMethodService, MethodService>();
builder.Services.AddScoped<IDescriptionService, DescriptionService>();

#region IllnessModel

builder.Services.AddScoped<IIllnessService, IllnessService>();
builder.Services.AddScoped<IResultIllnessService, ResultIllnessService>();
builder.Services.AddScoped<ISignsOfResearchService, SignsOfResearchService>();

#endregion

#region DescriptionOfSignsModel

builder.Services.AddScoped<IDescriptionOfSignsService, DescriptionOfSignsService>();
builder.Services.AddScoped<IStatusOfTheAttributeService, StatusOfTheAttributeService>();

#endregion

#endregion

#endregion

builder.Services.AddScoped<ISysAdminService, SysAdminService>();
builder.Services.AddScoped<IHistoryNodeService, HistoryNodeService>();
builder.Services.AddScoped<IGenderService, GenderService>();

#endregion

#region Repository

#region Address

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IStreetRepository, StreetRepository>();

#endregion

#region MedicModel

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IMedicRepository, MedicRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IAccessRepository, AccessRepository>();

#region InstitutionModel

builder.Services.AddScoped<ICorpusRepository, CorpusRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IInstitutionRepository, InstitutionRepository>();

#endregion

#region PlaceOfStudyModel

builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();
builder.Services.AddScoped<IPlaceOfStudyRepository, PlaceOfStudyRepository>();

#region AdvancedTrainingCoursesModel

builder.Services.AddScoped<IAdvancedTrainingCoursesRepository, AdvancedTrainingCoursesRepository>();

#endregion

#region HightSchoolModel

builder.Services.AddScoped<IHightSchoolRepository, HightSchoolRepository>();

#endregion

#region IntershipModel

builder.Services.AddScoped<IIntershipRepository, IntershipRepository>();

#endregion

#region SpecialityModel

builder.Services.AddScoped<ISpecialityRepository, SpecialityRepository>();

#endregion

#endregion

#endregion

#region PatientModel

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IOutpatientCardRepository, OutpatientCardRepository>();

#region DescriptionModel

builder.Services.AddScoped<IResearchCategoryRepository, ResearchCategoryRepository>();
builder.Services.AddScoped<IResearchAreaRepository, ResearchAreaRepository>();
builder.Services.AddScoped<IRadiationDoseRepository, RadiationDoseRepository>();
builder.Services.AddScoped<IProcessDynamicsRepository, ProcessDynamicsRepository>();
builder.Services.AddScoped<IMethodRepository, MethodRepository>();
builder.Services.AddScoped<IDescriptionRepository, DescriptionRepository>();

#region IllnessModel

builder.Services.AddScoped<IIllnessRepository, IllnessRepository>();
builder.Services.AddScoped<IResultIllnessRepository, ResultIllnessRepository>();
builder.Services.AddScoped<ISignsOfResearchRepository, SignsOfResearchRepository>();

#endregion

#region DescriptionOfSignsModel

builder.Services.AddScoped<IDescriptionOfSignsRepository, DescriptionOfSignsRepository>();
builder.Services.AddScoped<IStatusOfTheAttributeRepository, StatusOfTheAttributeRepository>();

#endregion

#endregion

#endregion


builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IHistoryNodeRepository, HistoryNodeRepository>();
builder.Services.AddScoped<ISysAdminRepository, SysAdminRepository>();

#endregion

builder.Services.AddControllers();
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000", "http://localhost:5001", "http://localhost:5000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithMethods("PUT", "POST", "GET", "DELETE");
        }));
builder.Services.AddMvc();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "ValidIssuer",
                    ValidAudience = "ValidateAudience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("IssuerSigningSecretKey")),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };
            })
            .AddCookie(options =>
            {
                options.LoginPath = new PathString("/Authorization");
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Context>();
    if (context.Database.GetAppliedMigrations().Any())
        context.Database.Migrate();
    SeedData.Initialize(app.Services);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");

app.UseAuthentication();  
app.UseAuthorization();
app.UseCookiePolicy();

app.MapControllers();

SeedData.Initialize(app.Services);

app.Run();
