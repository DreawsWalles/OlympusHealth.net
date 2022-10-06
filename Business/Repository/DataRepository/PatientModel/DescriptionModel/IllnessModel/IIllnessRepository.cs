using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.DataRepository.PatientModel.DescriptionModel.IllnessModel
{
    public interface IIllnessRepository : IRepository<Illness, Guid> { }
}
