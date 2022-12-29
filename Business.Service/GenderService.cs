using AutoMapper;
using Business.Enties;
using Business.Interop;
using Business.Repository.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GenderService(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository ?? throw new ArgumentNullException(nameof(genderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        private static void CheckEntity(GenderDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentException(nameof(entity.Name));
        }
        public GenderDto Create(GenderDto entity)
        {
            CheckEntity(entity);
            Gender gender = _mapper.Map<Gender>(entity);
            _genderRepository.Create(gender);
            return _mapper.Map<GenderDto>(entity);
        }

        public ICollection<GenderDto> GetAll()
        {
            return _mapper.Map<List<Gender>, ICollection<GenderDto>>(_genderRepository.Query());
        }

        public GenderDto? GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            return _mapper.Map<GenderDto>(_genderRepository.Query().FirstOrDefault(e => e.Id == Id)); 
        }

        public void Remove(GenderDto entity)
        {
            CheckEntity(entity);
            if(entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Gender gender = _mapper.Map<Gender>(entity);
            _genderRepository.Delete(gender);
        }

        public GenderDto Update(GenderDto updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(updateEntity.Id));
            Gender gender = _mapper.Map<Gender>(updateEntity);
            _genderRepository.Update(gender);
            return updateEntity; 
        }

        public async Task<GenderDto> CreateAsync(GenderDto entity)
        {
            CheckEntity(entity);
            Gender gender = _mapper.Map<Gender>(entity);
            await _genderRepository.CreateAsync(gender);
            return _mapper.Map<GenderDto>(entity);
        }

        public async Task<GenderDto> UpdateAsync(GenderDto updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(updateEntity.Id));
            Gender gender = _mapper.Map<Gender>(updateEntity);
            await _genderRepository.CreateOrUpdateAsync(gender);
            return updateEntity;
        }

        public async Task<ICollection<GenderDto>> GetAllAsync()
        {
            return _mapper.Map<List<Gender>, ICollection<GenderDto>>(await _genderRepository.QueryAsync());
        }

        public async Task<GenderDto?> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            var query = await _genderRepository.QueryAsync();
            return _mapper.Map<GenderDto>(query.FirstOrDefault(e => e.Id == Id));
        }
    }
}
