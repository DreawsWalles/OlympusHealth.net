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
    public class CorpusService : ICorpusService
    {
        private readonly ICorpusRepository _corpusRepository;
        private readonly IMapper _mapper;

        public CorpusService(ICorpusRepository corpusRepository, IMapper mapper)
        {
            _corpusRepository = corpusRepository;
            _mapper = mapper;
        }

        public CorpusDto Create(CorpusDto entity)
        {
            Corpus corpus = _mapper.Map<Corpus>(entity);
            _corpusRepository.Create(corpus);
            return _mapper.Map<CorpusDto>(corpus);
        }

        public ICollection<CorpusDto> GetAll()
        {
            return _mapper.Map<List<Corpus>, ICollection<CorpusDto>>(_corpusRepository.Query());
        }

        public CorpusDto GetById(Guid Id)
        {
            return _mapper.Map<CorpusDto>(_corpusRepository.Query().FirstOrDefault(e => e.Id == Id)); // Написать запрос
        }

        public void Remove(CorpusDto entity)
        {
            Corpus corpus = _mapper.Map<Corpus>(entity);
            _corpusRepository.Delete(corpus);
        }

        public CorpusDto Update(CorpusDto entity)
        {
            Corpus corpus = _mapper.Map<Corpus>(entity);
            _corpusRepository.Update(corpus);
            return _mapper.Map<CorpusDto>(corpus);
        }
    }
}
