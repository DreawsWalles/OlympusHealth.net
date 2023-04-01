using Business.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IHistoryNodeService
    {
        public enum Action
        {
            Auntification = 0,
            Create = 1,
            Remove = 2
        }
        public HistoryNode Create(HistoryNode entity, Action action);
        public HistoryNode Update(HistoryNode updateEntity);
        public void Remove(HistoryNode entity);
        public ICollection<HistoryNode> GetAll();
        public ICollection<HistoryNode> GetByLogin(string login, string role);
        public HistoryNode? GetById(Guid Id);

        public Task<HistoryNode> CreateAsync(HistoryNode entity, Action action);
        public Task<HistoryNode> UpdateAsync(HistoryNode updateEntity);
        public Task<ICollection<HistoryNode>> GetAllAsync();
        public Task<ICollection<HistoryNode>> GetByLoginAsync(string login, string role);
        public Task<HistoryNode?> GetByIdAsync(Guid Id);
    }
}
