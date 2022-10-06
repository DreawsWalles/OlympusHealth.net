using Business.Enties.PatientModel.DescriptionModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.PatientModel.DescriptionModel
{
    public class ProcessDynamicsRepository : AbstractRepository<ProcessDynamics, Guid>, IProcessDynamicsRepository
    {
        public ProcessDynamicsRepository(Context context)
        {
            _context = context;
        }

        public override List<ProcessDynamics> FromSqlInterpolated(FormattableString sqlCommand) => _context.ProcessDynamics.FromSqlInterpolated(sqlCommand).ToList();

        public override List<ProcessDynamics> FromSqlRow(string sqlCommand) => _context.ProcessDynamics.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(ProcessDynamics value)
        {
            _context.ProcessDynamics.Add(value);
        }

        protected override async Task CreateImplementationAsync(ProcessDynamics value)
        {
            await _context.ProcessDynamics.AddAsync(value);
        }

        protected override void DeleteImplementation(ProcessDynamics value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.ProcessDynamics.Remove(entity);
        }

        protected override Guid KeySelector(ProcessDynamics value) => value.Id;

        protected override IQueryable<ProcessDynamics> QueryImplementation()
        {
            return _context.ProcessDynamics;
        }

        protected override ProcessDynamics ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<ProcessDynamics> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(ProcessDynamics entity, ProcessDynamics value)
        {
            _context.Update(value);
        }
    }
}
