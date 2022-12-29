using AutoMapper;
using Business.Enties.MedicModel;
using Business.Interop;
using Business.Repository.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel
{
    public class AccessService : IAccessService
    {
        private readonly IAccessRepository _accessRepository;
        private readonly IMapper _mapper;

        public AccessService(IAccessRepository accessRepository, IMapper mapper)
        {
            _accessRepository = accessRepository ?? throw new ArgumentNullException(nameof(accessRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        private static void CheckEntity(Access entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null)
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.Medics == null)
                throw new ArgumentNullException(nameof(entity.Medics));
        }
        private static void CheckEntity(AccessDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null)
                throw new ArgumentNullException(nameof(entity.Name));
        }
        public AccessDto Create(AccessDto access)
        {
            if(access == null)  
                throw new ArgumentNullException(nameof(access));
            Access entity = _mapper.Map<Access>(access);
            CheckEntity(entity);
            _accessRepository.Create(entity);
            return _mapper.Map<AccessDto>(entity);
        }

        public async Task<AccessDto> CreateAsync(AccessDto access)
        {
            if (access == null)
                throw new ArgumentNullException(nameof(access));
            Access entity = _mapper.Map<Access>(access);
            CheckEntity(entity);
            await _accessRepository.CreateAsync(entity);
            return _mapper.Map<AccessDto>(entity);
        }

        public ICollection<AccessDto> GetAll()
        {
            return _mapper.Map<ICollection<Access>, ICollection<AccessDto>>(_accessRepository.Query());
        }

        public async Task<ICollection<AccessDto>> GetAllAsync()
        {
            return _mapper.Map<ICollection<Access>, ICollection<AccessDto>>(await _accessRepository.QueryAsync());
        }

        public AccessDto GetById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(id));
            return _mapper.Map<AccessDto>(_accessRepository.Query().Where(e => e.Id == id));
        }

        public async Task<AccessDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(id));
            var list = await _accessRepository.QueryAsync();
            return _mapper.Map<AccessDto>(list.Where(e => e.Id == id));
        }

        public void Remove(AccessDto access)
        {
            if (access == null)
                throw new ArgumentNullException(nameof(access));
            CheckEntity(access);
            if(access.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(access.Id));
            _accessRepository.Delete(_mapper.Map<Access>(access));
        }

        public AccessDto Update(AccessDto access)
        {
            if (access == null)
                throw new ArgumentNullException(nameof(access));
            var entity = _mapper.Map<Access>(access);
            CheckEntity(entity);
            if (access.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(access.Id));
            _accessRepository.Update(entity);
            return _mapper.Map<AccessDto>(entity);
        }

        public async Task<AccessDto> UpdateASync(AccessDto access)
        {
            if (access == null)
                throw new ArgumentNullException(nameof(access));
            var entity = _mapper.Map<Access>(access);
            CheckEntity(entity);
            if (access.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(access.Id));
            await _accessRepository.CreateOrUpdateAsync(entity);
            return _mapper.Map<AccessDto>(entity);
        }
    }
}
