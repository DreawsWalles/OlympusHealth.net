using AutoMapper;
using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public class Description_StatusOfTheAttributeService : IDescription_StatusOfTheAttributeService
    {
        private readonly IDescription_StatusOfTheAttributeRepository _description_StatusOfTheAttributeRepository;
        private readonly IMapper _mapper;

        public Description_StatusOfTheAttributeService(IDescription_StatusOfTheAttributeRepository description_StatusOfTheAttributeRepository, IMapper mapper)
        {
            _description_StatusOfTheAttributeRepository = description_StatusOfTheAttributeRepository;
            _mapper = mapper;
        }

        public Description_StatusOfTheAttributeDto Create(Description_StatusOfTheAttributeDto entity)
        {
            Description_StatusOfTheAttribute description_StatusOfTheAttribute = _mapper.Map<Description_StatusOfTheAttribute>(entity);
            _description_StatusOfTheAttributeRepository.Create(description_StatusOfTheAttribute);
            return _mapper.Map<Description_StatusOfTheAttributeDto>(description_StatusOfTheAttribute);
        }

        public IEnumerable<Description_StatusOfTheAttributeDto> GetAll()
        {
            return _mapper.Map<List<Description_StatusOfTheAttribute>, IEnumerable<Description_StatusOfTheAttributeDto>>(_description_StatusOfTheAttributeRepository.Query());
        }

        public Description_StatusOfTheAttributeDto GetById(Guid DescriptionId, Guid StatusOfTheAttributeId)
        {
            return _mapper.Map<Description_StatusOfTheAttributeDto>(_description_StatusOfTheAttributeRepository.Query().FirstOrDefault(e => e.DescriptionId == DescriptionId && e.StatusOfTheAttributeId == StatusOfTheAttributeId)); //Написать запрос
        }

        public void Remove(Description_StatusOfTheAttributeDto entity)
        {
            Description_StatusOfTheAttribute description_StatusOfTheAttribute = _mapper.Map<Description_StatusOfTheAttribute>(entity);
            _description_StatusOfTheAttributeRepository.Delete(description_StatusOfTheAttribute);
        }

        public Description_StatusOfTheAttributeDto Update(Description_StatusOfTheAttributeDto entity)
        {
            Description_StatusOfTheAttribute description_StatusOfTheAttribute = _mapper.Map<Description_StatusOfTheAttribute>(entity);
            _description_StatusOfTheAttributeRepository.Update(description_StatusOfTheAttribute);
            return _mapper.Map<Description_StatusOfTheAttributeDto>(description_StatusOfTheAttribute);
        }
    }
}
