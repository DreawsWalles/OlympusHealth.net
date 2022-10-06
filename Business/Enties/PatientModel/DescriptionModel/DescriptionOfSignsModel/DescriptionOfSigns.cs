using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    [Table("DescriptionsOfSigns")]
    public class DescriptionOfSigns
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SerialNumber { get; set; }

        public IEnumerable<Method> Methods { get; set; }
        public IEnumerable<StatusOfTheAttribute> StatusOfTheAttributes { get; set; }
    }
}
