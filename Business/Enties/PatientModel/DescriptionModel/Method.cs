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
    public class Method
    {
        public Guid Id { get; set; }

        public string NameFieldMethod { get; set; }

        public string NameTitle { get; set; }
        public bool AddEnter { get; set; } = false;


        public virtual ResearchArea ResearchArea { get; set; }
        public virtual ICollection<Description> Descriptions { get; set; } = new List<Description>();
        public virtual ICollection<RadiationDose> RadiationDose { get; set; } = new List<RadiationDose>();


        public virtual ResearchCategory ResearchCategory { get; set; }
        public virtual ICollection<Illness> Illnesses { get; set; } = new List<Illness>();
        public virtual ICollection<DescriptionOfSigns> DescriptionOfSigns { get; set; } = new List<DescriptionOfSigns>();
    }
}
