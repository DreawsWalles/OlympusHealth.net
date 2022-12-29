using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.MedicineRegistratorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.InstitutionModel
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual CorpusDto Corpus { get; set; }
        public virtual HeadOfDepartment HeadOfDepartment { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; }
        public virtual ICollection<MedicRegistrator>? MedicRegistrators { get; set; }
    }
}
