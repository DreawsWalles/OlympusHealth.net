using Business.Enties;
using Business.Enties.PatientModel;
using Business.Repository.DataRepository.PatientModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.PatientModel
{
    public class PatientRepository : AbstractRepository<Patient, Guid>, IPatientRepository
    {
        public PatientRepository(Context context)
        {
            _context = context;
        }
        public override List<Patient> FromSqlInterpolated(FormattableString sqlCommand)
        {
            try
            {
                var t = _context.Patients.FromSqlInterpolated(sqlCommand).ToList();
                _context.SaveChanges();
                return t;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        public override List<Patient> FromSqlRow(FormattableString sqlCommand)
        {
            try
            {
                var t = _context.Patients.FromSql(sqlCommand).ToList();
                _context.SaveChanges();
                return t;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        protected override void CreateImplementation(Patient value)
        {
            _context.Patients.Add(value);
        }

        protected override async Task CreateImplementationAsync(Patient value)
        {
            await _context.Patients.AddAsync(value);
        }

        protected override void DeleteImplementation(Patient value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Patients.Remove(entity);
        }

        protected override Guid KeySelector(Patient value) => value.Id;

        //прописать подтягивание описания
        protected override IQueryable<Patient> QueryImplementation()
        {
            return _context.Patients
                            .Include(e => e.Gender)
                            .Include(e => e.HistoryNodes)
                            .Include(e => e.OutpatientCards)
                            .Include(e => e.ResearchAreas)
                                .ThenInclude(e => e.Descriptions)
                                    .ThenInclude(e => e.Doctor)
                             .Include(e => e.ResearchAreas)
                                .ThenInclude(e => e.Descriptions)
                                    .ThenInclude(e => e.Device)
                              .Include(e => e.ResearchAreas)
                                .ThenInclude(e => e.Descriptions)
                                    .ThenInclude(e => e.ProcessDynamics)
                              .Include(e => e.ResearchAreas)
                                .ThenInclude(e => e.Descriptions)
                                    .ThenInclude(e => e.ResultIllness)
                                        .ThenInclude(e => e.SignsOfResearch)
                                            .ThenInclude(e => e.Illness)
                                                .ThenInclude(e=> e.Methods)//здесь через вспомогательную таблицу
                                                    .ThenInclude(e => e.RadiationDose)
                               .Include(e => e.ResearchAreas)
                                .ThenInclude(e => e.Descriptions)
                                    .ThenInclude(e => e.StatusOfTheAttributes) //здесь через вспомогательную таблицу
                                        .ThenInclude(e => e.DescriptionOfSigns)
                                            .ThenInclude(e => e.Methods) //здесь через вспомогательную таблицу
                                                .ThenInclude(e => e.ResearchCategory)
                                .Include(e => e.ResearchAreas)
                                    .ThenInclude(e => e.Descriptions)
                                        .ThenInclude(e => e.HeadOfDepartment); 
        }

        protected override Patient ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Patient> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Patient entity, Patient value)
        {
            _context.Update(value);
        }
    }
}
