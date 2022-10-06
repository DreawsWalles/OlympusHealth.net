using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.DataRepository.PatientModel.DescriptionModel.IllnessModel
{
    public interface IIllness_MethodRepository : IRepository<Illness_Method, Dictionary<int,Guid>> { }
}
