using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public interface IMethod_DescriptionOfSignsService
    {
        public Method_DescriptionOfSignsDto Create(Method_DescriptionOfSignsDto entity);
        public Method_DescriptionOfSignsDto Update(Method_DescriptionOfSignsDto entity);
        public void Remove(Method_DescriptionOfSignsDto entity);

        public IEnumerable<Method_DescriptionOfSignsDto> GetAll();
        public Method_DescriptionOfSignsDto GetById(Guid MethodId, Guid DescriptionOfSignsId);
    }
}
