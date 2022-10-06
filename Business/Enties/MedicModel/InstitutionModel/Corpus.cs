using Business.Enties.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.InstitutionModel
{
    [Table("Corpuses")]
    public class Corpus
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("InstitutionId")]
        public virtual Institution Institution { get; set; }

        [Required]
        [ForeignKey("StreetId")]
        public virtual Street Street { get; set; }
        public virtual IEnumerable<Device>? Devices { get; set; }
        public virtual IEnumerable<Department>? Departments { get; set; }
        public virtual IEnumerable<Corpus_Medic> Corpus_Medics { get; set; }

        [NotMapped]
        public virtual IEnumerable<Medic> Medics { get; set; }
    }
}
