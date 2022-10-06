using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.Address
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }
        public virtual IEnumerable<Street> Streets { get; set; }

    }
}
