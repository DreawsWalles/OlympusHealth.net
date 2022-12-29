using Business.Interop.Autefication;
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

        public ICollection<PatientDto> GetAll();
        public PatientDto GetById(Guid id);
        public PatientDto? IsRegistered(LoginModel model);

        public Task<PatientDto> CreateAsync(PatientDto entity);
        public Task<PatientDto> UpdateAsync(PatientDto entity);

        public Task<ICollection<PatientDto>> GetAllAsync();
        public Task<PatientDto> GetByIdAsync(Guid id);
        public Task<PatientDto?> IsRegisteredAsync(LoginModel model);
    }
}
