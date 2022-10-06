using Business.Enties.MedicModel.InstitutionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.DataRepository.MedicModel.InstitutionModel
{
    public interface ICorpus_MedicRepository : IRepository<Corpus_Medic, Dictionary<int, Guid>> { }
}
