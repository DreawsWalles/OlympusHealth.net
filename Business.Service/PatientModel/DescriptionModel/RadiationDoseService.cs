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
    public class RadiationDoseService : IRadiationDoseService
    {
        private readonly IRadiationDoseRepository _radiationDoseRepository;
        private readonly IMapper _mapper;

        public RadiationDoseService(IRadiationDoseRepository radiationDoseRepository, IMapper mapper)
        {
            _radiationDoseRepository = radiationDoseRepository;
            _mapper = mapper;
        }

        public RadiationDoseDto Create(RadiationDoseDto entity)
        {
            RadiationDose radiationDose = _mapper.Map<RadiationDose>(entity);
            _radiationDoseRepository.Create(radiationDose);
            return _mapper.Map<RadiationDoseDto>(radiationDose);
        }

        public IEnumerable<RadiationDoseDto> GetAll()
        {
            return _mapper.Map<List<RadiationDose>, List<RadiationDoseDto>>(_radiationDoseRepository.Query());
        }

        public RadiationDoseDto GetById(Guid id)
        {
            return _mapper.Map<RadiationDoseDto>(_radiationDoseRepository.Query().FirstOrDefault(e => e.Id == id)); //написать запрос
        }

        public void Remove(RadiationDoseDto entity)
        {
            RadiationDose radiationDose = _mapper.Map<RadiationDose>(entity);
            _radiationDoseRepository.Delete(radiationDose);
        }

        public RadiationDoseDto Update(RadiationDoseDto entity)
        {
            RadiationDose radiationDose = _mapper.Map<RadiationDose>(entity);
            _radiationDoseRepository.Update(radiationDose);
            return _mapper.Map<RadiationDoseDto>(radiationDose);
        }
    }
}
