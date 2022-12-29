using Business.Interop.PlaceOfStudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.PlaceOfStudyModel
{
    public interface IIntershipService
    {
        public IntershipDto Create(IntershipDto entity);
        public IntershipDto Update(IntershipDto entity);
        public void Remove(IntershipDto entity);

        public ICollection<IntershipDto> GetAll();
        public IntershipDto GetById(Guid Id);

        public Task<IntershipDto> CreateAsync(IntershipDto entity);
        public Task<IntershipDto> UpdateAsync(IntershipDto entity);

        public Task<ICollection<IntershipDto>> GetAllAsync();
        public Task<IntershipDto> GetByIdAsync(Guid Id);
    }
}
