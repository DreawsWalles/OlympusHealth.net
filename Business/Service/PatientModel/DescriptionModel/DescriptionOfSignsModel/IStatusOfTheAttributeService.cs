using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public interface IStatusOfTheAttributeService
    {
        public StatusOfTheAttributeDto Create(StatusOfTheAttributeDto entity);
        public StatusOfTheAttributeDto Update(StatusOfTheAttributeDto entity);
        public void Remove(StatusOfTheAttributeDto entity);

        public IEnumerable<StatusOfTheAttributeDto> GetAll();
        public StatusOfTheAttributeDto GetById(Guid Id);
    }
}
