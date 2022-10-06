using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public class StatusOfTheAttributeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual DescriptionOfSignsDto DescriptionOfSigns { get; set; }
        public virtual IEnumerable<DescriptionDto> Descriptions { get; set; }
    }
}
