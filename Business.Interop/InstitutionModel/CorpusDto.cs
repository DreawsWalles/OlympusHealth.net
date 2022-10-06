using Business.Interop.Address;
using Business.Interop.ChiefOfMedicineModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.InstitutionModel
{
    public class CorpusDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual InstitutionDto Institution { get; set; }
        public virtual StreetDto Street { get; set; }
        public virtual IEnumerable<DeviceDto>? Devices { get; set; }
        public virtual IEnumerable<DepartmentDto>? Departments { get; set; }
    }
}
