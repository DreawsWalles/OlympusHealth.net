using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.Address
{
    public class City
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public virtual Region Region { get; set; }
        public virtual ICollection<Street> Streets { get; set; } = new List<Street>();

    }
}
