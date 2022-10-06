using Business.Interop.Address;
using Business.Interop.InstitutionModel;
using Business.Interop.PatientModel.DescriptionModel;
using Business.Interop.PlaceOfStudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.DoctorModel
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surnane { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public DateTime DateEmployment { get; set; }
        public DateTime? DateDismissal { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateBirthday { get; set; }

        public virtual GenderDto Gender { get; set; }
        public virtual StreetDto? Address { get; set; }
        public virtual IEnumerable<Files>? Files { get; set; }
        public virtual IEnumerable<PlaceOfStudyDto>? PlaceOfStudies { get; set; }
        public virtual DepartmentDto? Doctors { get; set; }
        public virtual IEnumerable<DescriptionDto>? Descriptions { get; set; }
    }
}
