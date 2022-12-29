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
    public class IllnessService : IIllnessService
    {
        private readonly IIllnessRepository _llnessRepository;
        private readonly IMapper _mapper;

        public IllnessService(IIllnessRepository illnessRepository, IMapper mapper)
        {
            _llnessRepository = illnessRepository ?? throw new ArgumentNullException(nameof(illnessRepository)) ;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(IllnessDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if(entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
        }


        public IllnessDto Create(IllnessDto entity)
        {
            CheckEntity(entity);
            Illness illness = _mapper.Map<Illness>(entity);
            _llnessRepository.Create(illness);
            return _mapper.Map<IllnessDto>(illness);
        }

        public async Task<IllnessDto> CreateAsync(IllnessDto entity)
        {
            CheckEntity(entity);
            Illness illness = _mapper.Map<Illness>(entity);
            await _llnessRepository.CreateAsync(illness);
            return _mapper.Map<IllnessDto>(illness);
        }

        public ICollection<IllnessDto> GetAll()
        {
            return _mapper.Map<List<Illness>, ICollection<IllnessDto>>(_llnessRepository.Query());
        }

        public async Task<ICollection<IllnessDto>> GetAllAsync()
        {
            return _mapper.Map<List<Illness>, ICollection<IllnessDto>>(await _llnessRepository.QueryAsync());
        }

        public IllnessDto GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            return _mapper.Map<IllnessDto>(_llnessRepository.Query().FirstOrDefault(e => e.Id == Id)); 
        }

        public async Task<IllnessDto> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            return _mapper.Map<IllnessDto>((await _llnessRepository.QueryAsync()).FirstOrDefault(e => e.Id == Id));
        }

        public void Remove(IllnessDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Illness illness = _mapper.Map<Illness>(entity);
            _llnessRepository.Delete(illness);
        }

        public IllnessDto Update(IllnessDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Illness illness = _mapper.Map<Illness>(entity);
            _llnessRepository.Update(illness);
            return _mapper.Map<IllnessDto>(illness);
        }

        public async Task<IllnessDto> UpdateAsync(IllnessDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Illness illness = _mapper.Map<Illness>(entity);
            await _llnessRepository.CreateOrUpdateAsync(illness);
            return _mapper.Map<IllnessDto>(illness);
        }
    }
}
