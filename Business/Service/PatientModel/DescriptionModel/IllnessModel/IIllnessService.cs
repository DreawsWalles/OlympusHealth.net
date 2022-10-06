using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.IllnessModel
{
    public interface IIllnessService
    {
        public IllnessDto Create(IllnessDto entity);
        public IllnessDto Update(IllnessDto entity);
        public void Remove(IllnessDto entity);

        public IEnumerable<IllnessDto> GetAll();
        public IllnessDto GetById(Guid Id);
    }
}
