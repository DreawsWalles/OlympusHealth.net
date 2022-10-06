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

        public IEnumerable<IntershipDto> GetAll();
        public IntershipDto GetById(Guid Id);
    }
}
