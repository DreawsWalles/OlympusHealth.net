using Business.Enties.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.InstitutionModel
{
    [Table("Devices")]
    public class Device
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("CorpusId")]
        public virtual Corpus Corpus { get; set; }
        public virtual IEnumerable<Description> Descriptions { get; set; }
    }
}
