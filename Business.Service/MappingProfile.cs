using AutoMapper;
using Business.Enties;
using Business.Enties.Address;
using Business.Enties.MedicModel;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Enties.MedicModel.PlaceOfStudyModel;

using Business.Enties.PatientModel;
using Business.Enties.PatientModel.DescriptionModel;
using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using Business.Interop;
using Business.Interop.Address;
using Business.Interop.ChiefOfMedicineModel;
using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.InstitutionModel;
using Business.Interop.PatientModel;
using Business.Interop.PatientModel.DescriptionModel;
using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using Business.Interop.PlaceOfStudyModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Gender, GenderDto>();
            CreateMap<GenderDto, Gender>();

            #region Address
            CreateMap<Street, StreetDto>();
            CreateMap<StreetDto, Street>();

            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>();

            CreateMap<Region, RegionDto>();
            CreateMap<RegionDto, Region>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            #endregion

            #region Medic

            CreateMap<Medic, ChiefOfMedicine>();
            CreateMap<ChiefOfMedicine, Medic>();

            CreateMap<Medic, Doctor>();
            CreateMap<Doctor, Medic>();

            CreateMap<Medic, HeadOfDepartment>();
            CreateMap<HeadOfDepartment, Medic>();

            CreateMap<Access, AccessDto>();
            CreateMap<AccessDto, Access>();

            #region PlaceOfStudy
            CreateMap<Specialization, SpecializationDto>();
            CreateMap<SpecializationDto, Specialization>();

            #region Specialization
            CreateMap<Speciality, SpecialityDto>();
            CreateMap<SpecialityDto, Speciality>();

            #endregion

            #region Intership
            CreateMap<Intership, IntershipDto>();
            CreateMap<IntershipDto, Intership>();

            #endregion

            #region HightSchool
            CreateMap<HightSchool, HightSchoolDto>();
            CreateMap<HightSchoolDto, HightSchool>();

            #endregion

            #region AdbancedTrainingCourses
            CreateMap<AdvancedTrainingCourses, AdvancedTrainingCoursesDto>();
            CreateMap<AdvancedTrainingCoursesDto, AdvancedTrainingCourses>();

            #endregion

            CreateMap<PlaceOfStudy, PlaceOfStudyDto>()
                .ForMember(dest => dest.Medic, opt => opt.MapFrom(src => src.Medic))
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Medic))
                .ForMember(dest => dest.HeadOfDepartment, opt => opt.MapFrom(src => src.Medic))
                .ForMember(dest => dest.MedicRegistrator, opt => opt.MapFrom(src => src.Medic));
            CreateMap<PlaceOfStudyDto, PlaceOfStudy>()
                .ForMember(dest => dest.Medic, opt => opt.MapFrom(src => src.Medic))
                .ForMember(dest => dest.Medic, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dest => dest.Medic, opt => opt.MapFrom(src => src.HeadOfDepartment))
                .ForMember(dest => dest.Medic, opt => opt.MapFrom(src => src.MedicRegistrator));
            #endregion

            #region Institution

            CreateMap<Institution, InstitutionDto>();
            CreateMap<InstitutionDto, Institution>();

            CreateMap<Corpus, CorpusDto>();
            CreateMap<CorpusDto, Corpus>();

            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceDto, Device>();

            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.MedicRegistrators, opt => opt.MapFrom(src => src.MedicRegistrators))
                .ForMember(dest => dest.Doctors, opt => opt.MapFrom(src => src.Medics))
                .ForMember(dest => dest.HeadOfDepartment, opt => opt.MapFrom(src => src.ChiefsOfDepartment));
            #endregion

            #region Files
            CreateMap<Interop.ChiefOfMedicineModel.Files, Enties.MedicModel.Files>();
            CreateMap<Enties.MedicModel.Files, Interop.ChiefOfMedicineModel.Files>();

            CreateMap<Enties.MedicModel.Files, Interop.HeadOfDepartmentModel.Files>();
            CreateMap<Interop.HeadOfDepartmentModel.Files, Enties.MedicModel.Files>();

            CreateMap<Enties.MedicModel.Files, Interop.DoctorModel.Files>();
            CreateMap<Interop.DoctorModel.Files, Enties.MedicModel.Files>();

            CreateMap<Interop.MedicineRegistratorModel.Files, Enties.MedicModel.Files>();
            CreateMap<Enties.MedicModel.Files, Interop.MedicineRegistratorModel.Files>();
            #endregion
            #endregion

            #region Patient
            CreateMap<OutpatientCard, OutpatientCardDto>();
            CreateMap<OutpatientCardDto, OutpatientCard>();

            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();

            #region Descroption
            CreateMap<ResearchCategory, ResearchCategoryDto>();
            CreateMap<ResearchCategoryDto, ResearchCategory>();

            CreateMap<ResearchArea,ResearchAreaDto>();
            CreateMap<ResearchAreaDto, ResearchArea>();

            CreateMap<RadiationDose, RadiationDoseDto>();
            CreateMap<RadiationDoseDto, RadiationDose>();

            CreateMap<ProcessDynamics, ProcessDynamicsDto>();
            CreateMap<ProcessDynamicsDto, ProcessDynamics>();

            CreateMap<Method, MethodDto>();
            CreateMap<MethodDto, Method>();

            #region Illness
            CreateMap<SignsOfResearch, SignsOfResearchDto>();
            CreateMap<SignsOfResearchDto, SignsOfResearch>();

            CreateMap<ResultIllness, ResultIllnessDto>();
            CreateMap<ResultIllnessDto, ResultIllness>();

            CreateMap<Illness, IllnessDto>();
            CreateMap<IllnessDto, Illness>();

            #endregion

            #region DescriptionOfSigns
            CreateMap<StatusOfTheAttribute, StatusOfTheAttributeDto>();
            CreateMap<StatusOfTheAttributeDto, StatusOfTheAttribute>();



            CreateMap<DescriptionOfSigns, DescriptionOfSignsDto>();
            CreateMap<DescriptionOfSignsDto, DescriptionOfSigns>();

            #endregion

            CreateMap<Description, DescriptionDto>()
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dest => dest.HeadOfDepartment, opt => opt.MapFrom(src => src.HeadOfDepartment))
                .ForMember(dest => dest.SubDescription, opt => opt.MapFrom(src => src.SubDescription));
            #endregion
            #endregion
        }
    }
}
