using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel.DescriptionModel
{
    public class ResearchAreaDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual PatientDto Patient { get; set; }
        public virtual ICollection<DescriptionDto>? Descriptions { get; set; }
        public virtual ICollection<MethodDto> Methods { get; set; }
    }
}
