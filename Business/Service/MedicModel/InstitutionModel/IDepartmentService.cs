using Business.Interop.InstitutionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.InstitutionModel
{
    public interface IDepartmentService
    {
        public DepartmentDto Create(DepartmentDto department);
        public DepartmentDto Update(DepartmentDto department);
        public void Remove(DepartmentDto department);

        public ICollection<DepartmentDto> GetAll();
        public DepartmentDto GetById(Guid Id);


        public Task<DepartmentDto> CreateAsync(DepartmentDto department);
        public Task<DepartmentDto> UpdateAsync(DepartmentDto department);
        public Task<ICollection<DepartmentDto>> GetAllAsync();
        public Task<DepartmentDto> GetByIdAsync(Guid Id);
    }
}
