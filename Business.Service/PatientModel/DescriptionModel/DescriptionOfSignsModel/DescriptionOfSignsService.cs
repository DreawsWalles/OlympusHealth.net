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
    public class DescriptionOfSignsService : IDescriptionOfSignsService
    {
        private readonly IDescriptionOfSignsRepository _descriptionOfSignsRepository;
        private readonly IMapper _mapper;

        public DescriptionOfSignsService(IDescriptionOfSignsRepository descriptionOfSignsRepository, IMapper mapper)
        {
            _descriptionOfSignsRepository = descriptionOfSignsRepository;
            _mapper = mapper;
        }

        public DescriptionOfSignsDto Create(DescriptionOfSignsDto entity)
        {
            DescriptionOfSigns descriptionOfSigns = _mapper.Map<DescriptionOfSigns>(entity);
            _descriptionOfSignsRepository.Create(descriptionOfSigns);
            return _mapper.Map<DescriptionOfSignsDto>(descriptionOfSigns);
        }

        public IEnumerable<DescriptionOfSignsDto> GetAll()
        {
            return _mapper.Map<List<DescriptionOfSigns>, IEnumerable<DescriptionOfSignsDto>>(_descriptionOfSignsRepository.Query());
        }

        public DescriptionOfSignsDto GetById(Guid id)
        {
            return _mapper.Map<DescriptionOfSignsDto>(_descriptionOfSignsRepository.Query().FirstOrDefault(e => e.Id == id)); //Написать запрос
        }

        public void Remove(DescriptionOfSignsDto entity)
        {
            DescriptionOfSigns descriptionOfSigns = _mapper.Map<DescriptionOfSigns>(entity);
            _descriptionOfSignsRepository.Delete(descriptionOfSigns);
        }

        public DescriptionOfSignsDto Update(DescriptionOfSignsDto entity)
        {
            DescriptionOfSigns descriptionOfSigns = _mapper.Map<DescriptionOfSigns>(entity);
            _descriptionOfSignsRepository.Update(descriptionOfSigns);
            return _mapper.Map<DescriptionOfSignsDto>(descriptionOfSigns);
        }
    }
}
