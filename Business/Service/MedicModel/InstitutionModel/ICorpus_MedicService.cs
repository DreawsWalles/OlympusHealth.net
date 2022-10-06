using Business.Interop.InstitutionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.InstitutionModel
{
    public interface ICorpus_MedicService
    {
        public Corpus_MedicDto Create(Corpus_MedicDto entity);
        public Corpus_MedicDto Update(Corpus_MedicDto entity);
        public void Remove(Corpus_MedicDto entity);

        public IEnumerable<Corpus_MedicDto> GetAll();
        public Corpus_MedicDto GetById(Guid id);
    }
}
