using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public ICollection<Method> Methods { get; set; } = new List<Method>();
        public ICollection<StatusOfTheAttribute> StatusOfTheAttributes { get; set; } = new List<StatusOfTheAttribute>();
    }
}
