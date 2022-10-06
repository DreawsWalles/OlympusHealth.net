using Business.Enties.MedicModel;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel
{
    public class Description
    {
        public Guid Id { get; set; }
        public DateTime DateCreation { get; set; }
        public string? File { get; set; }
        public TimeOnly NeedTime { get; set; }

        public virtual ResearchArea ResearchArea { get; set; }
        public virtual Medic HeadOfDepartment { get; set; }
        public virtual Medic Doctor { get; set; }
        public virtual Device Device { get; set; }
        public virtual Method Method { get; set; }
        public virtual Description? SubDescription { get; set; }
        public virtual ResultIllness ResultIllness { get; set; }
        public virtual ProcessDynamics ProcessDynamics { get; set; }
        public virtual IEnumerable<StatusOfTheAttribute> StatusOfTheAttributes { get; set; }
    }
}
