using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.IllnessModel
{
    public interface IIllness_MethodService
    {
        public Illness_MethodDto Create(Illness_MethodDto entity);
        public Illness_MethodDto Update(Illness_MethodDto entity);
        public void Remove(Illness_MethodDto entity);

        public IEnumerable<Illness_MethodDto> GetAll();
        public Illness_MethodDto GetById(Guid IllnessId, Guid MethodId);
    }
}
