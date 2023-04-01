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
        public PatientDto Create(RegisterModelUser entity);
        public PatientDto Update(PatientDto entity);
        public void Remove(PatientDto entity);

        public ICollection<PatientDto> GetAll();
        public PatientDto GetById(Guid id);
        public PatientDto? IsRegistered(LoginModel model);
        public PatientDto? FindByLogin(string login);

        public Task<PatientDto> CreateAsync(RegisterModelUser entity);
        public Task<PatientDto> UpdateAsync(PatientDto entity);

        public Task<ICollection<PatientDto>> GetAllAsync();
        public Task<PatientDto> GetByIdAsync(Guid id);
        public Task<PatientDto?> IsRegisteredAsync(LoginModel model);
        public Task<PatientDto?> FindByLoginAsync(string login);
    }
}
