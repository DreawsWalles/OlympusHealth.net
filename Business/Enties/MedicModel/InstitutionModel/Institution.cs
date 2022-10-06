using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.InstitutionModel
{
    [Table("Institutions")]
    [Index("Name", IsUnique = true)]
    public class Institution
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Avatar { get; set; }

        public virtual IEnumerable<Corpus> Corpuses { get; set; }
    }
}
