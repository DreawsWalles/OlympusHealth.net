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
        public IEnumerable<FilesForChief> GetAll(ChiefOfMedicine chief);

        public FilesForDoctor Create(Doctor doctor, FilesForDoctor file);
        public FilesForDoctor Update(FilesForDoctor file);
        public void Remove(FilesForDoctor file);
        public IEnumerable<FilesForDoctor> GelAll(Doctor doctor);

        public FilesForHeadOfDepartment Create(HeadOfDepartment headOfDepartment, FilesForHeadOfDepartment file);
        public FilesForHeadOfDepartment Update(FilesForHeadOfDepartment file);
        public void Remove(FilesForHeadOfDepartment file);
        public IEnumerable<FilesForHeadOfDepartment> GetAll(HeadOfDepartment headOfDepartment);

        public FilesForRegistrator Create(MedicRegistrator medicRegistrator, FilesForRegistrator file);
        public FilesForRegistrator Update(FilesForRegistrator file);
        public void Remove(FilesForRegistrator file);
        public IEnumerable<FilesForRegistrator> GetAll(MedicRegistrator medicRegistrator);

        public Files Create(Medic medic, Files file);
        public Files Update(Files file);
        public void Remove(Files file);
        public IEnumerable<Files> GetAll(Medic medic);
        public File? GetById(Guid id);
    }
}
