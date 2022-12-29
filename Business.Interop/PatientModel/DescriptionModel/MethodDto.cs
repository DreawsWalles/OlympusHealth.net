using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel.DescriptionModel
{
    public class MethodDto
    {
        public Guid Id { get; set; }
        public string NameFieldMethod { get; set; }
        public string NameTitle { get; set; }
        public bool AddEnter { get; set; }

        public virtual ResearchAreaDto ResearchArea { get; set; }
        public virtual ICollection<DescriptionDto> Descriptions { get; set; }
        public virtual ICollection<RadiationDoseDto> RadiationDose { get; set; }
        public virtual ResearchCategoryDto ResearchCategory { get; set; }
        public virtual ICollection<IllnessDto> Illnesses { get; set; }
        public virtual ICollection<DescriptionOfSignsDto> DescriptionOfSigns { get; set; }
    }
}
