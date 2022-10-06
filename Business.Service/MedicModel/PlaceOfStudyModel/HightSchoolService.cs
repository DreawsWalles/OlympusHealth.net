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
            _hightSchoolRepository = hightSchoolRepository;
            _mapper = mapper;
        }

        public HightSchoolDto Create(HightSchoolDto entity)
        {
            HightSchool hightSchool = _mapper.Map<HightSchool>(entity);
            _hightSchoolRepository.Create(hightSchool);
            return _mapper.Map<HightSchoolDto>(hightSchool);
        }

        public IEnumerable<HightSchoolDto> GetAll()
        {
            return _mapper.Map<List<HightSchool>, IEnumerable<HightSchoolDto>>(_hightSchoolRepository.Query());
        }

        public HightSchoolDto GetById(Guid Id)
        {
            return _mapper.Map<HightSchoolDto>(_hightSchoolRepository.Query().FirstOrDefault(e => e.Id == Id));//Написать запрос
        }

        public void Remove(HightSchoolDto entity)
        {
            HightSchool hightSchool = _mapper.Map<HightSchool>(entity);
            _hightSchoolRepository.Delete(hightSchool);
        }

        public HightSchoolDto Update(HightSchoolDto entity)
        {
            HightSchool hightSchool = _mapper.Map<HightSchool>(entity);
            _hightSchoolRepository.Update(hightSchool);
            return _mapper.Map<HightSchoolDto>(hightSchool);
        }
    }
}
