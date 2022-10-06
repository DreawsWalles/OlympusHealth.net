using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public class DescriptionOfSigns
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SerialNumber { get; set; }

        public IEnumerable<Method> Methods { get; set; }
        public IEnumerable<StatusOfTheAttribute> StatusOfTheAttributes { get; set; }
    }
}
