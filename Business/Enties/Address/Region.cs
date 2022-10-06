using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.Address
{
    [Table("Regions")]
    public class Region
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public virtual IEnumerable<City>? Citys { get; set; }
    }
}
