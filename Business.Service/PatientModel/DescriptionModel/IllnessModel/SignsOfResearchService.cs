using AutoMapper;
using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.IllnessModel
{
    public class SignsOfResearchService : ISignsOfResearchService
    {
        private readonly ISignsOfResearchRepository _signsOfResearchRepository;
        private readonly IMapper _mapper;

        public SignsOfResearchService(ISignsOfResearchRepository signsOfResearchRepository, IMapper mapper)
        {
            _signsOfResearchRepository = signsOfResearchRepository ?? throw new ArgumentNullException(nameof(signsOfResearchRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(SignsOfResearchDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if(entity.Name == null ||entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if(entity.Illness == null)
                throw new ArgumentNullException(nameof(entity.Illness));
        }

        public SignsOfResearchDto Create(SignsOfResearchDto entity)
        {
            CheckEntity(entity);
            SignsOfResearch signsOfResearch = _mapper.Map<SignsOfResearch>(entity);
            _signsOfResearchRepository.Create(signsOfResearch);
            return _mapper.Map<SignsOfResearchDto>(signsOfResearch);
        }

        public async Task<SignsOfResearchDto> CreateAsync(SignsOfResearchDto entity)
        {
            CheckEntity(entity);
            SignsOfResearch signsOfResearch = _mapper.Map<SignsOfResearch>(entity);
            await _signsOfResearchRepository.CreateAsync(signsOfResearch);
            return _mapper.Map<SignsOfResearchDto>(signsOfResearch);
        }

        public ICollection<SignsOfResearchDto> GetAll()
        {
            return _mapper.Map<List<SignsOfResearch>, ICollection<SignsOfResearchDto>>(_signsOfResearchRepository.Query());
        }

        public async Task<ICollection<SignsOfResearchDto>> GetAllAsync()
        {
            return _mapper.Map<List<SignsOfResearch>, ICollection<SignsOfResearchDto>>(await _signsOfResearchRepository.QueryAsync());
        }

        public SignsOfResearchDto GetById(Guid Id)
        {
            if(Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            return _mapper.Map<SignsOfResearchDto>(_signsOfResearchRepository.Query().FirstOrDefault(e => e.Id == Id)); 
        }

        public async Task<SignsOfResearchDto> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            return _mapper.Map<SignsOfResearchDto>((await _signsOfResearchRepository.QueryAsync()).FirstOrDefault(e => e.Id == Id));
        }

        public void Remove(SignsOfResearchDto entity)
        {
            CheckEntity(entity);
            if(entity.Id .CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            SignsOfResearch signsOfResearch = _mapper.Map<SignsOfResearch>(entity);
            _signsOfResearchRepository.Delete(signsOfResearch);
        }

        public SignsOfResearchDto Update(SignsOfResearchDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            SignsOfResearch signsOfResearch = _mapper.Map<SignsOfResearch>(entity);
            _signsOfResearchRepository.Update(signsOfResearch);
            return _mapper.Map<SignsOfResearchDto>(signsOfResearch);
        }

        public async Task<SignsOfResearchDto> UpdateAsync(SignsOfResearchDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            SignsOfResearch signsOfResearch = _mapper.Map<SignsOfResearch>(entity);
            await _signsOfResearchRepository.CreateOrUpdateAsync(signsOfResearch);
            return _mapper.Map<SignsOfResearchDto>(signsOfResearch);
        }
    }
}
