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
    [Table("Methods")]
    public class Method
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string NameFieldMethod { get; set; }

        [Required]
        public string NameTitle { get; set; }
        public bool AddEnter { get; set; } = false;

        [Required]
        [ForeignKey("ResearchAreaId")]
        public virtual ResearchArea ResearchArea { get; set; }
        public virtual IEnumerable<Description> Descriptions { get; set; }
        public virtual IEnumerable<RadiationDose> RadiationDose { get; set; }

        [Required]
        [ForeignKey("ResearchCategoryId")]
        public virtual ResearchCategory ResearchCategory { get; set; }
        public virtual IEnumerable<Illness> Illnesses { get; set; }
        public virtual IEnumerable<DescriptionOfSigns> DescriptionOfSigns { get; set; }
    }
}
