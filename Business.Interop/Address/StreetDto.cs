using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Address
{
    public class StreetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string? NumberOfHouse { get; set; }

        public virtual Guid CityId { get; set; }
    }
}
