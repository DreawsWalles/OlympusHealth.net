using AutoMapper;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Interop.InstitutionModel;
using Business.Repository.DataRepository.MedicModel.InstitutionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.InstitutionModel
{
    public class Corpus_MedicService : ICorpus_MedicService
    {
        private readonly ICorpus_MedicRepository _corpus_MedicRepository;
        private readonly IMapper _mapper;

        public Corpus_MedicService(ICorpus_MedicRepository corpus_MedicRepository, IMapper mapper)
        {
            _corpus_MedicRepository = corpus_MedicRepository;
            _mapper = mapper;
        }

        public Corpus_MedicDto Create(Corpus_MedicDto entity)
        {
            Corpus_Medic corpus_Medic = _mapper.Map<Corpus_Medic>(entity);
            _corpus_MedicRepository.Create(corpus_Medic);
            return _mapper.Map<Corpus_MedicDto>(corpus_Medic);
        }

        public IEnumerable<Corpus_MedicDto> GetAll()
        {
            return _mapper.Map<List<Corpus_Medic>, IEnumerable<Corpus_MedicDto>>(_corpus_MedicRepository.Query());
        }

        public Corpus_MedicDto GetById(Guid id)
        {
            return _mapper.Map<Corpus_MedicDto>(_corpus_MedicRepository.Query().FirstOrDefault(e => e.CorpusId == id)); //Написать запрос
        }

        public void Remove(Corpus_MedicDto entity)
        {
            Corpus_Medic corpus_Medic = _mapper.Map<Corpus_Medic>(entity);
            _corpus_MedicRepository.Delete(corpus_Medic);
        }

        public Corpus_MedicDto Update(Corpus_MedicDto entity)
        {
            Corpus_Medic corpus_Medic = _mapper.Map<Corpus_Medic>(entity);
            _corpus_MedicRepository.Update(corpus_Medic);
            return _mapper.Map<Corpus_MedicDto>(corpus_Medic);
        }
    }
}
