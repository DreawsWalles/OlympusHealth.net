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
    public class ResultIllnessService : IResultIllnessService
    {
        private readonly IResultIllnessRepository _resultIllnessRepository;
        private readonly IMapper _mapper;

        public ResultIllnessService(IResultIllnessRepository resultIllnessRepository, IMapper mapper)
        {
            _resultIllnessRepository = resultIllnessRepository ?? throw new ArgumentNullException(nameof(resultIllnessRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(ResultIllnessDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null)
                throw new ArgumentNullException(nameof(entity));
            if(entity.SignsOfResearch == null)
                throw new ArgumentNullException(nameof(entity));
        }

        public ResultIllnessDto Create(ResultIllnessDto entity)
        {
            CheckEntity(entity);
            ResultIllness resultIllness = _mapper.Map<ResultIllness>(entity);
            _resultIllnessRepository.Create(resultIllness);
            return _mapper.Map<ResultIllnessDto>(resultIllness);
        }

        public async Task<ResultIllnessDto> CreateAsync(ResultIllnessDto entity)
        {
            CheckEntity(entity);
            ResultIllness resultIllness = _mapper.Map<ResultIllness>(entity);
            await _resultIllnessRepository.CreateAsync(resultIllness);
            return _mapper.Map<ResultIllnessDto>(resultIllness);
        }

        public ICollection<ResultIllnessDto> GetAll()
        {
            return _mapper.Map<List<ResultIllness>, ICollection<ResultIllnessDto>>(_resultIllnessRepository.Query());
        }

        public async Task<ICollection<ResultIllnessDto>> GetAllAsync()
        {
            return _mapper.Map<List<ResultIllness>, ICollection<ResultIllnessDto>>(await _resultIllnessRepository.QueryAsync());
        }

        public ResultIllnessDto GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            return _mapper.Map<ResultIllnessDto>(_resultIllnessRepository.Query().FirstOrDefault(e => e.Id == Id)); 
        }

        public async Task<ResultIllnessDto> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            return _mapper.Map<ResultIllnessDto>((await _resultIllnessRepository.QueryAsync()).FirstOrDefault(e => e.Id == Id));
        }

        public void Remove(ResultIllnessDto entity)
        {
            CheckEntity(entity);
            if(entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity));
            ResultIllness resultIllness = _mapper.Map<ResultIllness>(entity);
            _resultIllnessRepository.Delete(resultIllness);
        }

        public ResultIllnessDto Update(ResultIllnessDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity));
            ResultIllness resultIllness = _mapper.Map<ResultIllness>(entity);
            _resultIllnessRepository.Update(resultIllness);
            return _mapper.Map<ResultIllnessDto>(resultIllness);
        }

        public async Task<ResultIllnessDto> UpdateAsync(ResultIllnessDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity));
            ResultIllness resultIllness = _mapper.Map<ResultIllness>(entity);
            await _resultIllnessRepository.CreateOrUpdateAsync(resultIllness);
            return _mapper.Map<ResultIllnessDto>(resultIllness);
        }
    }
}
