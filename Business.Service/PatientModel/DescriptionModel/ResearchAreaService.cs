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
    public class ResearchAreaService : IResearchAreaService
    {
        private readonly IResearchAreaRepository _researchAreaRepository;
        private readonly IMapper _mapper;

        public ResearchAreaService(IResearchAreaRepository researchAreaRepository, IMapper mapper)
        {
            _researchAreaRepository = researchAreaRepository ?? throw new ArgumentNullException(nameof(researchAreaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(ResearchAreaDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity));
            if(entity.Patient == null)
                throw new ArgumentNullException(nameof(entity));
        }

        public ResearchAreaDto Create(ResearchAreaDto entity)
        {
            CheckEntity(entity);
            ResearchArea researchArea = _mapper.Map<ResearchArea>(entity);
            _researchAreaRepository.Create(researchArea);
            return _mapper.Map<ResearchAreaDto>(researchArea);
        }

        public async Task<ResearchAreaDto> CreateAsync(ResearchAreaDto entity)
        {
            CheckEntity(entity);
            ResearchArea researchArea = _mapper.Map<ResearchArea>(entity);
            await _researchAreaRepository.CreateAsync(researchArea);
            return _mapper.Map<ResearchAreaDto>(researchArea);
        }

        public ICollection<ResearchAreaDto> GetAll()
        {
            return _mapper.Map<List<ResearchArea>, ICollection<ResearchAreaDto>>(_researchAreaRepository.Query());
        }

        public async Task<ICollection<ResearchAreaDto>> GetAllAsync()
        {
            return _mapper.Map<List<ResearchArea>, ICollection<ResearchAreaDto>>(await _researchAreaRepository.QueryAsync());
        }

        public ResearchAreaDto GetById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<ResearchAreaDto>(_researchAreaRepository.Query().FirstOrDefault(e => e.Id == id)); 
        }

        public async Task<ResearchAreaDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<ResearchAreaDto>((await _researchAreaRepository.QueryAsync()).FirstOrDefault(e => e.Id == id));
        }

        public void Remove(ResearchAreaDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            ResearchArea researchArea = _mapper.Map<ResearchArea>(entity);
            _researchAreaRepository.Delete(researchArea);
        }

        public ResearchAreaDto Update(ResearchAreaDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            ResearchArea researchArea = _mapper.Map<ResearchArea>(entity);
            _researchAreaRepository.Update(researchArea);
            return _mapper.Map<ResearchAreaDto>(researchArea);
        }

        public async Task<ResearchAreaDto> UpdateAsync(ResearchAreaDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            ResearchArea researchArea = _mapper.Map<ResearchArea>(entity);
            await _researchAreaRepository.CreateOrUpdateAsync(researchArea);
            return _mapper.Map<ResearchAreaDto>(researchArea);
        }
    }
}
