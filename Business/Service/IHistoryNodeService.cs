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
        public IEnumerable<HistoryNode> GetAll();
        public HistoryNode? GetById(Guid Id);
    }
}
