using AutoMapper;
using Business.Enties;
using Business.Interop;
using Business.Repository.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GenderService(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        public GenderDto Create(GenderDto entity)
        {
            Gender gender = _mapper.Map<Gender>(entity);
            _genderRepository.Create(gender);
            return _mapper.Map<GenderDto>(entity);
        }

        public IEnumerable<GenderDto> GetAll()
        {
            return _mapper.Map<List<Gender>, IEnumerable<GenderDto>>(_genderRepository.Query());
        }

        public GenderDto? GetById(Guid Id)
        {
            return _mapper.Map<GenderDto>(_genderRepository.Query().FirstOrDefault(e => e.Id == Id)); //гаписать запрос
        }

        public void Remove(GenderDto entity)
        {
            Gender gender = _mapper.Map<Gender>(entity);
            _genderRepository.Delete(gender);
        }

        public GenderDto Update(GenderDto updateEntity)
        {
            Gender gender = _mapper.Map<Gender>(updateEntity);
            _genderRepository.Update(gender);
            return updateEntity; 
        }
    }
}
