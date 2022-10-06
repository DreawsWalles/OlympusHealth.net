using Business.Interop.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel
{
    public interface IProcessDynamicsService
    {
        public ProcessDynamicsDto Create(ProcessDynamicsDto entity);
        public ProcessDynamicsDto Update(ProcessDynamicsDto entity);
        public void Remove(ProcessDynamicsDto entity);

        public IEnumerable<ProcessDynamicsDto> GetAll();
        public ProcessDynamicsDto GetById(Guid id);
    }
}
