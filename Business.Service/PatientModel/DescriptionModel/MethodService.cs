using AutoMapper;
using Business.Enties.PatientModel.DescriptionModel;
using Business.Interop.PatientModel.DescriptionModel;
using Business.Repository.DataRepository.MedicModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel
{
    public class MethodService : IMethodService
    {
        private readonly IMethodRepository _methodRepository;
        private readonly IMapper _mapper;

        public MethodService(IMethodRepository methodRepository, IMapper mapper)
        {
            _methodRepository= methodRepository ?? throw new ArgumentNullException(nameof(methodRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(MethodDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if(entity.NameFieldMethod == null || entity.NameFieldMethod.Trim() == "")
                throw new ArgumentNullException(nameof(entity.NameFieldMethod));
            if (entity.NameTitle == null || entity.NameTitle.Trim() == "")
                throw new ArgumentNullException(nameof(entity.NameTitle));
            if(entity.ResearchArea == null)
                throw new ArgumentNullException(nameof(entity.ResearchArea));
            if(entity.ResearchCategory == null)
                throw new ArgumentNullException(nameof(entity.ResearchCategory));
        }

        public MethodDto Create(MethodDto entity)
        {
            CheckEntity(entity);
            Method method = _mapper.Map<Method>(entity);
            _methodRepository.Create(method);
            return _mapper.Map<MethodDto>(method);
        }

        public async Task<MethodDto> CreateAsync(MethodDto entity)
        {
            CheckEntity(entity);
            Method method = _mapper.Map<Method>(entity);
             await _methodRepository.CreateAsync(method);
            return _mapper.Map<MethodDto>(method);
        }

        public ICollection<MethodDto> GetAll()
        {
            return _mapper.Map<List<Method>, ICollection<MethodDto>>(_methodRepository.Query());
        }

        public async Task<ICollection<MethodDto>> GetAllAsync()
        {
            return _mapper.Map<List<Method>, ICollection<MethodDto>>(await _methodRepository.QueryAsync());
        }

        public MethodDto GetById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<MethodDto>(_methodRepository.Query().FirstOrDefault(e => e.Id == id));
        }

        public async Task<MethodDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<MethodDto>((await _methodRepository.QueryAsync()).FirstOrDefault(e => e.Id == id));
        }

        public void Remove(MethodDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Method method = _mapper.Map<Method>(entity);
            _methodRepository.Delete(method);
        }

        public MethodDto Update(MethodDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Method method = _mapper.Map<Method>(entity);
            _methodRepository.Update(method);
            return _mapper.Map<MethodDto>(method);
        }

        public async Task<MethodDto> UpdateAsync(MethodDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Method method = _mapper.Map<Method>(entity);
            await _methodRepository.CreateOrUpdateAsync(method);
            return _mapper.Map<MethodDto>(method);
        }
    }
}
