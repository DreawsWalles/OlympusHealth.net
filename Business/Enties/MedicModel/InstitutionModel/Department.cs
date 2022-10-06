using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.InstitutionModel
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        [ForeignKey("CorpusId")]
        public virtual Corpus Corpus { get; set; }
        public virtual Medic? ChiefsOfDepartment { get; set; }

        [InverseProperty("Doctors")]
        public virtual IEnumerable<Medic>? Medics { get; set; }

        [InverseProperty("MedicRegistrator")]
        public virtual IEnumerable<Medic>? MedicRegistrators { get; set; }
    }
}
