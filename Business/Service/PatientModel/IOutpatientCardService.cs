using Business.Interop.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel
{
    public interface IOutpatientCardService
    {
        public OutpatientCardDto Create(OutpatientCardDto entity);
        public OutpatientCardDto Update(OutpatientCardDto entity);
        public void Remove(OutpatientCardDto entity);

        public IEnumerable<OutpatientCardDto> GetAll();
        public OutpatientCardDto GetById(Guid id);
    }
}
