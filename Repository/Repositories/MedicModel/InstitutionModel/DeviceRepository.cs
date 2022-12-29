using Business.Enties.MedicModel.InstitutionModel;
using Business.Repository.DataRepository.MedicModel.InstitutionModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.MedicModel.InstitutionModel
{
    public class DeviceRepository : AbstractRepository<Device, Guid>, IDeviceRepository
    {
        public DeviceRepository(Context context)
        {
            _context = context;
        }

        public override List<Device> FromSqlInterpolated(FormattableString sqlCommand) => _context.Devices.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Device> FromSqlRow(FormattableString sqlCommand) => _context.Devices.FromSql(sqlCommand).ToList();

        protected override void CreateImplementation(Device value)
        {
            _context.Devices.Add(value);
        }

        protected override async Task CreateImplementationAsync(Device value)
        {
            await _context.Devices.AddAsync(value);
        }

        protected override void DeleteImplementation(Device value)
        {
            var entity = ReadImplementation(value.Id);
            if (entity == null)
                return;
            _context.Devices.Remove(entity);
        }

        protected override Guid KeySelector(Device value) => value.Id;

        protected override IQueryable<Device> QueryImplementation()
        {
            return _context.Devices
                                .Include(e => e.Corpus)
                                    .ThenInclude(e => e.Institution)
                                 .Include(e => e.Corpus)
                                    .ThenInclude(e => e.Departments);
        }

        protected override Device ReadImplementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(i => i.Id == key);
        }

        protected override async Task<Device> ReadImplementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
        }

        protected override void UpdateImplementation(Device entity, Device value)
        {
            _context.Update(value);
        }
    }
}
