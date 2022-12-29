using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public class DescriptionOfSignsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SerialNumber { get; set; }

        public ICollection<MethodDto> Methods { get; set; }
        public ICollection<StatusOfTheAttributeDto> StatusOfTheAttributes { get; set; }
    }
}
