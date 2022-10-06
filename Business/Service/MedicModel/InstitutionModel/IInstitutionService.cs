using Business.Interop.InstitutionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.InstitutionModel
{
    public interface IInstitutionService
    {
        public InstitutionDto Create(InstitutionDto entity);
        public InstitutionDto Update(InstitutionDto entity);
        public void Remove(InstitutionDto entity);

        public IEnumerable<InstitutionDto> GetAll();
        public InstitutionDto GetById(Guid Id);
    }
}
