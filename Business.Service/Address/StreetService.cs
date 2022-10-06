using AutoMapper;
using Business.Enties.Address;
using Business.Interop.Address;
using Business.Repository.DataRepository.Address;
using Business.Service.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Address
{
    public class StreetService : IStreetService
    {
        private readonly IStreetRepository _streetRepository;
        private readonly IMapper _mapper;

        public StreetService(IStreetRepository streetRepository, IMapper mapper)
        {
            _streetRepository = streetRepository;
            _mapper = mapper;
        }

        public StreetDto Create(StreetDto entity)
        {
            Street street = _mapper.Map<Street>(entity);
            _streetRepository.Create(street);
            return _mapper.Map<StreetDto>(street);
        }

        public IEnumerable<StreetDto> GetAll()
        {
            return _mapper.Map<List<Street>, IEnumerable<StreetDto>>(_streetRepository.Query());
        }

        public StreetDto? GetById(Guid Id)
        {
            return _mapper.Map<StreetDto>(_streetRepository.Query().FirstOrDefault(e => e.Id == Id));//написать запрос
        }

        public void Remove(StreetDto entity)
        {
            Street street = _mapper.Map<Street>(entity);
            _streetRepository.Delete(street);
        }

        public StreetDto Update(StreetDto updateEntity)
        {
            Street street = _mapper.Map<Street>(updateEntity);
            _streetRepository.Update(street);
            return _mapper.Map<StreetDto>(street);
        }
    }
}
