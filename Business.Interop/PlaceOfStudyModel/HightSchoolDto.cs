using Business.Interop.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.PlaceOfStudyModel
{
    public class HightSchoolDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual StreetDto Street { get; set; }
    }
}
