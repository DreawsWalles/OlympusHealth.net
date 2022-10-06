using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel.DescriptionModel.IllnessModel
{
    public class SignsOfResearchDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual IllnessDto Illness { get; set; }
        public virtual IEnumerable<ResultIllnessDto> ResultIllnesses { get; set; }
    }
}
