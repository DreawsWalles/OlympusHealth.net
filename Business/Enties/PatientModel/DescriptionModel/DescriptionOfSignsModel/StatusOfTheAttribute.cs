using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    [Table("StatusesOfTheAttribute")]
    public class StatusOfTheAttribute
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("DescriptionOfSignsId")]
        public virtual DescriptionOfSigns DescriptionOfSigns { get; set; }
        public virtual IEnumerable<Description> Descriptions { get; set; }
    }
}
