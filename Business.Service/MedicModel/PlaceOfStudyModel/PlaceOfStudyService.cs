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
    public class PlaceOfStudyService : IPlaceOfStudyService
    {
        private readonly IPlaceOfStudyRepository _placeOfStudyRepository;
        private readonly IMapper _mapper;

        public PlaceOfStudyService(IPlaceOfStudyRepository placeOfStudyRepository, IMapper mapper)
        {
            _placeOfStudyRepository = placeOfStudyRepository ?? throw new ArgumentNullException(nameof(placeOfStudyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(PlaceOfStudy entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            DateTime currentDate = new();
            if (entity.StartEducation.Year > currentDate.Year)
                throw new ArgumentException(nameof(entity.StartEducation.Year));
            if (entity.StartEducation.Month > currentDate.Month)
                throw new ArgumentException(nameof(entity.StartEducation.Month));
            if (entity.StartEducation.Day >= currentDate.Day)
                throw new ArgumentException(nameof(entity.StartEducation.Year));
            if(entity.EndEducation != null)
            {
                var tmp = (DateTime)entity.EndEducation;
                if (tmp.Year > currentDate.Year)
                    throw new ArgumentException(nameof(tmp.Year));
                if (tmp.Month > currentDate.Month)
                    throw new ArgumentException(nameof(tmp.Month));
                if (tmp.Day >= currentDate.Day)
                    throw new ArgumentException(nameof(tmp.Year));
            }
            if (entity.Medic == null)
                throw new ArgumentNullException(nameof(entity.Medic));
            if(entity.AdvancedTrainingCourses == null && entity.HightSchools == null && entity.Interships == null && entity.Specialities == null)
                throw new ArgumentNullException($"{nameof(AdvancedTrainingCourses)} and, {nameof(entity.HightSchools)} and, {nameof(entity.Interships)} and {nameof(entity.Specialities)} can't empty");
            if(entity.Specialization == null)
                throw new ArgumentNullException(nameof(entity.Specialization));
        }

        public PlaceOfStudyDto Create(PlaceOfStudyDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            PlaceOfStudy placeOfStudy = _mapper.Map<PlaceOfStudy>(entity);
            CheckEntity(placeOfStudy);
            _placeOfStudyRepository.Create(placeOfStudy);
            return _mapper.Map<PlaceOfStudyDto>(placeOfStudy);
        }

        public async Task<PlaceOfStudyDto> CreateAsync(PlaceOfStudyDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            PlaceOfStudy placeOfStudy = _mapper.Map<PlaceOfStudy>(entity);
            CheckEntity(placeOfStudy);
            await _placeOfStudyRepository.CreateAsync(placeOfStudy);
            return _mapper.Map<PlaceOfStudyDto>(placeOfStudy);
        }

        public PlaceOfStudyDto FindById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(id));
            return _mapper.Map<PlaceOfStudyDto>(_placeOfStudyRepository.Query().FirstOrDefault(e => e.Id == id)); 
        }

        public async Task<PlaceOfStudyDto> FindByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(id));
            var list = await _placeOfStudyRepository.QueryAsync();
            return _mapper.Map<PlaceOfStudyDto>(list.FirstOrDefault(e => e.Id == id));
        }

        public ICollection<PlaceOfStudyDto> GetAll()
        {
            return _mapper.Map<List<PlaceOfStudy>, ICollection<PlaceOfStudyDto>>(_placeOfStudyRepository.Query());
        }

        public async Task<ICollection<PlaceOfStudyDto>> GetAllAsync()
        {
            return _mapper.Map<List<PlaceOfStudy>, ICollection<PlaceOfStudyDto>>(await _placeOfStudyRepository.QueryAsync());
        }

        public void Remove(PlaceOfStudyDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            PlaceOfStudy placeOfStudy = _mapper.Map<PlaceOfStudy>(entity);
            CheckEntity(placeOfStudy);
            _placeOfStudyRepository.Delete(placeOfStudy);
        }

        public PlaceOfStudyDto Update(PlaceOfStudyDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            PlaceOfStudy placeOfStudy = _mapper.Map<PlaceOfStudy>(entity);
            CheckEntity(placeOfStudy);
            _placeOfStudyRepository.Update(placeOfStudy);
            return _mapper.Map<PlaceOfStudyDto>(placeOfStudy);
        }

        public async Task<PlaceOfStudyDto> UpdateAsync(PlaceOfStudyDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            PlaceOfStudy placeOfStudy = _mapper.Map<PlaceOfStudy>(entity);
            CheckEntity(placeOfStudy);
            await _placeOfStudyRepository.CreateOrUpdateAsync(placeOfStudy);
            return _mapper.Map<PlaceOfStudyDto>(placeOfStudy);
        }
    }
}
