using AutoMapper;
using Business.Enties;
using Business.Interop;
using Business.Interop.Autefication;
using Business.Repository.DataRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Service
{
    public class SysAdminService : ISysAdminService 
    {
        private readonly ISysAdminRepository _sysAdminRepository;
        private readonly IHistoryNodeRepository _historyNodeRepository;
        private readonly IMapper _mapper;
        public SysAdminService(ISysAdminRepository sysAdminRepository, IHistoryNodeRepository historyNodeRepository, IMapper mapper)
        {
            _sysAdminRepository = sysAdminRepository ?? throw new ArgumentNullException(nameof(sysAdminRepository));
            _historyNodeRepository = historyNodeRepository ?? throw new ArgumentNullException(nameof(historyNodeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(SysAdmin sysAdmin)
        {
            if (sysAdmin == null)
                throw new ArgumentNullException(nameof(sysAdmin));
            if(sysAdmin.Login == null || sysAdmin.Login.Trim() == "")
                throw new ArgumentNullException(nameof(sysAdmin.Login));
            if(sysAdmin.Password == null || sysAdmin.Password.Trim() == "")
                throw new ArgumentNullException(nameof(sysAdmin.Password));
        }
        private static void checkEntity(RegisterModelSysAdmin entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if(entity.Login == null || entity.Login.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Login));
            if (entity.Password == null || entity.Password.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Password));
        }
        private static void checkEntity(LoginModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Login == null || entity.Login.Trim() == "" )
                throw new ArgumentNullException(nameof(entity.Login));
            if (entity.Password == null || entity.Password.Trim() == "" )
                throw new ArgumentNullException(nameof(entity.Password));
        }

        public void Accept(Guid id)
        {
            if(id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            var entity = _sysAdminRepository.Query().FirstOrDefault(x => x.Id == id);
            if(entity == null)
                throw new ArgumentException(nameof(id));
            entity.Accept = true;
            _sysAdminRepository.Update(entity);
        }

        public async Task AcceptAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            var entity = (await _sysAdminRepository.QueryAsync()).FirstOrDefault(x => x.Id == id);
            if (entity == null)
                throw new ArgumentException(nameof(id));
            entity.Accept = true;
            await _sysAdminRepository.CreateOrUpdateAsync(entity);
        }

        public SysAdminDto Create(RegisterModelSysAdmin entity)
        {
            checkEntity(entity);
            SysAdmin sysAdmin = new()
            {
                Login = entity.Login,
                Password = entity.Password,
            };
            sysAdmin.Password = new PasswordHasher<SysAdmin>().HashPassword(sysAdmin, entity.Password);
            _sysAdminRepository.Create(sysAdmin);
            return _mapper.Map<SysAdminDto>(sysAdmin);
        }

        public async Task<SysAdminDto> CreateAsync(RegisterModelSysAdmin entity)
        {
            checkEntity(entity);
            SysAdmin sysAdmin = new()
            {
                Login = entity.Login,
                Password = entity.Password,
            };
            sysAdmin.Password = new PasswordHasher<SysAdmin>().HashPassword(sysAdmin, entity.Password);
            await _sysAdminRepository.CreateAsync(sysAdmin);
            return _mapper.Map<SysAdminDto>(sysAdmin);
        }

        public SysAdminDto? FindByLogin(string login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));
            if (login.Trim() == "")
                return null;
            return _mapper.Map<SysAdminDto>(_sysAdminRepository.Query().FirstOrDefault(element => element.Login.Contains(login, StringComparison.InvariantCultureIgnoreCase)));
        }

        public async Task<SysAdminDto?> FindByLoginAsync(string login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));
            if (login.Trim() == "")
                return null;
            return _mapper.Map<SysAdminDto>((await _sysAdminRepository.QueryAsync()).FirstOrDefault(element => element.Login.Contains(login, StringComparison.InvariantCultureIgnoreCase)));
        }

        public ICollection<SysAdminDto> GetAll()
        {
            return _mapper.Map<ICollection<SysAdmin>, ICollection<SysAdminDto>>(_sysAdminRepository.Query());
        }

        public async Task<ICollection<SysAdminDto>> GetAllAsync()
        {
            return _mapper.Map<ICollection<SysAdmin>, ICollection<SysAdminDto>>(await _sysAdminRepository.QueryAsync());
        }

        public SysAdminDto? GetById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException("id");
            return _mapper.Map<SysAdminDto>(_sysAdminRepository.Query().FirstOrDefault(e => e.Id == id)); 
        }

        public async Task<SysAdminDto?> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException("id");
            var query = await _sysAdminRepository.QueryAsync();
            return _mapper.Map<SysAdminDto>(query.FirstOrDefault(e => e.Id == id));
        }

        public SysAdminDto? IsRegistered(LoginModel model)
        {
            checkEntity(model);
            SysAdmin sysAdmin = _sysAdminRepository.Query().FirstOrDefault(e => e.Login.Contains(model.Login, StringComparison.InvariantCultureIgnoreCase));
            if (sysAdmin == null)
                return null;
            var tmp = new PasswordHasher<SysAdmin>().VerifyHashedPassword(sysAdmin, sysAdmin.Password, model.Password);
            return tmp == PasswordVerificationResult.Success ? _mapper.Map<SysAdminDto>(sysAdmin) : null;
        }

        public async Task<SysAdminDto?> IsRegisteredAsync(LoginModel model)
        {
            checkEntity(model);
            var query = await _sysAdminRepository.QueryAsync();
            SysAdmin? sysAdmin = query.FirstOrDefault(e => e.Login.Contains(model.Login, StringComparison.InvariantCultureIgnoreCase));
            if (sysAdmin == null)
                return null;
            var tmp = new PasswordHasher<SysAdmin>().VerifyHashedPassword(sysAdmin, sysAdmin.Password, model.Password);
            return tmp == PasswordVerificationResult.Success ? _mapper.Map<SysAdminDto>(sysAdmin) : null;
        }

        public void Remove(SysAdminDto sysAdmin)
        {
            if (sysAdmin.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(sysAdmin.Id));
            var user = _sysAdminRepository.Query().FirstOrDefault(e => e.Id == sysAdmin.Id);
            //var histories = _historyNodeRepository.Query().Where(e => e.SysAdmin.Id == user.Id);
            //foreach (var node in histories)
            //    _historyNodeRepository.Delete(node);
            _sysAdminRepository.Delete(user);
        }

        public SysAdminDto Update(SysAdminDto updateEntity)
        {
            var user = _mapper.Map<SysAdmin>(updateEntity);
            CheckEntity(user);
            if (user.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(user.Id));
            _sysAdminRepository.Update(user);
            return _mapper.Map<SysAdminDto>(user);
        }

        public async Task<SysAdminDto> UpdateAsync(SysAdminDto updateEntity)
        {
            var user = _mapper.Map<SysAdmin>(updateEntity);
            CheckEntity(user);
            if (user.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(user.Id));
            await _sysAdminRepository.CreateOrUpdateAsync(user);
            return _mapper.Map<SysAdminDto>(user);
        }
    }
}
