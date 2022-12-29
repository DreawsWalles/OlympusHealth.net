using Business.Interop.InstitutionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.InstitutionModel
{
    public interface ICorpusService
    {
        public CorpusDto Create(CorpusDto entity);
        public CorpusDto Update(CorpusDto entity);
        public void Remove(CorpusDto entity);

        public ICollection<CorpusDto> GetAll();
        public CorpusDto GetById(Guid Id);
    }
}
