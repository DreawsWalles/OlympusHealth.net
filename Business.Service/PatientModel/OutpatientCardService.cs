using AutoMapper;
using Business.Enties.PatientModel;
using Business.Interop.PatientModel;
using Business.Repository.DataRepository.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel
{
    public class OutpatientCardService : IOutpatientCardService
    {
        private readonly IOutpatientCardRepository _outpatientCardRepository;
        private readonly IMapper _mapper;

        public OutpatientCardService(IOutpatientCardRepository outpatientCardRepository, IMapper mapper)
        {
            _outpatientCardRepository = outpatientCardRepository;
            _mapper = mapper;
        }

        public OutpatientCardDto Create(OutpatientCardDto entity)
        {
            OutpatientCard card = _mapper.Map<OutpatientCard>(entity);
            _outpatientCardRepository.Create(card);
            return _mapper.Map<OutpatientCardDto>(card);
        }

        public IEnumerable<OutpatientCardDto> GetAll()
        {
            return _mapper.Map<List<OutpatientCard>, IEnumerable<OutpatientCardDto>>(_outpatientCardRepository.Query());
        }

        public OutpatientCardDto GetById(Guid id)
        {
            return _mapper.Map<OutpatientCardDto>(_outpatientCardRepository.Query().FirstOrDefault(e => e.Id == id)); // написать запрос
        }

        public void Remove(OutpatientCardDto entity)
        {
            OutpatientCard card = _mapper.Map<OutpatientCard>(entity);
            _outpatientCardRepository.Delete(card);
        }

        public OutpatientCardDto Update(OutpatientCardDto entity)
        {
            OutpatientCard card = _mapper.Map<OutpatientCard>(entity);
            _outpatientCardRepository.Update(card);
            return _mapper.Map<OutpatientCardDto>(card);
        }
    }
}
