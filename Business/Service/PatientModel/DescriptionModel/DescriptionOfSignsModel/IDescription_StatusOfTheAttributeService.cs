using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public interface IDescription_StatusOfTheAttributeService
    {
        public Description_StatusOfTheAttributeDto Create(Description_StatusOfTheAttributeDto entity);
        public Description_StatusOfTheAttributeDto Update(Description_StatusOfTheAttributeDto entity);
        public void Remove(Description_StatusOfTheAttributeDto entity);

        public IEnumerable<Description_StatusOfTheAttributeDto> GetAll();
        public Description_StatusOfTheAttributeDto GetById(Guid DescriptionId, Guid StatusOfTheAttributeId);
    }
}
