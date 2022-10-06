using AutoMapper;
using Business.Enties.MedicModel;
using Business.Interop.ChiefOfMedicineModel;
using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.MedicineRegistratorModel;
using Business.Repository.DataRepository.MedicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel
{
    public class FilesService : IFilesService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public FilesService(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }
        #region Create
        public Interop.ChiefOfMedicineModel.Files Create(ChiefOfMedicine chief, Interop.ChiefOfMedicineModel.Files file)
        {
            return _mapper.Map<Interop.ChiefOfMedicineModel.Files>(Create(_mapper.Map<Medic>(chief), _mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public Interop.DoctorModel.Files Create(Doctor doctor, Interop.DoctorModel.Files file)
        {
            return _mapper.Map<Interop.DoctorModel.Files>(Create(_mapper.Map<Medic>(doctor), _mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public Interop.HeadOfDepartmentModel.Files Create(HeadOfDepartment headOfDepartment, Interop.HeadOfDepartmentModel.Files file)
        {
            return _mapper.Map<Interop.HeadOfDepartmentModel.Files>(Create(_mapper.Map<Medic>(headOfDepartment), _mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public Interop.MedicineRegistratorModel.Files Create(MedicRegistrator medicRegistrator, Interop.MedicineRegistratorModel.Files file)
        {
            return _mapper.Map<Interop.MedicineRegistratorModel.Files>(Create(_mapper.Map<Medic>(medicRegistrator), _mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public Enties.MedicModel.Files Create(Medic medic, Enties.MedicModel.Files file)
        {
            file.Medic = medic;
            _fileRepository.Create(file);
            return file;
        }
        #endregion

        #region GetAll
        public IEnumerable<Interop.DoctorModel.Files> GelAll(Doctor doctor)
        {
            return _mapper.Map<IEnumerable<Enties.MedicModel.Files>, IEnumerable<Interop.DoctorModel.Files>>(GetAll(_mapper.Map<Medic>(doctor)));
        }

        public IEnumerable<Interop.ChiefOfMedicineModel.Files> GetAll(ChiefOfMedicine chief)
        {
            return _mapper.Map<IEnumerable<Enties.MedicModel.Files>, IEnumerable<Interop.ChiefOfMedicineModel.Files>>(GetAll(_mapper.Map<Medic>(chief)));
        }

        public IEnumerable<Interop.HeadOfDepartmentModel.Files> GetAll(HeadOfDepartment headOfDepartment)
        {
            return _mapper.Map<IEnumerable<Enties.MedicModel.Files>, IEnumerable<Interop.HeadOfDepartmentModel.Files>>(GetAll(_mapper.Map<Medic>(headOfDepartment)));
        }

        public IEnumerable<Interop.MedicineRegistratorModel.Files> GetAll(MedicRegistrator medicRegistrator)
        {
            return _mapper.Map<IEnumerable<Enties.MedicModel.Files>, IEnumerable<Interop.MedicineRegistratorModel.Files>>(GetAll(_mapper.Map<Medic>(medicRegistrator)));
        }

        public IEnumerable<Enties.MedicModel.Files> GetAll(Medic medic)
        {
            return _fileRepository.Query().Where(e => e.Medic.Id == medic.Id);
        }
        #endregion

        public Interop.Files? GetById(Guid id)
        {
            return _mapper.Map< Interop.Files>(_fileRepository.Query().FirstOrDefault(e => e.Id == id));
        }

        #region Remove
        public void Remove(Interop.ChiefOfMedicineModel.Files file)
        {
            Remove(_mapper.Map<Enties.MedicModel.Files>(file));
        }

        public void Remove(Interop.DoctorModel.Files file)
        {
            Remove(_mapper.Map<Enties.MedicModel.Files>(file));
        }

        public void Remove(Interop.HeadOfDepartmentModel.Files file)
        {
            Remove(_mapper.Map<Enties.MedicModel.Files>(file));
        }

        public void Remove(Interop.MedicineRegistratorModel.Files file)
        {
            Remove(_mapper.Map<Enties.MedicModel.Files>(file));
        }

        public void Remove(Enties.MedicModel.Files file)
        {
            _fileRepository.Delete(file);
        }
        #endregion

        #region Update
        public Interop.ChiefOfMedicineModel.Files Update(Interop.ChiefOfMedicineModel.Files file)
        {
            return _mapper.Map<Interop.ChiefOfMedicineModel.Files>(Update(_mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public Interop.DoctorModel.Files Update(Interop.DoctorModel.Files file)
        {
            return _mapper.Map<Interop.DoctorModel.Files>(Update(_mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public Interop.HeadOfDepartmentModel.Files Update(Interop.HeadOfDepartmentModel.Files file)
        {
            return _mapper.Map<Interop.HeadOfDepartmentModel.Files>(Update(_mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public Interop.MedicineRegistratorModel.Files Update(Interop.MedicineRegistratorModel.Files file)
        {
            return _mapper.Map<Interop.MedicineRegistratorModel.Files>(Update(_mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public Enties.MedicModel.Files Update(Enties.MedicModel.Files file)
        {
            _fileRepository.Update(file);
            return file;
        }
        #endregion
    }
}
