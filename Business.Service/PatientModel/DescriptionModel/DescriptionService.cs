using AutoMapper;
using Business.Enties.PatientModel.DescriptionModel;
using Business.Interop.PatientModel.DescriptionModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel
{
    public class DescriptionService : IDescriptionService
    {
        private readonly IDescriptionRepository _descriptionRepository;
        private readonly IMapper _mapper;

        public DescriptionDto Create(DescriptionDto entity)
        {
            Description description = _mapper.Map<Description>(entity);
            _descriptionRepository.Create(description);
            return _mapper.Map<DescriptionDto>(description);
        }

        public IEnumerable<DescriptionDto> GetAll()
        {
            return _mapper.Map<List<Description>, IEnumerable<DescriptionDto>>(_descriptionRepository.Query());
        }

        public DescriptionDto GetById(Guid id)
        {
            return _mapper.Map<DescriptionDto>(_descriptionRepository.Query().FirstOrDefault(e => e.Id == id)); //Написать запрос
        }

        public void Remove(DescriptionDto entity)
        {
            Description description = _mapper.Map<Description>(entity);
            _descriptionRepository.Delete(description);
        }

        public DescriptionDto Update(DescriptionDto entity)
        {
            Description description = _mapper.Map<Description>(entity);
            _descriptionRepository.Update(description);
            return _mapper.Map<DescriptionDto>(description);
        }
    }
}
