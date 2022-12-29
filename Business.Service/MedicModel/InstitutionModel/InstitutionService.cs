using AutoMapper;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Interop.InstitutionModel;
using Business.Repository.DataRepository.MedicModel.InstitutionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.InstitutionModel
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IInstitutionRepository _institutionRepository;
        private readonly IMapper _mapper;

        public InstitutionService(IInstitutionRepository institutionRepository, IMapper mapper)
        {
            _institutionRepository = institutionRepository ?? throw new ArgumentNullException(nameof(institutionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(InstitutionDto entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentException(nameof(entity.Name));
        }

        public InstitutionDto Create(InstitutionDto entity)
        {
            CheckEntity(entity);
            Institution institution = _mapper.Map<Institution>(entity);
            _institutionRepository.Create(institution);
            return _mapper.Map<InstitutionDto>(institution);
        }

        public async Task<InstitutionDto> CreateAsync(InstitutionDto entity)
        {
            CheckEntity(entity);
            Institution institution = _mapper.Map<Institution>(entity);
            await _institutionRepository.CreateAsync(institution);
            return _mapper.Map<InstitutionDto>(institution);
        }

        public ICollection<InstitutionDto> GetAll()
        {
            return _mapper.Map<List<Institution>, ICollection<InstitutionDto>>(_institutionRepository.Query());
        }

        public async Task<ICollection<InstitutionDto>> GetAllAsync()
        {
            return _mapper.Map<List<Institution>, ICollection<InstitutionDto>>(await _institutionRepository.QueryAsync());
        }

        public InstitutionDto GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            return _mapper.Map<InstitutionDto>(_institutionRepository.Query().FirstOrDefault(e => e.Id == Id)); 
        }

        public async Task<InstitutionDto> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            var list = await _institutionRepository.QueryAsync();
            return _mapper.Map<InstitutionDto>(list.FirstOrDefault(e => e.Id == Id));
        }

        public void Remove(InstitutionDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Institution institution = _mapper.Map<Institution>(entity);
            _institutionRepository.Delete(institution);
        }

        public InstitutionDto Update(InstitutionDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Institution institution = _mapper.Map<Institution>(entity);
            _institutionRepository.Update(institution);
            return _mapper.Map<InstitutionDto>(institution);
        }

        public async Task<InstitutionDto> UpdateAsync(InstitutionDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Institution institution = _mapper.Map<Institution>(entity);
            await _institutionRepository.CreateOrUpdateAsync(institution);
            return _mapper.Map<InstitutionDto>(institution);
        }
    }
}
