using AutoMapper;
using Business.Enties.MedicModel.PlaceOfStudyModel;
using Business.Interop.PlaceOfStudyModel;
using Business.Repository.DataRepository.MedicModel.PlaceOfStudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.PlaceOfStudyModel
{
    public class IntershipService : IIntershipService
    {
        private readonly IIntershipRepository _intershipRepository;
        private readonly IMapper _mapper;

        public IntershipService(IIntershipRepository intershipRepository, IMapper mapper)
        {
            _intershipRepository = intershipRepository;
            _mapper = mapper;
        }

        public IntershipDto Create(IntershipDto entity)
        {
            Intership intership = _mapper.Map<Intership>(entity);
            _intershipRepository.Create(intership);
            return _mapper.Map<IntershipDto>(intership);
        }

        public IEnumerable<IntershipDto> GetAll()
        {
            return _mapper.Map<List<Intership>, IEnumerable<IntershipDto>>(_intershipRepository.Query());
        }

        public IntershipDto GetById(Guid Id)
        {
            return _mapper.Map<IntershipDto>(_intershipRepository.Query().FirstOrDefault(e => e.Id == Id)); //Написать запрос
        }

        public void Remove(IntershipDto entity)
        {
            Intership intership = _mapper.Map<Intership>(entity);
            _intershipRepository.Delete(intership);
        }

        public IntershipDto Update(IntershipDto entity)
        {
            Intership intership = _mapper.Map<Intership>(entity);
            _intershipRepository.Update(intership);
            return _mapper.Map<IntershipDto>(intership);
        }
    }
}
