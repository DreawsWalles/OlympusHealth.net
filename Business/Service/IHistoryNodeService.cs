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
        public HistoryNode Create(HistoryNode entity);
        public HistoryNode Update(HistoryNode updateEntity);
        public void Remove(HistoryNode entity);
        public ICollection<HistoryNode> GetAll();
        public HistoryNode? GetById(Guid Id);

        public Task<HistoryNode> CreateAsync(HistoryNode entity);
        public Task<HistoryNode> UpdateAsync(HistoryNode updateEntity);
        public Task<ICollection<HistoryNode>> GetAllAsync();
        public Task<HistoryNode?> GetByIdAsync(Guid Id);
    }
}
