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
        public ICollection<Medic> FindByFullName(string Name);
        public ICollection<Medic> GetAll();
        public Medic? FindById(Guid id);
        public void Accept(Guid id);

        public Medic Create(RegisterModelUser entity);
        public Medic Update(Medic entity);
        public void Remove(Medic entity);

        public ChiefOfMedicine Update(ChiefOfMedicine entity);
        public void Remove(ChiefOfMedicine entity);

        public Doctor Update(Doctor entity);
        public void Remove(Doctor entity);

        public HeadOfDepartment Update(HeadOfDepartment entity);
        public void Remove(HeadOfDepartment entity);

        public MedicRegistrator Update(MedicRegistrator entity);
        public void Remove(MedicRegistrator entity);


        public Task<Medic?> IsRegisteredAsync(LoginModel model);
        public Task<Medic?> FindByLoginAsync(string login);
        public Task<ICollection<Medic>> FindByFullNameAsync(string Name);

        public Task<Medic> CreateAsync(RegisterModelUser entity);
        public Task<Medic> UpdateAsync(Medic entity);

        public Task<ChiefOfMedicine> UpdateAsync(ChiefOfMedicine entity);

        public Task<Doctor> UpdateAsync(Doctor entity);

        public Task<HeadOfDepartment> UpdateAsync(HeadOfDepartment entity);

        public Task<MedicRegistrator> UpdateAsync(MedicRegistrator entity);

        public Task<ICollection<Medic>> GetAllAsync();
        public Task<Medic?> FindByIdAsync(Guid id);
        public Task AcceptAsync(Guid id);
    }
}
