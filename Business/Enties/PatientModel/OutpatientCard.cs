using Business.Enties.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel
{
    public class OutpatientCard
    {
        public Guid Id { get; set; }
        public string? File { get; set; }
        public string? Text { get; set; }

        public DateTime DateLastAdmission { get; set; }
        public DateTime? DateNextAdmission { get; set; }


        public virtual Patient Patient { get; set; }

        public virtual ResearchArea ResearchArea { get; set; }
    }
}
