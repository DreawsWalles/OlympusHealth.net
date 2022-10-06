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
            _placeOfStudyRepository = placeOfStudyRepository;
            _mapper = mapper;
        }

        public PlaceOfStudyDto Create(PlaceOfStudyDto entity)
        {
            PlaceOfStudy placeOfStudy = _mapper.Map<PlaceOfStudy>(entity);
            _placeOfStudyRepository.Create(placeOfStudy);
            return _mapper.Map<PlaceOfStudyDto>(placeOfStudy);
        }

        public PlaceOfStudyDto FindById(Guid id)
        {
            return _mapper.Map<PlaceOfStudyDto>(_placeOfStudyRepository.Query().FirstOrDefault(e => e.Id == id)); //Написать запрос
        }

        public IEnumerable<PlaceOfStudyDto> GetAll()
        {
            return _mapper.Map<List<PlaceOfStudy>, IEnumerable<PlaceOfStudyDto>>(_placeOfStudyRepository.Query());
        }

        public void Remove(PlaceOfStudyDto entity)
        {
            PlaceOfStudy placeOfStudy = _mapper.Map<PlaceOfStudy>(entity);
            _placeOfStudyRepository.Delete(placeOfStudy);
        }

        public PlaceOfStudyDto Update(PlaceOfStudyDto entity)
        {
            PlaceOfStudy placeOfStudy = _mapper.Map<PlaceOfStudy>(entity);
            _placeOfStudyRepository.Update(placeOfStudy);
            return _mapper.Map<PlaceOfStudyDto>(placeOfStudy);
        }
    }
}
