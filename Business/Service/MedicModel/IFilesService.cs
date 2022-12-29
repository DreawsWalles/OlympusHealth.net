using Business.Interop.ChiefOfMedicineModel;
using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.MedicineRegistratorModel;
using Business.Enties.MedicModel;

using FilesForChief = Business.Interop.ChiefOfMedicineModel.Files;
using FilesForDoctor = Business.Interop.DoctorModel.Files;
using FilesForHeadOfDepartment = Business.Interop.HeadOfDepartmentModel.Files;
using FilesForRegistrator = Business.Interop.MedicineRegistratorModel.Files;
using Files = Business.Enties.MedicModel.Files;
using File = Business.Interop.Files;

namespace Business.Service.MedicModel
{
    public interface IFilesService
    {
        public FilesForChief Create(ChiefOfMedicine chief, FilesForChief file);
        public FilesForChief Update(FilesForChief file);
        public void Remove(FilesForChief file);
        public ICollection<FilesForChief> GetAll(ChiefOfMedicine chief);

        public FilesForDoctor Create(Doctor doctor, FilesForDoctor file);
        public FilesForDoctor Update(FilesForDoctor file);
        public void Remove(FilesForDoctor file);
        public ICollection<FilesForDoctor> GelAll(Doctor doctor);

        public FilesForHeadOfDepartment Create(HeadOfDepartment headOfDepartment, FilesForHeadOfDepartment file);
        public FilesForHeadOfDepartment Update(FilesForHeadOfDepartment file);
        public void Remove(FilesForHeadOfDepartment file);
        public ICollection<FilesForHeadOfDepartment> GetAll(HeadOfDepartment headOfDepartment);

        public FilesForRegistrator Create(MedicRegistrator medicRegistrator, FilesForRegistrator file);
        public FilesForRegistrator Update(FilesForRegistrator file);
        public void Remove(FilesForRegistrator file);
        public ICollection<FilesForRegistrator> GetAll(MedicRegistrator medicRegistrator);

        public Files Create(Medic medic, Files file);
        public Files Update(Files file);
        public void Remove(Files file);
        public ICollection<Files> GetAll(Medic medic);
        public File? GetById(Guid id);

        public Task<FilesForChief> CreateAsync(ChiefOfMedicine chief, FilesForChief file);
        public Task<FilesForChief> UpdateAsync(FilesForChief file);
        public Task<ICollection<FilesForChief>> GetAllAsync(ChiefOfMedicine chief);

        public Task<FilesForDoctor> CreateAsync(Doctor doctor, FilesForDoctor file);
        public Task<FilesForDoctor> UpdateAsync(FilesForDoctor file);
        public Task<ICollection<FilesForDoctor>> GetAllAsync(Doctor doctor);

        public Task<FilesForHeadOfDepartment> CreateAsync(HeadOfDepartment headOfDepartment, FilesForHeadOfDepartment file);
        public Task<FilesForHeadOfDepartment> UpdateAsync(FilesForHeadOfDepartment file);
        public Task<ICollection<FilesForHeadOfDepartment>> GetAllAsync(HeadOfDepartment headOfDepartment);

        public Task<FilesForRegistrator> GetAllAsync(MedicRegistrator medicRegistrator, FilesForRegistrator file);
        public Task<FilesForRegistrator> UpdateAsync(FilesForRegistrator file);
        public Task<ICollection<FilesForRegistrator>> GetAllAsync(MedicRegistrator medicRegistrator);

        public Task<Files> CreateAsync(Medic medic, Files file);
        public Task<Files> UpdateAsync(Files file);
        public Task<ICollection<Files>> GetAllAsync(Medic medic);
        public Task<File?> GetByIdAsync(Guid id);
    }
}
