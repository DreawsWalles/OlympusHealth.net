using Business.Enties.MedicModel.InstitutionModel;
using Business.Enties.MedicModel.PlaceOfStudyModel;
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
    public class Corpus_MedicRepository : AbstractRepository<Corpus_Medic, Dictionary<int, Guid>>, ICorpus_MedicRepository
    {
        public Corpus_MedicRepository(Context context)
        {
            _context = context;
        }

        public override List<Corpus_Medic> FromSqlInterpolated(FormattableString sqlCommand) => _context.Corpus_Medics.FromSqlInterpolated(sqlCommand).ToList();

        public override List<Corpus_Medic> FromSqlRow(string sqlCommand) => _context.Corpus_Medics.FromSqlRaw(sqlCommand).ToList();

        protected override void CreateImplementation(Corpus_Medic value)
        {
            _context.Corpus_Medics.Add(value);
        }

        protected override async Task CreateImplementationAsync(Corpus_Medic value)
        {
            await _context.Corpus_Medics.AddAsync(value);
        }

        protected override void DeleteImplementation(Corpus_Medic value)
        {
            var entity = ReadImplementation(new Dictionary<int, Guid> { { 0, value.CorpusId }, { 1, value.MedicId } });
            if (entity == null)
                return;
            _context.Corpus_Medics.Remove(entity);
        }

        protected override Dictionary<int, Guid> KeySelector(Corpus_Medic value) => new Dictionary<int, Guid> { { 0, value.CorpusId }, { 1, value.MedicId } };

        protected override IQueryable<Corpus_Medic> QueryImplementation()
        {
            return _context.Corpus_Medics;
        }

        protected override Corpus_Medic ReadImplementation(Dictionary<int, Guid> key)
        {
            return QueryImplementation().FirstOrDefault(i => i.CorpusId == key[0] && i.MedicId == key[1]);
        }

        protected override async Task<Corpus_Medic> ReadImplementationAsync(Dictionary<int, Guid> key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(i => i.CorpusId == key[0] && i.MedicId == key[1]);
        }

        protected override void UpdateImplementation(Corpus_Medic entity, Corpus_Medic value)
        {
            _context.Update(value);
        }
    }
}
