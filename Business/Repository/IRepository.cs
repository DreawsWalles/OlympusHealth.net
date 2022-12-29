using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public interface IRepository<T, TKey> where T : class
    {
        T Read(TKey key);
        Task<T> ReadAsync(TKey key);
        void Create(T value);
        Task CreateAsync(T value);
        void Update(T value);
        void CreateOrUpdate(T value);
        Task CreateOrUpdateAsync(T value);
        void Delete(T value);
        void UpdateFields(T value, params Expression<Func<T, object>>[] includeProperties);

        void Create(IEnumerable<T> values);
        Task CreateAsync(IEnumerable<T> values);
        void Update(IEnumerable<T> values);
        void CreateOrUpdate(IEnumerable<T> values);
        Task CreateOrUpdateAsync(IEnumerable<T> values);
        void Delete(IEnumerable<T> values);

        List<T> Query(Expression<Func<T, bool>> where = null);
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> where = null);

        TResult Query<TResult>(Func<IQueryable<T>, TResult> body);

        List<T> FromSqlRow(FormattableString sqlCommand);
        List<T> FromSqlInterpolated(FormattableString sqlCommand);
    }
}
