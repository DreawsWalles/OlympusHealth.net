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
    public class ResearchCategoryService : IResearchCategoryService
    {
        private readonly IResearchCategoryRepository _researchCategoryRepository;
        private readonly IMapper _mapper;

        public ResearchCategoryService(IResearchCategoryRepository researchCategoryRepository, IMapper mapper)
        {
            _researchCategoryRepository = researchCategoryRepository ?? throw new ArgumentNullException(nameof(researchCategoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(ResearchCategoryDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
        }

        public ResearchCategoryDto Create(ResearchCategoryDto entity)
        {
            CheckEntity(entity);    
            ResearchCategory researchCategory = _mapper.Map<ResearchCategory>(entity);
            _researchCategoryRepository.Create(researchCategory);
            return _mapper.Map<ResearchCategoryDto>(researchCategory);
        }

        public async Task<ResearchCategoryDto> CreateAsync(ResearchCategoryDto entity)
        {
            CheckEntity(entity);
            ResearchCategory researchCategory = _mapper.Map<ResearchCategory>(entity);
            await _researchCategoryRepository.CreateAsync(researchCategory);
            return _mapper.Map<ResearchCategoryDto>(researchCategory);
        }

        public ICollection<ResearchCategoryDto> GetAll()
        {
            return _mapper.Map<List<ResearchCategory>, ICollection<ResearchCategoryDto>>(_researchCategoryRepository.Query());
        }

        public async Task<ICollection<ResearchCategoryDto>> GetAllAsync()
        {
            return _mapper.Map<List<ResearchCategory>, ICollection<ResearchCategoryDto>>(await _researchCategoryRepository.QueryAsync());
        }

        public ResearchCategoryDto GetById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<ResearchCategoryDto>(_researchCategoryRepository.Query().FirstOrDefault(e => e.Id == id)); 
        }

        public async Task<ResearchCategoryDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<ResearchCategoryDto>((await _researchCategoryRepository.QueryAsync()).FirstOrDefault(e => e.Id == id));
        }

        public void Remove(ResearchCategoryDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            ResearchCategory researchCategory = _mapper.Map<ResearchCategory>(entity);
            _researchCategoryRepository.Delete(researchCategory);
        }

        public ResearchCategoryDto Update(ResearchCategoryDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            ResearchCategory researchCategory = _mapper.Map<ResearchCategory>(entity);
            _researchCategoryRepository.Update(researchCategory);
            return _mapper.Map<ResearchCategoryDto>(researchCategory);
        }

        public async Task<ResearchCategoryDto> UpdateAsync(ResearchCategoryDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            ResearchCategory researchCategory = _mapper.Map<ResearchCategory>(entity);
            await   _researchCategoryRepository.CreateOrUpdateAsync(researchCategory);
            return _mapper.Map<ResearchCategoryDto>(researchCategory);
        }
    }
}
