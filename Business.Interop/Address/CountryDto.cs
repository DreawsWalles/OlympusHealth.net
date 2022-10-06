using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Address
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<RegionDto>? Regions { get; set; }
    }
}
