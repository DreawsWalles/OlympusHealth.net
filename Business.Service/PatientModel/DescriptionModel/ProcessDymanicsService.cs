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
            _processDynamicsRepository = processDynamicsRepository;
            _mapper = mapper;
        }

        public ProcessDynamicsDto Create(ProcessDynamicsDto entity)
        {
            ProcessDynamics processDynamics = _mapper.Map<ProcessDynamics>(entity);
            _processDynamicsRepository.Create(processDynamics);
            return _mapper.Map<ProcessDynamicsDto>(processDynamics);
        }

        public IEnumerable<ProcessDynamicsDto> GetAll()
        {
            return _mapper.Map<List<ProcessDynamics>, IEnumerable<ProcessDynamicsDto>>(_processDynamicsRepository.Query());
        }

        public ProcessDynamicsDto GetById(Guid id)
        {
            return _mapper.Map<ProcessDynamicsDto>(_processDynamicsRepository.Query().FirstOrDefault(e => e.Id == id)); //написать запрос
        }

        public void Remove(ProcessDynamicsDto entity)
        {
            ProcessDynamics processDynamics = _mapper.Map<ProcessDynamics>(entity);
            _processDynamicsRepository.Delete(processDynamics);
        }

        public ProcessDynamicsDto Update(ProcessDynamicsDto entity)
        {
            ProcessDynamics processDynamics = _mapper.Map<ProcessDynamics>(entity);
            _processDynamicsRepository.Update(processDynamics);
            return _mapper.Map<ProcessDynamicsDto>(processDynamics);
        }
    }
}
