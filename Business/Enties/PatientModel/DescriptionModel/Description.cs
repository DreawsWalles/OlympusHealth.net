using Business.Enties.MedicModel;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel
{
    [Table("Descriptions")]
    public class Description
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }
        public string? File { get; set; }
        public DateTime NeedTime { get; set; }

        [Required]
        [ForeignKey("ResearchAreaId")]
        public virtual ResearchArea ResearchArea { get; set; }

        [Required]
        [ForeignKey("HeadOfDepartmentId")]
        public virtual Medic HeadOfDepartment { get; set; }

        [Required]
        [ForeignKey("DoctorId")]
        public virtual Medic Doctor { get; set; }

        [Required]
        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }

        [Required]
        [ForeignKey("MethodId")]
        public virtual Method Method { get; set; }

        [ForeignKey("SubDescriptionId")]
        public virtual Description? SubDescription { get; set; }

        [Required]
        [ForeignKey("ResultIllnessId")]
        public virtual ResultIllness ResultIllness { get; set; }

        [Required]
        [ForeignKey("ProcessDynamicsId")]
        public virtual ProcessDynamics ProcessDynamics { get; set; }
        public virtual IEnumerable<StatusOfTheAttribute> StatusOfTheAttributes { get; set; }
    }
}
