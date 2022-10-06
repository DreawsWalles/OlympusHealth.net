using Business.Interop.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel
{
    public interface IRadiationDoseService
    {
        public RadiationDoseDto Create(RadiationDoseDto entity);
        public RadiationDoseDto Update(RadiationDoseDto entity);
        public void Remove(RadiationDoseDto entity);

        public IEnumerable<RadiationDoseDto> GetAll();
        public RadiationDoseDto GetById(Guid id);
    }
}
