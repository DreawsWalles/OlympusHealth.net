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
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public DepartmentDto Create(DepartmentDto entity)
        {
            Department department = _mapper.Map<Department>(entity);
            _departmentRepository.Create(department);
            return _mapper.Map<DepartmentDto>(department);
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            return _mapper.Map<List<Department>, IEnumerable<DepartmentDto>>(_departmentRepository.Query());
        }

        public DepartmentDto GetById(Guid Id)
        {
            return _mapper.Map<DepartmentDto>(_departmentRepository.Query().FirstOrDefault(e => e.Id == Id)); //написать запрос
        }

        public void Remove(DepartmentDto entity)
        {
            Department department = _mapper.Map<Department>(entity);
            _departmentRepository.Delete(department);
        }

        public DepartmentDto Update(DepartmentDto entity)
        {
            Department department = _mapper.Map<Department>(entity);
            _departmentRepository.Update(department);
            return _mapper.Map<DepartmentDto>(department);
        }
    }
}
