using Business.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IGenderService
    {
        public GenderDto Create(GenderDto entity);
        public GenderDto Update(GenderDto updateEntity);
        public void Remove(GenderDto entity);
        public ICollection<GenderDto> GetAll();
        public GenderDto? GetById(Guid Id);

        public Task<GenderDto> CreateAsync(GenderDto entity);
        public Task<GenderDto> UpdateAsync(GenderDto updateEntity);
        public Task<ICollection<GenderDto>> GetAllAsync();
        public Task<GenderDto?> GetByIdAsync(Guid Id);

    }
}
