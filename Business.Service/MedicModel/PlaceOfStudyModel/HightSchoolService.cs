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
    public class HightSchoolService : IHightSchoolService
    {
        private readonly IHightSchoolRepository _hightSchoolRepository;
        private readonly IMapper _mapper;

        public HightSchoolService(IHightSchoolRepository hightSchoolRepository, IMapper mapper)
        {
            _hightSchoolRepository = hightSchoolRepository ?? throw new ArgumentNullException(nameof(hightSchoolRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(HightSchoolDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.Street == null)
                throw new ArgumentNullException(nameof(entity.Street));
        }

        public HightSchoolDto Create(HightSchoolDto entity)
        {
            CheckEntity(entity);
            HightSchool hightSchool = _mapper.Map<HightSchool>(entity);
            _hightSchoolRepository.Create(hightSchool);
            return _mapper.Map<HightSchoolDto>(hightSchool);
        }

        public async Task<HightSchoolDto> CreateAsync(HightSchoolDto entity)
        {
            CheckEntity(entity);
            HightSchool hightSchool = _mapper.Map<HightSchool>(entity);
            await _hightSchoolRepository.CreateAsync(hightSchool);
            return _mapper.Map<HightSchoolDto>(hightSchool);
        }

        public ICollection<HightSchoolDto> GetAll()
        {
            return _mapper.Map<List<HightSchool>, ICollection<HightSchoolDto>>(_hightSchoolRepository.Query());
        }

        public async Task<ICollection<HightSchoolDto>> GetAllTask()
        {
            return _mapper.Map<List<HightSchool>, ICollection<HightSchoolDto>>(await _hightSchoolRepository.QueryAsync());
        }

        public HightSchoolDto GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            return _mapper.Map<HightSchoolDto>(_hightSchoolRepository.Query().FirstOrDefault(e => e.Id == Id));
        }

        public async Task<HightSchoolDto> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            var list = await _hightSchoolRepository.QueryAsync();
            return _mapper.Map<HightSchoolDto>(list.FirstOrDefault(e => e.Id == Id));
        }

        public void Remove(HightSchoolDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            HightSchool hightSchool = _mapper.Map<HightSchool>(entity);
            _hightSchoolRepository.Delete(hightSchool);
        }

        public HightSchoolDto Update(HightSchoolDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            HightSchool hightSchool = _mapper.Map<HightSchool>(entity);
            _hightSchoolRepository.Update(hightSchool);
            return _mapper.Map<HightSchoolDto>(hightSchool);
        }

        public async Task<HightSchoolDto> UpdateAsync(HightSchoolDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            HightSchool hightSchool = _mapper.Map<HightSchool>(entity);
            await _hightSchoolRepository.CreateOrUpdateAsync(hightSchool);
            return _mapper.Map<HightSchoolDto>(hightSchool);
        }
    }
}
