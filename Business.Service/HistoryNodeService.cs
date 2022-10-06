using AutoMapper;
using Business.Enties;
using Business.Repository.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class HistoryNodeService : IHistoryNodeService
    {
        private readonly IHistoryNodeRepository _historyNodeRepository;
        private readonly IMapper _mapper;

        public HistoryNodeService(IHistoryNodeRepository historyNodeRepository, IMapper mapper)
        {
            _historyNodeRepository = historyNodeRepository;
            _mapper = mapper;
        }

        public HistoryNode Create(HistoryNode entity)
        {
            _historyNodeRepository.Create(entity);
            return entity;
        }

        public IEnumerable<HistoryNode> GetAll()
        {
            return _historyNodeRepository.Query();
        }

        public HistoryNode? GetById(Guid Id)
        {
            return _historyNodeRepository.Query().FirstOrDefault(e => e.Id == Id); // Написать ззапрос
        }

        public void Remove(HistoryNode entity)
        {
            _historyNodeRepository.Delete(entity);
        }

        public HistoryNode Update(HistoryNode updateEntity)
        {
            _historyNodeRepository.Update(updateEntity);
            return updateEntity;
        }
    }
}
