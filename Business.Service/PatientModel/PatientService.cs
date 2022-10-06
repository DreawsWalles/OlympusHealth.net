using AutoMapper;
using Business.Enties.PatientModel;
using Business.Interop.PatientModel;
using Business.Repository.DataRepository.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public PatientDto Create(PatientDto entity)
        {
            Patient patient = _mapper.Map<Patient>(entity);
            _patientRepository.Create(patient);
            return _mapper.Map<PatientDto>(patient);
        }

        public IEnumerable<PatientDto> GetAll()
        {
            return _mapper.Map<List<Patient>, IEnumerable<PatientDto>>(_patientRepository.Query());
        }

        public PatientDto GetById(Guid id)
        {
            return _mapper.Map<PatientDto>(_patientRepository.Query().FirstOrDefault(e => e.Id == id));
        }

        public void Remove(PatientDto entity)
        {
            Patient patient = _mapper.Map<Patient>(entity);
            _patientRepository.Delete(patient);
        }

        public PatientDto Update(PatientDto entity)
        {
            Patient patient = _mapper.Map<Patient>(entity);
            _patientRepository.Update(patient);
            return _mapper.Map<PatientDto>(patient);
        }
    }
}
