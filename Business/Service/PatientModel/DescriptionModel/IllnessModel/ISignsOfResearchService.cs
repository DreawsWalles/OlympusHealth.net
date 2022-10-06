using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.IllnessModel
{
    public interface ISignsOfResearchService
    {
        public SignsOfResearchDto Create(SignsOfResearchDto entity);
        public SignsOfResearchDto Update(SignsOfResearchDto entity);
        public void Remove(SignsOfResearchDto entity);

        public IEnumerable<SignsOfResearchDto> GetAll();
        public SignsOfResearchDto GetById(Guid Id);
    }
}
