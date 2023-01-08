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
        public string? Name { get; set; }

        public virtual Guid RegionId { get; set; }
        public virtual ICollection<StreetDto> Streets { get; set; }
    }
}
