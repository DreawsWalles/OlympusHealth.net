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
    public class ProcessDymanicsService : IProcessDynamicsService
    {
        private readonly IProcessDynamicsRepository _processDynamicsRepository;
        private readonly IMapper _mapper;

        public ProcessDymanicsService(IProcessDynamicsRepository processDynamicsRepository, IMapper mapper)
        {
            _processDynamicsRepository = processDynamicsRepository ?? throw new ArgumentNullException(nameof(processDynamicsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(ProcessDynamicsDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentException(nameof(entity.Name));
        }

        public ProcessDynamicsDto Create(ProcessDynamicsDto entity)
        {
            CheckEntity(entity);
            ProcessDynamics processDynamics = _mapper.Map<ProcessDynamics>(entity);
            _processDynamicsRepository.Create(processDynamics);
            return _mapper.Map<ProcessDynamicsDto>(processDynamics);
        }

        public async Task<ProcessDynamicsDto> CreateAsync(ProcessDynamicsDto entity)
        {
            CheckEntity(entity);
            ProcessDynamics processDynamics = _mapper.Map<ProcessDynamics>(entity);
            await _processDynamicsRepository.CreateAsync(processDynamics);
            return _mapper.Map<ProcessDynamicsDto>(processDynamics);
        }

        public ICollection<ProcessDynamicsDto> GetAll()
        {
            return _mapper.Map<List<ProcessDynamics>, ICollection<ProcessDynamicsDto>>(_processDynamicsRepository.Query());
        }

        public async Task<ICollection<ProcessDynamicsDto>> GetAllAsync()
        {
            return _mapper.Map<List<ProcessDynamics>, ICollection<ProcessDynamicsDto>>(await _processDynamicsRepository.QueryAsync());
        }

        public ProcessDynamicsDto GetById(Guid id)
        {
            if(id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<ProcessDynamicsDto>(_processDynamicsRepository.Query().FirstOrDefault(e => e.Id == id)); 
        }

        public async Task<ProcessDynamicsDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<ProcessDynamicsDto>((await _processDynamicsRepository.QueryAsync()).FirstOrDefault(e => e.Id == id));
        }

        public void Remove(ProcessDynamicsDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity));
            ProcessDynamics processDynamics = _mapper.Map<ProcessDynamics>(entity);
            _processDynamicsRepository.Delete(processDynamics);
        }

        public ProcessDynamicsDto Update(ProcessDynamicsDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity));    
            ProcessDynamics processDynamics = _mapper.Map<ProcessDynamics>(entity);
            _processDynamicsRepository.Update(processDynamics);
            return _mapper.Map<ProcessDynamicsDto>(processDynamics);
        }

        public async Task<ProcessDynamicsDto> UpdateAsync(ProcessDynamicsDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity));
            ProcessDynamics processDynamics = _mapper.Map<ProcessDynamics>(entity);
            await _processDynamicsRepository.CreateOrUpdateAsync(processDynamics);
            return _mapper.Map<ProcessDynamicsDto>(processDynamics);
        }
    }
}
