using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public class Description_StatusOfTheAttributeRepository : AbstractRepository<Description_StatusOfTheAttribute, Dictionary<int,Guid>>, IDescription_StatusOfTheAttributeRepository
    {
        public Description_StatusOfTheAttributeRepository(Context context)
        {
            _context = context;
        }
        public override List<Description_StatusOfTheAttribute> FromSqlInterpolated(FormattableString sqlCommand) => _context.Description_StatusOfTheAttributes.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Description_StatusOfTheAttribute> FromSqlRow(string sqlCommand) => _context.Description_StatusOfTheAttributes.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Description_StatusOfTheAttribute value)
        {
            _context.Description_StatusOfTheAttributes.Add(value);
        }

        protected override async Task CreateImplementationAsync(Description_StatusOfTheAttribute value)
        {
            await _context.Description_StatusOfTheAttributes.AddAsync(value);
        }

        protected override void DeleteImplementation(Description_StatusOfTheAttribute value)
        {
            var entity = ReadImplementation(new Dictionary<int, Guid> { { 0, value.DescriptionId }, { 1, value.StatusOfTheAttributeId } });
            if (entity == null)
                return;
            _context.Description_StatusOfTheAttributes.Remove(entity);
        }

        protected override Dictionary<int, Guid> KeySelector(Description_StatusOfTheAttribute value) => new Dictionary<int, Guid> { { 0, value.DescriptionId }, { 1, value.StatusOfTheAttributeId } };

        protected override IQueryable<Description_StatusOfTheAttribute> QueryImplementation()
        {
            return _context.Description_StatusOfTheAttributes; //Здесь реализовать многие ко многим
        }

        protected override Description_StatusOfTheAttribute ReadImplementation(Dictionary<int, Guid> key)
        {
            return QueryImplementation().FirstOrDefault(i => i.DescriptionId == key[0] && i.StatusOfTheAttributeId == key[1]);
        }

        protected override async Task<Description_StatusOfTheAttribute> ReadImplementationAsync(Dictionary<int, Guid> key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.DescriptionId == key[0] && i.StatusOfTheAttributeId == key[1]);
        }

        protected override void UpdateImplementation(Description_StatusOfTheAttribute entity, Description_StatusOfTheAttribute value)
        {
            _context.Update(value);
        }
    }
}
