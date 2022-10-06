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
        public IEnumerable<GenderDto> GetAll();
        public GenderDto? GetById(Guid Id);

    }
}
