using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public interface IDescriptionOfSignsService
    {
        public DescriptionOfSignsDto Create(DescriptionOfSignsDto entity);
        public DescriptionOfSignsDto Update(DescriptionOfSignsDto entity);
        public void Remove(DescriptionOfSignsDto entity);

        public IEnumerable<DescriptionOfSignsDto> GetAll();
        public DescriptionOfSignsDto GetById(Guid id);
    }
}
