using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Address
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual CountryDto Country { get; set; }
        public virtual IEnumerable<CityDto>? Citys { get; set; }
    }
}
