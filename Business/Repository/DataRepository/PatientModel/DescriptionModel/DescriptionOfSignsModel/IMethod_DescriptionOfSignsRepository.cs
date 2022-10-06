using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.DataRepository.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public interface IMethod_DescriptionOfSignsRepository : IRepository<Method_DescriptionOfSigns, Dictionary<int, Guid>> { }
}
