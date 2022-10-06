using Business.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class AbstractRepository<T, TKey> : IRepository<T, TKey> where T : class
    {
        private readonly object _syncRoot = new();
        protected Context _context;

        #region protected

        protected void CreateOrUpdateImplementation(T value)
        {
            var entity = ReadImplementation(KeySelector(value));
            if (entity == null) 
                CreateImplementation(value);
            else UpdateImplementation(entity, value);
        }

        protected async Task CreateOrUpdateImplementationAsync(T value)
        {
            var entity = await ReadImplementationAsync(KeySelector(value));
            if (entity == null) 
                await CreateImplementationAsync(value);
            else UpdateImplementation(entity, value);
        }

        protected void OperationEnvironment(Action body)
        {
            lock (_syncRoot)
            {

                body.Invoke();
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    ex.Entries.Single().Reload();
                    _context.SaveChanges();
                }

            }
        }

        protected TRet OperationEnvironment<TRet>(Func<TRet> body)
        {
            lock (_syncRoot)
            {
                return body.Invoke();
            }
        }

        protected async Task<TRet> OperationEnvironmentAsync<TRet>(Func<Task<TRet>> body)
        {
            return await body.Invoke();
        }

        protected async Task OperationEnvironmentAsync(Func<Task> body)
        {
            await body.Invoke();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await ex.Entries.Single().ReloadAsync();
                await _context.SaveChangesAsync();
            }
        }

        public void UpdateFields(T value, params Expression<Func<T, object>>[] includeProperties)
        {
            OperationEnvironment(() =>
            {
                var dbEntry = _context.Entry(value);
                foreach (var includeProperty in includeProperties)
                {
                    dbEntry.Property(includeProperty).IsModified = true;
                }
            });
        }

        #region abstract
        protected abstract TKey KeySelector(T value);

        protected abstract T ReadImplementation(TKey key);
        protected abstract Task<T> ReadImplementationAsync(TKey key);
        protected abstract void CreateImplementation(T value);
        protected abstract Task CreateImplementationAsync(T value);
        protected abstract void UpdateImplementation(T entity, T value);
        protected abstract void DeleteImplementation(T value);

        protected abstract IQueryable<T> QueryImplementation();
        #endregion
        #endregion

        #region inteface
        public abstract List<T> FromSqlRow(string sqlCommand);
        public abstract List<T> FromSqlInterpolated(FormattableString sqlCommand);

        public T Read(TKey key)
        {
            return OperationEnvironment(() => ReadImplementation(key));
        }

        public async Task<T> ReadAsync(TKey key)
        {
            return await OperationEnvironmentAsync(async () => await ReadImplementationAsync(key));
        }

        public void Create(T value)
        {
            OperationEnvironment(() => CreateImplementation(value));
        }

        public async Task CreateAsync(T value)
        {
            await OperationEnvironmentAsync(async () => await CreateImplementationAsync(value));
        }

        public void Update(T value)
        {
            OperationEnvironment(() => UpdateImplementation(ReadImplementation(KeySelector(value)), value));
        }

        public void CreateOrUpdate(T value)
        {
            OperationEnvironment(() => CreateOrUpdateImplementation(value));
        }

        public async Task CreateOrUpdateAsync(T value)
        {
            await OperationEnvironmentAsync(async () => await CreateOrUpdateImplementationAsync(value));
        }

        public void Delete(T value)
        {
            OperationEnvironment(() => DeleteImplementation(value));
        }

        public void Create(IEnumerable<T> values)
        {
            OperationEnvironment(() => values.ToList().ForEach(CreateImplementation));
        }

        public async Task CreateAsync(IEnumerable<T> values)
        {
            await OperationEnvironmentAsync(async () =>
            {
                foreach (var value in values)
                {
                    await CreateImplementationAsync(value);
                }
            });
        }

        public void Update(IEnumerable<T> values)
        {
            OperationEnvironment(() => values.ToList().ForEach(v => UpdateImplementation(ReadImplementation(KeySelector(v)), v)));
        }

        public void CreateOrUpdate(IEnumerable<T> values)
        {
            OperationEnvironment(() => values.ToList().ForEach(CreateOrUpdateImplementation));
        }

        public async Task CreateOrUpdateAsync(IEnumerable<T> values)
        {
            await OperationEnvironmentAsync(async () =>
            {
                foreach (var value in values)
                {
                    await CreateOrUpdateImplementationAsync(value);
                }
            });
        }

        public void Delete(IEnumerable<T> values)
        {
            OperationEnvironment(() => values.ToList().ForEach(DeleteImplementation));
        }

        public List<T> Query(Expression<Func<T, bool>> where = null)
        {
            return OperationEnvironment(() =>
            {
                var query = QueryImplementation();
                if (where != null) query = query.Where(where);
                return query.ToList();
            });
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> where = null)
        {
            return await OperationEnvironmentAsync(async () =>
            {
                var query = QueryImplementation();
                if (where != null) query = query.Where(where);
                return await query.ToListAsync();
            });
        }

        public TResult Query<TResult>(Func<IQueryable<T>, TResult> body)
        {
            return OperationEnvironment(() =>
            {
                var query = QueryImplementation();
                return body(query);
            });
        }
        #endregion
    }
}
