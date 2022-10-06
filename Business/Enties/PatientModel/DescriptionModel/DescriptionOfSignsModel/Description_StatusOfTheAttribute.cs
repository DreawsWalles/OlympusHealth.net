using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    [Table("Description_StatusOfTheAttribute")]
    [PrimaryKey("DescriptionId", "StatusOfTheAttributeId")]
    public class Description_StatusOfTheAttribute
    {
        [Column(Order = 1)]
        public Guid DescriptionId { get; set; }

        [Column(Order = 2)]
        public Guid StatusOfTheAttributeId { get; set; }

        [Required]
        [ForeignKey("DescriptionId")]
        public virtual Description Description { get; set; }

        [Required]
        [ForeignKey("StatusOfTheAttributeId")]
        public virtual StatusOfTheAttribute StatusOfTheAttribute { get; set; }
    }
}
