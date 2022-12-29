using AutoMapper;
using Business.Enties;
using Business.Repository.DataRepository;
using Npgsql.Internal;
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

        private static void CheckEntity(HistoryNode entity)
        {
            if (entity.Text == null || entity.Text.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Text));
            if (entity.SysAdmin == null && entity.Medic == null && entity.Patient == null)
                throw new ArgumentNullException($"{entity.Medic} and {entity.Medic} and {entity.Patient} can't be empty");
        }
        public HistoryNodeService(IHistoryNodeRepository historyNodeRepository)
        {
            _historyNodeRepository = historyNodeRepository ?? throw new ArgumentNullException(nameof(historyNodeRepository));
        }

        public HistoryNode Create(HistoryNode entity)
        {
            CheckEntity(entity);
            _historyNodeRepository.Create(entity);
            return entity;
        }

        public ICollection<HistoryNode> GetAll()
        {
            return _historyNodeRepository.Query();
        }

        public HistoryNode? GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            return _historyNodeRepository.Query().FirstOrDefault(e => e.Id == Id); 
        }

        public void Remove(HistoryNode entity)
        {
            CheckEntity(entity);
            if(entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            _historyNodeRepository.Delete(entity);
        }

        public HistoryNode Update(HistoryNode updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            _historyNodeRepository.Update(updateEntity);
            return updateEntity;
        }

        public async Task<HistoryNode> CreateAsync(HistoryNode entity)
        {
            CheckEntity(entity);
            await _historyNodeRepository.CreateAsync(entity);
            return entity;
        }

        public async Task<HistoryNode> UpdateAsync(HistoryNode updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            await _historyNodeRepository.CreateOrUpdateAsync(updateEntity);
            return updateEntity;
        }

        public async Task<ICollection<HistoryNode>> GetAllAsync()
        {
            return await _historyNodeRepository.QueryAsync();
        }

        public async Task<HistoryNode?> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            var query = await _historyNodeRepository.QueryAsync();
            return query.FirstOrDefault(e => e.Id == Id);
        }
    }
}
