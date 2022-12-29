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
            _fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(Enties.MedicModel.Files entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Content == null || entity.Content == "")
                throw new ArgumentNullException(nameof(entity));
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
            CheckEntity(file);
            file.Medic = medic ?? throw new ArgumentNullException(nameof(medic));
            _fileRepository.Create(file);
            return file;
        }

        public async Task<Interop.ChiefOfMedicineModel.Files> CreateAsync(ChiefOfMedicine chief, Interop.ChiefOfMedicineModel.Files file)
        {
            return _mapper.Map<Interop.ChiefOfMedicineModel.Files>(await CreateAsync(_mapper.Map<Medic>(chief), _mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public async Task<Interop.DoctorModel.Files> CreateAsync(Doctor doctor, Interop.DoctorModel.Files file)
        {
            return _mapper.Map<Interop.DoctorModel.Files>(await CreateAsync(_mapper.Map<Medic>(doctor), _mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public async Task<Interop.HeadOfDepartmentModel.Files> CreateAsync(HeadOfDepartment headOfDepartment, Interop.HeadOfDepartmentModel.Files file)
        {
            return _mapper.Map<Interop.HeadOfDepartmentModel.Files>(await CreateAsync(_mapper.Map<Medic>(headOfDepartment), _mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public async Task<Enties.MedicModel.Files> CreateAsync(Medic medic, Enties.MedicModel.Files file)
        {
            CheckEntity(file);
            file.Medic = medic ?? throw new ArgumentNullException(nameof(medic));
            await _fileRepository.CreateAsync(file);
            return file;
        }
        #endregion

        #region GetAll
        public ICollection<Interop.DoctorModel.Files> GelAll(Doctor doctor)
        {
            return _mapper.Map<ICollection<Enties.MedicModel.Files>, ICollection<Interop.DoctorModel.Files>>(GetAll(_mapper.Map<Medic>(doctor)));
        }

        public ICollection<Interop.ChiefOfMedicineModel.Files> GetAll(ChiefOfMedicine chief)
        {
            return _mapper.Map<ICollection<Enties.MedicModel.Files>, ICollection<Interop.ChiefOfMedicineModel.Files>>(GetAll(_mapper.Map<Medic>(chief)));
        }

        public ICollection<Interop.HeadOfDepartmentModel.Files> GetAll(HeadOfDepartment headOfDepartment)
        {
            return _mapper.Map<ICollection<Enties.MedicModel.Files>, ICollection<Interop.HeadOfDepartmentModel.Files>>(GetAll(_mapper.Map<Medic>(headOfDepartment)));
        }

        public ICollection<Interop.MedicineRegistratorModel.Files> GetAll(MedicRegistrator medicRegistrator)
        {
            return _mapper.Map<ICollection<Enties.MedicModel.Files>, ICollection<Interop.MedicineRegistratorModel.Files>>(GetAll(_mapper.Map<Medic>(medicRegistrator)));
        }

        public ICollection<Enties.MedicModel.Files> GetAll(Medic medic)
        {
            return _fileRepository.Query().Where(e => e.Medic.Id == medic.Id).ToList();
        }

        public Task<ICollection<Interop.ChiefOfMedicineModel.Files>> GetAllAsync(ChiefOfMedicine chief)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Interop.DoctorModel.Files>> GetAllAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Interop.HeadOfDepartmentModel.Files>> GetAllAsync(HeadOfDepartment headOfDepartment)
        {
            throw new NotImplementedException();
        }

        public Task<Interop.MedicineRegistratorModel.Files> GetAllAsync(MedicRegistrator medicRegistrator, Interop.MedicineRegistratorModel.Files file)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Interop.MedicineRegistratorModel.Files>> GetAllAsync(MedicRegistrator medicRegistrator)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Enties.MedicModel.Files>> GetAllAsync(Medic medic)
        {
            throw new NotImplementedException();
        }
        #endregion

        public Interop.Files? GetById(Guid id)
        {
            return _mapper.Map< Interop.Files>(_fileRepository.Query().FirstOrDefault(e => e.Id == id));
        }

        public async Task<Interop.Files?> GetByIdAsync(Guid id)
        {
            var list = await _fileRepository.QueryAsync();
            return _mapper.Map<Interop.Files>(list.FirstOrDefault(e => e.Id == id));
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
            CheckEntity(file);
            if(file.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(file.Id));
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
            CheckEntity(file);
            if (file.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(file.Id));
            _fileRepository.Update(file);
            return file;
        }

        public async Task<Interop.ChiefOfMedicineModel.Files> UpdateAsync(Interop.ChiefOfMedicineModel.Files file)
        {
            return _mapper.Map<Interop.ChiefOfMedicineModel.Files>(await UpdateAsync(_mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public async Task<Interop.DoctorModel.Files> UpdateAsync(Interop.DoctorModel.Files file)
        {
            return _mapper.Map<Interop.DoctorModel.Files>(await UpdateAsync(_mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public async Task<Interop.HeadOfDepartmentModel.Files> UpdateAsync(Interop.HeadOfDepartmentModel.Files file)
        {
            return _mapper.Map<Interop.HeadOfDepartmentModel.Files>(await UpdateAsync(_mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public async Task<Interop.MedicineRegistratorModel.Files> UpdateAsync(Interop.MedicineRegistratorModel.Files file)
        {
            return _mapper.Map<Interop.MedicineRegistratorModel.Files>(await UpdateAsync(_mapper.Map<Enties.MedicModel.Files>(file)));
        }

        public async Task<Enties.MedicModel.Files> UpdateAsync(Enties.MedicModel.Files file)
        {
            CheckEntity(file);
            if (file.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(file.Id));
            await _fileRepository.CreateOrUpdateAsync(file);
            return file;
        }
        #endregion
    }
}
