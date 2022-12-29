using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.InstitutionModel;
using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel.DescriptionModel
{
    public class DescriptionDto
    {
        public Guid Id { get; set; }
        public DateTime DateCreation { get; set; }
        public string? File { get; set; }
        public TimeOnly NeedTime { get; set; }

        public virtual ResearchAreaDto ResearchArea { get; set; }
        public virtual HeadOfDepartment HeadOfDepartment { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual DeviceDto Device { get; set; }
        public virtual MethodDto Method { get; set; }
        public virtual DescriptionDto? SubDescription { get; set; }
        public virtual ResultIllnessDto ResultIllness { get; set; }
        public virtual ProcessDynamicsDto ProcessDynamics { get; set; }
        public virtual ICollection<StatusOfTheAttributeDto> StatusOfTheAttributes { get; set; }
    }
}
