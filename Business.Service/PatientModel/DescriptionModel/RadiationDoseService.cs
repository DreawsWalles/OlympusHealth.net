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
        
        private static void CheckEntity(RadiationDoseDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Dose < 0.0)
                throw new ArgumentException(nameof(entity.Dose));
            if (entity.Method == null)
                throw new ArgumentNullException(nameof(entity.Dose));
        }

        public RadiationDoseDto Create(RadiationDoseDto entity)
        {
            CheckEntity(entity);
            RadiationDose radiationDose = _mapper.Map<RadiationDose>(entity);
            _radiationDoseRepository.Create(radiationDose);
            return _mapper.Map<RadiationDoseDto>(radiationDose);
        }

        public async Task<RadiationDoseDto> CreateAsync(RadiationDoseDto entity)
        {
            CheckEntity(entity);
            RadiationDose radiationDose = _mapper.Map<RadiationDose>(entity);
            await _radiationDoseRepository.CreateAsync(radiationDose);
            return _mapper.Map<RadiationDoseDto>(radiationDose);
        }

        public ICollection<RadiationDoseDto> GetAll()
        {
            return _mapper.Map<List<RadiationDose>, List<RadiationDoseDto>>(_radiationDoseRepository.Query());
        }

        public async Task<ICollection<RadiationDoseDto>> GetAllAsync()
        {
            return _mapper.Map<List<RadiationDose>, List<RadiationDoseDto>>(await _radiationDoseRepository.QueryAsync());
        }

        public RadiationDoseDto GetById(Guid id)
        {
            if(id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<RadiationDoseDto>(_radiationDoseRepository.Query().FirstOrDefault(e => e.Id == id)); 
        }

        public async Task<RadiationDoseDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<RadiationDoseDto>((await _radiationDoseRepository.QueryAsync()).FirstOrDefault(e => e.Id == id));
        }

        public void Remove(RadiationDoseDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            RadiationDose radiationDose = _mapper.Map<RadiationDose>(entity);
            _radiationDoseRepository.Delete(radiationDose);
        }

        public RadiationDoseDto Update(RadiationDoseDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            RadiationDose radiationDose = _mapper.Map<RadiationDose>(entity);
            _radiationDoseRepository.Update(radiationDose);
            return _mapper.Map<RadiationDoseDto>(radiationDose);
        }

        public async Task<RadiationDoseDto> UpdateAsync(RadiationDoseDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            RadiationDose radiationDose = _mapper.Map<RadiationDose>(entity);
            await _radiationDoseRepository.CreateOrUpdateAsync(radiationDose);
            return _mapper.Map<RadiationDoseDto>(radiationDose);
        }
    }
}
