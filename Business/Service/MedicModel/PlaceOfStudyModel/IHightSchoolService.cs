using Business.Interop.PlaceOfStudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.PlaceOfStudyModel
{
    public interface IHightSchoolService
    {
        public HightSchoolDto Create(HightSchoolDto entity);
        public HightSchoolDto Update(HightSchoolDto entity);
        public void Remove(HightSchoolDto entity);

        public IEnumerable<HightSchoolDto> GetAll();
        public HightSchoolDto GetById(Guid Id);
    }
}
