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

        public IEnumerable<DepartmentDto> GetAll();
        public DepartmentDto GetById(Guid Id);
    }
}
