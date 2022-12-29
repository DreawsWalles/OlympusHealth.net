using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enties.Address
{
    public class Region
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public virtual Country Country { get; set; }
        public virtual ICollection<City> Citys { get; set; } = new List<City>();
    }
}
