using Business.Interop.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel
{
    public interface IPatientService
    {
        public PatientDto Create(PatientDto entity);
        public PatientDto Update(PatientDto entity);
        public void Remove(PatientDto entity);

        public IEnumerable<PatientDto> GetAll();
        public PatientDto GetById(Guid id);
    }
}
