using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionsOfSigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SerialNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionsOfSigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessDynamicses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessDynamicses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysAdmins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusesOfTheAttribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DescriptionOfSignsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusesOfTheAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusesOfTheAttribute_DescriptionsOfSigns_DescriptionOfSig~",
                        column: x => x.DescriptionOfSignsId,
                        principalTable: "DescriptionsOfSigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GenderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignsOfResearches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IllnessId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignsOfResearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignsOfResearches_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchAreas_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResultIllnesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SignsOfResearchId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultIllnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultIllnesses_SignsOfResearches_SignsOfResearchId",
                        column: x => x.SignsOfResearchId,
                        principalTable: "SignsOfResearches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NumberOfHouse = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streets_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameFieldMethod = table.Column<string>(type: "text", nullable: false),
                    NameTitle = table.Column<string>(type: "text", nullable: false),
                    AddEnter = table.Column<bool>(type: "boolean", nullable: false),
                    ResearchAreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResearchCategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Methods_ResearchAreas_ResearchAreaId",
                        column: x => x.ResearchAreaId,
                        principalTable: "ResearchAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Methods_ResearchCategories_ResearchCategoryId",
                        column: x => x.ResearchCategoryId,
                        principalTable: "ResearchCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutpatientCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    File = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    DateLastAdmission = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateNextAdmission = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResearchAreaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutpatientCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutpatientCards_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutpatientCards_ResearchAreas_ResearchAreaId",
                        column: x => x.ResearchAreaId,
                        principalTable: "ResearchAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvancedTrainingCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StreetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvancedTrainingCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvancedTrainingCourses_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Corpuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: false),
                    StreetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corpuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corpuses_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corpuses_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HightSchools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StreetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HightSchools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HightSchools_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StreetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interships_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StreetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialities_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionOfSignsMethod",
                columns: table => new
                {
                    DescriptionOfSignsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MethodsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionOfSignsMethod", x => new { x.DescriptionOfSignsId, x.MethodsId });
                    table.ForeignKey(
                        name: "FK_DescriptionOfSignsMethod_DescriptionsOfSigns_DescriptionOfS~",
                        column: x => x.DescriptionOfSignsId,
                        principalTable: "DescriptionsOfSigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionOfSignsMethod_Methods_MethodsId",
                        column: x => x.MethodsId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Illness_Methods",
                columns: table => new
                {
                    IllnessId = table.Column<Guid>(type: "uuid", nullable: false),
                    MethodId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illness_Methods", x => new { x.IllnessId, x.MethodId });
                    table.ForeignKey(
                        name: "FK_Illness_Methods_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Illness_Methods_Methods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IllnessMethod",
                columns: table => new
                {
                    IllnessesId = table.Column<Guid>(type: "uuid", nullable: false),
                    MethodsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IllnessMethod", x => new { x.IllnessesId, x.MethodsId });
                    table.ForeignKey(
                        name: "FK_IllnessMethod_Illnesses_IllnessesId",
                        column: x => x.IllnessesId,
                        principalTable: "Illnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IllnessMethod_Methods_MethodsId",
                        column: x => x.MethodsId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Method_DescriptionsOfSigns",
                columns: table => new
                {
                    MethodId = table.Column<Guid>(type: "uuid", nullable: false),
                    DescriptionOfSighsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Method_DescriptionsOfSigns", x => new { x.MethodId, x.DescriptionOfSighsId });
                    table.ForeignKey(
                        name: "FK_Method_DescriptionsOfSigns_DescriptionsOfSigns_DescriptionO~",
                        column: x => x.DescriptionOfSighsId,
                        principalTable: "DescriptionsOfSigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Method_DescriptionsOfSigns_Methods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RadiationDoses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Dose = table.Column<double>(type: "double precision", nullable: false),
                    MethodId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadiationDoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadiationDoses_Methods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CorpusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Corpuses_CorpusId",
                        column: x => x.CorpusId,
                        principalTable: "Corpuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Corpuses_Medics",
                columns: table => new
                {
                    CorpusId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corpuses_Medics", x => new { x.CorpusId, x.MedicId });
                    table.ForeignKey(
                        name: "FK_Corpuses_Medics_Corpuses_CorpusId",
                        column: x => x.CorpusId,
                        principalTable: "Corpuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CorpusId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChiefsOfDepartmentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Corpuses_CorpusId",
                        column: x => x.CorpusId,
                        principalTable: "Corpuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surnane = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    DateEmployment = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateDismissal = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    DateBirthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorsId = table.Column<Guid>(type: "uuid", nullable: true),
                    MedicRegistratorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medics_Departments_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medics_Departments_MedicRegistratorId",
                        column: x => x.MedicRegistratorId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medics_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medics_Roles_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medics_Streets_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    File = table.Column<string>(type: "text", nullable: true),
                    NeedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResearchAreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    HeadOfDepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uuid", nullable: false),
                    MethodId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDescriptionId = table.Column<Guid>(type: "uuid", nullable: true),
                    ResultIllnessId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcessDynamicsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptions_Descriptions_SubDescriptionId",
                        column: x => x.SubDescriptionId,
                        principalTable: "Descriptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Descriptions_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descriptions_Medics_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Medics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descriptions_Medics_HeadOfDepartmentId",
                        column: x => x.HeadOfDepartmentId,
                        principalTable: "Medics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descriptions_Methods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descriptions_ProcessDynamicses_ProcessDynamicsId",
                        column: x => x.ProcessDynamicsId,
                        principalTable: "ProcessDynamicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descriptions_ResearchAreas_ResearchAreaId",
                        column: x => x.ResearchAreaId,
                        principalTable: "ResearchAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descriptions_ResultIllnesses_ResultIllnessId",
                        column: x => x.ResultIllnessId,
                        principalTable: "ResultIllnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    MedicId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Medics_MedicId",
                        column: x => x.MedicId,
                        principalTable: "Medics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    File = table.Column<string>(type: "text", nullable: true),
                    SysAdminId = table.Column<Guid>(type: "uuid", nullable: true),
                    MedicId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryNodes_Medics_MedicId",
                        column: x => x.MedicId,
                        principalTable: "Medics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryNodes_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryNodes_SysAdmins_SysAdminId",
                        column: x => x.SysAdminId,
                        principalTable: "SysAdmins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaceOfStudies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartEducation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndEducation = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MedicId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecializationId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdvancedTrainingCoursesId = table.Column<Guid>(type: "uuid", nullable: true),
                    HightSchoolsId = table.Column<Guid>(type: "uuid", nullable: true),
                    IntershipsId = table.Column<Guid>(type: "uuid", nullable: true),
                    SpecialitiesId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOfStudies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceOfStudies_AdvancedTrainingCourses_AdvancedTrainingCour~",
                        column: x => x.AdvancedTrainingCoursesId,
                        principalTable: "AdvancedTrainingCourses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaceOfStudies_HightSchools_HightSchoolsId",
                        column: x => x.HightSchoolsId,
                        principalTable: "HightSchools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaceOfStudies_Interships_IntershipsId",
                        column: x => x.IntershipsId,
                        principalTable: "Interships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaceOfStudies_Medics_MedicId",
                        column: x => x.MedicId,
                        principalTable: "Medics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceOfStudies_Specialities_SpecialitiesId",
                        column: x => x.SpecialitiesId,
                        principalTable: "Specialities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaceOfStudies_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Description_StatusOfTheAttribute",
                columns: table => new
                {
                    DescriptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusOfTheAttributeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description_StatusOfTheAttribute", x => new { x.DescriptionId, x.StatusOfTheAttributeId });
                    table.ForeignKey(
                        name: "FK_Description_StatusOfTheAttribute_Descriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Description_StatusOfTheAttribute_StatusesOfTheAttribute_Sta~",
                        column: x => x.StatusOfTheAttributeId,
                        principalTable: "StatusesOfTheAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionStatusOfTheAttribute",
                columns: table => new
                {
                    DescriptionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusOfTheAttributesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionStatusOfTheAttribute", x => new { x.DescriptionsId, x.StatusOfTheAttributesId });
                    table.ForeignKey(
                        name: "FK_DescriptionStatusOfTheAttribute_Descriptions_DescriptionsId",
                        column: x => x.DescriptionsId,
                        principalTable: "Descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionStatusOfTheAttribute_StatusesOfTheAttribute_Stat~",
                        column: x => x.StatusOfTheAttributesId,
                        principalTable: "StatusesOfTheAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvancedTrainingCourses_Name",
                table: "AdvancedTrainingCourses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvancedTrainingCourses_StreetId",
                table: "AdvancedTrainingCourses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Corpuses_InstitutionId",
                table: "Corpuses",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Corpuses_StreetId",
                table: "Corpuses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Corpuses_Medics_MedicId",
                table: "Corpuses_Medics",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ChiefsOfDepartmentId",
                table: "Departments",
                column: "ChiefsOfDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CorpusId",
                table: "Departments",
                column: "CorpusId");

            migrationBuilder.CreateIndex(
                name: "IX_Description_StatusOfTheAttribute_StatusOfTheAttributeId",
                table: "Description_StatusOfTheAttribute",
                column: "StatusOfTheAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionOfSignsMethod_MethodsId",
                table: "DescriptionOfSignsMethod",
                column: "MethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_DeviceId",
                table: "Descriptions",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_DoctorId",
                table: "Descriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_HeadOfDepartmentId",
                table: "Descriptions",
                column: "HeadOfDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_MethodId",
                table: "Descriptions",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_ProcessDynamicsId",
                table: "Descriptions",
                column: "ProcessDynamicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_ResearchAreaId",
                table: "Descriptions",
                column: "ResearchAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_ResultIllnessId",
                table: "Descriptions",
                column: "ResultIllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_SubDescriptionId",
                table: "Descriptions",
                column: "SubDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionStatusOfTheAttribute_StatusOfTheAttributesId",
                table: "DescriptionStatusOfTheAttribute",
                column: "StatusOfTheAttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CorpusId",
                table: "Devices",
                column: "CorpusId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_MedicId",
                table: "Files",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Name",
                table: "Genders",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HightSchools_Name",
                table: "HightSchools",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HightSchools_StreetId",
                table: "HightSchools",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryNodes_MedicId",
                table: "HistoryNodes",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryNodes_PatientId",
                table: "HistoryNodes",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryNodes_SysAdminId",
                table: "HistoryNodes",
                column: "SysAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Illness_Methods_MethodId",
                table: "Illness_Methods",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Illnesses_Name",
                table: "Illnesses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IllnessMethod_MethodsId",
                table: "IllnessMethod",
                column: "MethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_Name",
                table: "Institutions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interships_Name",
                table: "Interships",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interships_StreetId",
                table: "Interships",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Medics_AddressId",
                table: "Medics",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Medics_DoctorsId",
                table: "Medics",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Medics_GenderId",
                table: "Medics",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Medics_Login_Email_PhoneNumber",
                table: "Medics",
                columns: new[] { "Login", "Email", "PhoneNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medics_MedicRegistratorId",
                table: "Medics",
                column: "MedicRegistratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Method_DescriptionsOfSigns_DescriptionOfSighsId",
                table: "Method_DescriptionsOfSigns",
                column: "DescriptionOfSighsId");

            migrationBuilder.CreateIndex(
                name: "IX_Methods_ResearchAreaId",
                table: "Methods",
                column: "ResearchAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Methods_ResearchCategoryId",
                table: "Methods",
                column: "ResearchCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OutpatientCards_PatientId",
                table: "OutpatientCards",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_OutpatientCards_ResearchAreaId",
                table: "OutpatientCards",
                column: "ResearchAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderId",
                table: "Patients",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Login_Email_PhoneNumber",
                table: "Patients",
                columns: new[] { "Login", "Email", "PhoneNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfStudies_AdvancedTrainingCoursesId",
                table: "PlaceOfStudies",
                column: "AdvancedTrainingCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfStudies_HightSchoolsId",
                table: "PlaceOfStudies",
                column: "HightSchoolsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfStudies_IntershipsId",
                table: "PlaceOfStudies",
                column: "IntershipsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfStudies_MedicId",
                table: "PlaceOfStudies",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfStudies_SpecialitiesId",
                table: "PlaceOfStudies",
                column: "SpecialitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfStudies_SpecializationId",
                table: "PlaceOfStudies",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDynamicses_Name",
                table: "ProcessDynamicses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RadiationDoses_MethodId",
                table: "RadiationDoses",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryId",
                table: "Regions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchAreas_Name",
                table: "ResearchAreas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchAreas_PatientId",
                table: "ResearchAreas",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchCategories_Name",
                table: "ResearchCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResultIllnesses_Name",
                table: "ResultIllnesses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResultIllnesses_SignsOfResearchId",
                table: "ResultIllnesses",
                column: "SignsOfResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SignsOfResearches_IllnessId",
                table: "SignsOfResearches",
                column: "IllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_Name",
                table: "Specialities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_StreetId",
                table: "Specialities",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Name",
                table: "Specializations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusesOfTheAttribute_DescriptionOfSignsId",
                table: "StatusesOfTheAttribute",
                column: "DescriptionOfSignsId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_CityId",
                table: "Streets",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SysAdmins_Login",
                table: "SysAdmins",
                column: "Login",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Corpuses_Medics_Medics_MedicId",
                table: "Corpuses_Medics",
                column: "MedicId",
                principalTable: "Medics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Medics_ChiefsOfDepartmentId",
                table: "Departments",
                column: "ChiefsOfDepartmentId",
                principalTable: "Medics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corpuses_Streets_StreetId",
                table: "Corpuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Medics_Streets_AddressId",
                table: "Medics");

            migrationBuilder.DropForeignKey(
                name: "FK_Corpuses_Institutions_InstitutionId",
                table: "Corpuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Corpuses_CorpusId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Medics_ChiefsOfDepartmentId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Corpuses_Medics");

            migrationBuilder.DropTable(
                name: "Description_StatusOfTheAttribute");

            migrationBuilder.DropTable(
                name: "DescriptionOfSignsMethod");

            migrationBuilder.DropTable(
                name: "DescriptionStatusOfTheAttribute");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "HistoryNodes");

            migrationBuilder.DropTable(
                name: "Illness_Methods");

            migrationBuilder.DropTable(
                name: "IllnessMethod");

            migrationBuilder.DropTable(
                name: "Method_DescriptionsOfSigns");

            migrationBuilder.DropTable(
                name: "OutpatientCards");

            migrationBuilder.DropTable(
                name: "PlaceOfStudies");

            migrationBuilder.DropTable(
                name: "RadiationDoses");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "StatusesOfTheAttribute");

            migrationBuilder.DropTable(
                name: "SysAdmins");

            migrationBuilder.DropTable(
                name: "AdvancedTrainingCourses");

            migrationBuilder.DropTable(
                name: "HightSchools");

            migrationBuilder.DropTable(
                name: "Interships");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Methods");

            migrationBuilder.DropTable(
                name: "ProcessDynamicses");

            migrationBuilder.DropTable(
                name: "ResultIllnesses");

            migrationBuilder.DropTable(
                name: "DescriptionsOfSigns");

            migrationBuilder.DropTable(
                name: "ResearchAreas");

            migrationBuilder.DropTable(
                name: "ResearchCategories");

            migrationBuilder.DropTable(
                name: "SignsOfResearches");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "Corpuses");

            migrationBuilder.DropTable(
                name: "Medics");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
