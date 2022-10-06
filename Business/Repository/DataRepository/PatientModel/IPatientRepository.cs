using Business.Enties.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.DataRepository.PatientModel
{
    public interface IPatientRepository : IRepository<Patient, Guid> { }
}
