using AutoMapper;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Interop.InstitutionModel;
using Business.Repository.DataRepository.MedicModel.InstitutionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.InstitutionModel
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository ??  throw new ArgumentNullException(nameof(departmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(DepartmentDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.Corpus == null)
                throw new ArgumentNullException(nameof(entity.Corpus));
            if (entity.HeadOfDepartment == null)
                throw new ArgumentNullException(nameof(entity.HeadOfDepartment));
        }

        public DepartmentDto Create(DepartmentDto entity)
        {
            CheckEntity(entity);
            Department department = _mapper.Map<Department>(entity);
            _departmentRepository.Create(department);
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> CreateAsync(DepartmentDto entity)
        {
            CheckEntity(entity);
            Department department = _mapper.Map<Department>(entity);
            await _departmentRepository.CreateAsync(department);
            return _mapper.Map<DepartmentDto>(department);
        }

        public ICollection<DepartmentDto> GetAll()
        {
            return _mapper.Map<List<Department>, ICollection<DepartmentDto>>(_departmentRepository.Query());
        }

        public async Task<ICollection<DepartmentDto>> GetAllAsync()
        {
            return _mapper.Map<List<Department>, ICollection<DepartmentDto>>(await _departmentRepository.QueryAsync());
        }

        public DepartmentDto GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            return _mapper.Map<DepartmentDto>(_departmentRepository.Query().FirstOrDefault(e => e.Id == Id)); 
        }

        public async Task<DepartmentDto> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            return _mapper.Map<DepartmentDto>((await _departmentRepository.QueryAsync()).FirstOrDefault(e => e.Id == Id));
        }

        public void Remove(DepartmentDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Department department = _mapper.Map<Department>(entity);
            _departmentRepository.Delete(department);
        }

        public DepartmentDto Update(DepartmentDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Department department = _mapper.Map<Department>(entity);
            _departmentRepository.Update(department);
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> UpdateAsync(DepartmentDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Department department = _mapper.Map<Department>(entity);
            await _departmentRepository.CreateAsync(department);
            return _mapper.Map<DepartmentDto>(department);
        }
    }
}
