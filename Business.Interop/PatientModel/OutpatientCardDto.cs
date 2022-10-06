using Business.Interop.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel
{
    public class OutpatientCardDto
    {
        public Guid Id { get; set; }
        public string? File { get; set; }
        public string? Text { get; set; }
        public DateTime DateLastAdmission { get; set; }
        public DateTime? DateNextAdmission { get; set; }

        public virtual PatientDto Patient { get; set; }
        public virtual ResearchAreaDto? ResearchArea { get; set; }
    }
}
