using AutoMapper;
using Business.Enties.MedicModel.PlaceOfStudyModel;
using Business.Interop.PlaceOfStudyModel;
using Business.Repository.DataRepository.MedicModel.PlaceOfStudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.PlaceOfStudyModel
{
    public class IntershipService : IIntershipService
    {
        private readonly IIntershipRepository _intershipRepository;
        private readonly IMapper _mapper;

        public IntershipService(IIntershipRepository intershipRepository, IMapper mapper)
        {
            _intershipRepository = intershipRepository ?? throw new ArgumentNullException(nameof(intershipRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(IntershipDto entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.Street == null)
                throw new ArgumentNullException(nameof(entity.Street));
        }

        public IntershipDto Create(IntershipDto entity)
        {
            CheckEntity(entity);
            Intership intership = _mapper.Map<Intership>(entity);
            _intershipRepository.Create(intership);
            return _mapper.Map<IntershipDto>(intership);
        }

        public async Task<IntershipDto> CreateAsync(IntershipDto entity)
        {
            CheckEntity(entity);
            Intership intership = _mapper.Map<Intership>(entity);
            await _intershipRepository.CreateAsync(intership);
            return _mapper.Map<IntershipDto>(intership);
        }

        public ICollection<IntershipDto> GetAll()
        {
            return _mapper.Map<List<Intership>, ICollection<IntershipDto>>(_intershipRepository.Query());
        }

        public async Task<ICollection<IntershipDto>> GetAllAsync()
        {
            return _mapper.Map<List<Intership>, ICollection<IntershipDto>>(await _intershipRepository.QueryAsync());
        }

        public IntershipDto GetById(Guid Id)
        {
            return _mapper.Map<IntershipDto>(_intershipRepository.Query().FirstOrDefault(e => e.Id == Id)); 
        }

        public async Task<IntershipDto> GetByIdAsync(Guid Id)
        {
            var list = await _intershipRepository.QueryAsync();
            return _mapper.Map<IntershipDto>(list.FirstOrDefault(e => e.Id == Id));
        }

        public void Remove(IntershipDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Intership intership = _mapper.Map<Intership>(entity);
            _intershipRepository.Delete(intership);
        }

        public IntershipDto Update(IntershipDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Intership intership = _mapper.Map<Intership>(entity);
            _intershipRepository.Update(intership);
            return _mapper.Map<IntershipDto>(intership);
        }

        public async Task<IntershipDto> UpdateAsync(IntershipDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Intership intership = _mapper.Map<Intership>(entity);
            await _intershipRepository.CreateOrUpdateAsync(intership);
            return _mapper.Map<IntershipDto>(intership);
        }
    }
}
