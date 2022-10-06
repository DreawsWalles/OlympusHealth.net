using Business.Enties.Address;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.MedicModel.PlaceOfStudyModel
{
    [Table("Interships")]
    [Index("Name", IsUnique = true)]
    public class Intership
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("StreetId")]
        public virtual Street Street { get; set; }
        public virtual IEnumerable<PlaceOfStudy> PlaceOfStudies { get; set; }
    }
}
