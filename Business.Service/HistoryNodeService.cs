using AutoMapper;
using Business.Enties;
using Business.Enties.MedicModel;
using Business.Repository.DataRepository;
using Business.Repository.DataRepository.MedicModel;
using Business.Repository.DataRepository.PatientModel;
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
        public enum Action
        {
            Auntification = 0,
            Create = 1
        }
        private readonly IHistoryNodeRepository _historyNodeRepository;
        private readonly ISysAdminRepository _sysAdminRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMedicRepository _medicRepository;

        private static void CheckEntity(HistoryNode entity)
        {
            if (entity.Text == null || entity.Text.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Text));
            if (entity.SysAdmin == null && entity.Medic == null && entity.Patient == null)
                throw new ArgumentNullException($"{entity.Medic} and {entity.Medic} and {entity.Patient} can't be empty");
        }
        public HistoryNodeService(IHistoryNodeRepository historyNodeRepository, ISysAdminRepository sysAdminRepository, IPatientRepository patientRepository, IMedicRepository medicRepository)
        {
            _historyNodeRepository = historyNodeRepository ?? throw new ArgumentNullException(nameof(historyNodeRepository));
            _sysAdminRepository = sysAdminRepository ?? throw new ArgumentNullException(nameof(sysAdminRepository));
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(_patientRepository));
            _medicRepository = medicRepository ?? throw new ArgumentNullException(nameof(medicRepository));
        }

        public HistoryNode Create(HistoryNode entity, IHistoryNodeService.Action action)
        {
            CheckEntity(entity);
            List<SysAdmin> admins = _sysAdminRepository.Query();
            if(action == 0)
            {
                var tmp = new HistoryNode();
                tmp.Text = $"Вы вошли в приложение в {tmp.DateCreation}";
                if (entity.Patient != null)
                    tmp.Patient = _patientRepository.Query().First(e => e.Id == entity.Patient.Id);
                tmp.Medic = entity.Medic;
                tmp.SysAdmin = entity.SysAdmin;
                _historyNodeRepository.Create(tmp);
            }
            foreach (var admin in admins)
                _historyNodeRepository.Create(new HistoryNode()
                {
                    Text = entity.Text,
                    SysAdmin = admin
                });
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

        public async Task<HistoryNode>CreateAsync(HistoryNode entity, IHistoryNodeService.Action action)
        {
            CheckEntity(entity);
            List<SysAdmin> admins = await _sysAdminRepository.QueryAsync();
            switch(action)
            {
                case IHistoryNodeService.Action.Auntification:
                    {
                        var tmp = new HistoryNode();
                        tmp.Text = $"Вы вошли в приложение в {tmp.DateCreation}";
                        if (entity.Patient != null)
                            tmp.Patient = (await _patientRepository.QueryAsync()).First(e => e.Id == entity.Patient.Id);
                        if (entity.Medic != null)
                            tmp.Medic = _medicRepository.Query().FirstOrDefault(e => e.Id == entity.Medic.Id);
                        if (entity.SysAdmin != null)
                            tmp.SysAdmin = admins.FirstOrDefault(e => e.Id == entity.SysAdmin?.Id);
                        await _historyNodeRepository.CreateAsync(tmp);
                        foreach (var admin in admins)
                            await _historyNodeRepository.CreateAsync(new HistoryNode()
                            {
                                Text = entity.Text,
                                SysAdmin = admin
                            });
                    }
                    break;
                case IHistoryNodeService.Action.Create:
                    {
                        var tmp = new HistoryNode();
                        tmp.Text = $"Вы вошли зарегистрированы в приложениии в {tmp.DateCreation}";
                        if (entity.Patient != null)
                            tmp.Patient = (await _patientRepository.QueryAsync()).First(e => e.Id == entity.Patient.Id);
                        if (entity.Medic != null)
                            tmp.Medic = _medicRepository.Query().FirstOrDefault(e => e.Id == entity.Medic.Id);
                        if (entity.SysAdmin != null)
                            tmp.SysAdmin = admins.FirstOrDefault(e => e.Id == entity.SysAdmin?.Id);
                        await _historyNodeRepository.CreateAsync(tmp);
                        foreach (var admin in admins)
                            await _historyNodeRepository.CreateAsync(new HistoryNode()
                            {
                                Text = entity.Text,
                                SysAdmin = admin
                            });
                    }
                    break;
                case IHistoryNodeService.Action.Remove:
                    {
                        foreach(var admin in admins)
                            await _historyNodeRepository.CreateAsync(new HistoryNode()
                            {
                                Text = entity.Text,
                                SysAdmin = admin
                            });
                    }
                    break;

            }
            
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

        public ICollection<HistoryNode> GetByLogin(string login, string role)
        {
            if(login == null)
                throw new ArgumentNullException(nameof(login));
            if(role == null)
                throw new ArgumentNullException(nameof(role));
            switch(role)
            {
                case "Patient":
                    return _historyNodeRepository.Query().Where(e => e.Patient != null &&  e.Patient.Login.Contains(login, StringComparison.InvariantCultureIgnoreCase)).ToList();
                case "Medic":
                    return _historyNodeRepository.Query().Where(e => e.Medic != null && e.Medic.Login.Contains(login, StringComparison.InvariantCultureIgnoreCase)).ToList();
                case "SysAdmin":
                    return _historyNodeRepository.Query().Where(e => e.SysAdmin != null && e.SysAdmin.Login.Contains(login, StringComparison.InvariantCultureIgnoreCase)).ToList();
                default:
                    return new List<HistoryNode>();
            }
        }

        public async Task<ICollection<HistoryNode>> GetByLoginAsync(string login, string role)
        {

            if (login == null)
                throw new ArgumentNullException(nameof(login));
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            switch (role)
            {
                case "Patient":
                    return (await _historyNodeRepository.QueryAsync()).Where(e => e.Patient != null && e.Patient.Login.Contains(login, StringComparison.InvariantCultureIgnoreCase)).ToList();
                case "Medic":
                    return (await _historyNodeRepository.QueryAsync()).Where(e => e.Medic != null && e.Medic.Login.Contains(login, StringComparison.InvariantCultureIgnoreCase)).ToList();
                case "SysAdmin":
                    return (await _historyNodeRepository.QueryAsync()).Where(e => e.SysAdmin != null && e.SysAdmin.Login.Contains(login, StringComparison.InvariantCultureIgnoreCase)).ToList();
                default:
                    return new List<HistoryNode>();
            }
        }
    }
}
