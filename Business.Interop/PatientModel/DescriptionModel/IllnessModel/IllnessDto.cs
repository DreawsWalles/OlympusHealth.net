using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel.DescriptionModel.IllnessModel
{
    public class IllnessDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MethodDto> Methods { get; set; }
        public virtual ICollection<SignsOfResearchDto> SignsOfResearches { get; set; }
    }
}
