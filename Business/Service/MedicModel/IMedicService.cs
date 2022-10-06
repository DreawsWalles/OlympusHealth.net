using Business.Enties.MedicModel;
using Business.Interop.Autefication;
using Business.Interop.ChiefOfMedicineModel;
using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.MedicineRegistratorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel
{
    public interface IMedicService
    {
        public Medic? IsRegistered(LoginModel model);
        public Medic? FindByLogin(string login);
        public IEnumerable<Medic> FindByFullName(string Name);
        public Medic FindById(Guid id);

        public Medic Create(Medic entity);
        public Medic Update(Medic entity);
        public void Remove(Medic entity);

        public ChiefOfMedicine Create(ChiefOfMedicine entity);
        public ChiefOfMedicine Update(ChiefOfMedicine entity);
        public void Remove(ChiefOfMedicine entity);

        public Doctor Create(Doctor entity);
        public Doctor Update(Doctor entity);
        public void Remove(Doctor entity);

        public HeadOfDepartment Create(HeadOfDepartment entity);
        public HeadOfDepartment Update(HeadOfDepartment entity);
        public void Remove(HeadOfDepartment entity);

        public MedicRegistrator Create(MedicRegistrator entity);
        public MedicRegistrator Update(MedicRegistrator entity);
        public void Remove(MedicRegistrator entity);
    }
}
