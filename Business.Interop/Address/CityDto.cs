using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Address
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual RegionDto Region { get; set; }
        public virtual IEnumerable<StreetDto> Streets { get; set; }
    }
}
