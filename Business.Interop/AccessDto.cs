using Business.Interop.ChiefOfMedicineModel;
using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.MedicineRegistratorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop
{
    public class AccessDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<ChiefOfMedicine>? ChiefOfMedicines { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<HeadOfDepartment> HeadOfDepartments { get; set; }
        public ICollection<MedicRegistrator> MedicRegistrators { get; set; }
    }
}
