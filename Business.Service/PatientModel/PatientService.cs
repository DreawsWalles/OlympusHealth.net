using AutoMapper;
using Business.Enties;
using Business.Enties.MedicModel;
using Business.Enties.PatientModel;
using Business.Interop;
using Business.Interop.Autefication;
using Business.Interop.PatientModel;
using Business.Repository.DataRepository;
using Business.Repository.DataRepository.PatientModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Service.PatientModel
{ 
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;

        public PatientService(IPatientRepository patientRepository, IMapper mapper, IGenderRepository genderRepository)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _genderRepository = genderRepository ?? throw new ArgumentNullException(nameof(genderRepository));
        }
        private static void CheckEntity(LoginModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Login == null || entity.Login == "")
                throw new ArgumentNullException(nameof(entity.Login));
            if (entity.Password == null || entity.Password == "")
                throw new ArgumentNullException(nameof(entity.Password));
        }
        private static void CheckEntity(PatientDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Login == null || entity.Login.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Login));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.Surname == null || entity.Surname.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Surname));
            try
            {
                if(entity.Email != null)
                {
                    var Address = new System.Net.Mail.MailAddress(entity.Email);
                    if (Address.Address != entity.Email)
                        throw new ArgumentException(nameof(entity.Email));
                }
            }
            catch
            {
                throw new ArgumentException(nameof(entity.Email));
            }
            if (entity.Birthday != null)
            {
                DateTime birthday = (DateTime)entity.Birthday;
                if (birthday.CompareTo(DateTime.Now) >= 0)
                    throw new ArgumentException(nameof(entity.Birthday));
            }
            Regex validatePhoneNumberValid = new("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
            if (entity.PhoneNumber != null && !validatePhoneNumberValid.IsMatch(entity.PhoneNumber))
                throw new ArgumentException(nameof(entity.PhoneNumber));
            if(entity.Gender == null)
                throw new ArgumentNullException(nameof(entity.Gender));
        }
        private static void CheckEntity(RegisterModelUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Login == null || entity.Login.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Login));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.Surname == null || entity.Surname.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Surname));
            try
            {
                if (entity.Email != null && entity.Email.Trim() != "")
                {
                    var Address = new System.Net.Mail.MailAddress(entity.Email);
                    if (Address.Address != entity.Email)
                        throw new ArgumentException(nameof(entity.Email));
                }
            }
            catch
            {
                throw new ArgumentException(nameof(entity.Email));
            }
            if (entity.Birthday != null)
            {
                DateTime birthday = (DateTime)entity.Birthday;
                if (birthday.CompareTo(DateTime.Now) >= 0)
                    throw new ArgumentException(nameof(entity.Birthday));
            }
            Regex validatePhoneNumberValid = new("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
            if (entity.PhoneNumber != null && entity.PhoneNumber != "" && !validatePhoneNumberValid.IsMatch(entity.PhoneNumber))
                throw new ArgumentException(nameof(entity.PhoneNumber));
            if (entity.Gender == null)
                throw new ArgumentNullException(nameof(entity.Gender));
        }

        public PatientDto Create(RegisterModelUser entity)
        {
            CheckEntity(entity);
            Patient patient = new()
            {
                Login = entity.Login,
                Password = entity.Password,
                Name = entity.Name,
                Surname = entity.Surname,
                Patronymic = entity.Patronymic.Trim() == "" ? null : entity.Patronymic,
                Email = entity?.Email.Trim() == "" ? null : entity.Email,
                PhoneNumber = entity?.PhoneNumber.Trim() == "" ? null : entity.PhoneNumber,
                Birthday = entity?.Birthday,
            };
            Gender? gender = _genderRepository.Query().FirstOrDefault(e => e.Id == entity.Gender.Id);
            if (gender == null)
                return null;
            patient.Gender = gender; 
            patient.Password = new PasswordHasher<Patient>().HashPassword(patient, entity.Password);
            _patientRepository.CreateOrUpdate(patient);
            return _mapper.Map<PatientDto>(patient);
        }

        public ICollection<PatientDto> GetAll()
        {
            return _mapper.Map<List<Patient>, ICollection<PatientDto>>(_patientRepository.Query());
        }

        public PatientDto GetById(Guid id)
        {
            if(id.CompareTo(new Guid()) == 0)
                throw new ArithmeticException(nameof(id));
            return _mapper.Map<PatientDto>(_patientRepository.Query().FirstOrDefault(e => e.Id == id));
        }

        public void Remove(PatientDto entity)
        {
            CheckEntity(entity);
            if(entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Patient patient = _mapper.Map<Patient>(entity);
            _patientRepository.Delete(patient);
        }

        public PatientDto Update(PatientDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Patient patient = _mapper.Map<Patient>(entity);
            _patientRepository.Update(patient);
            return _mapper.Map<PatientDto>(patient);
        }

        public PatientDto? IsRegistered(LoginModel model)
        {
            CheckEntity(model);
            var user = _patientRepository.Query()
                .FirstOrDefault(element => element.Login.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase));
            if (user != null)
            {
                var tmp = new PasswordHasher<Patient>().VerifyHashedPassword(user, user.Password, model.Password);
                return _mapper.Map<PatientDto>(tmp == PasswordVerificationResult.Success ? user : null);
            }
            user = _patientRepository.Query()
                .FirstOrDefault(element =>
                {
                    if (element.PhoneNumber != null)
                        return element.PhoneNumber.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase);
                    return false;
                });
            if (user != null)
            {
                var tmp = new PasswordHasher<Patient>().VerifyHashedPassword(user, user.Password, model.Password);
                return _mapper.Map<PatientDto>(tmp == PasswordVerificationResult.Success ? user : null);
            }
            user = _patientRepository.Query()
                .FirstOrDefault(element =>
                {
                    if (element.Email != null)
                        return element.Email.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase);
                    return false;
                });
            if (user != null)
            {
                var tmp = new PasswordHasher<Patient>().VerifyHashedPassword(user, user.Password, model.Password);
                return _mapper.Map<PatientDto>(tmp == PasswordVerificationResult.Success ? user : null);
            }
            return null;
        }

        public async Task<PatientDto> CreateAsync(RegisterModelUser entity)
        {
            CheckEntity(entity);
            Patient patient = new()
            {
                Login = entity.Login,
                Password = entity.Password,
                Name = entity.Name,
                Surname = entity.Surname,
                Patronymic = entity.Patronymic.Trim() == "" ? null : entity.Patronymic,
                Email = entity?.Email.Trim() == "" ? null : entity.Email,
                PhoneNumber = entity?.PhoneNumber.Trim() == "" ? null : entity.PhoneNumber,
                Birthday = entity?.Birthday,
            };
            Gender? gender = (await _genderRepository.QueryAsync()).FirstOrDefault(e => e.Id == entity.Gender.Id);
            if (gender == null)
                return null;
            patient.Gender = gender;
            patient.Password = new PasswordHasher<Patient>().HashPassword(patient, entity.Password);
            await _patientRepository.CreateOrUpdateAsync(patient);
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto> UpdateAsync(PatientDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Patient patient = _mapper.Map<Patient>(entity);
            await _patientRepository.CreateOrUpdateAsync(patient);
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<ICollection<PatientDto>> GetAllAsync()
        {
            return _mapper.Map<List<Patient>, ICollection<PatientDto>>(await _patientRepository.QueryAsync());
        }

        public async Task<PatientDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArithmeticException(nameof(id));
            var list = await _patientRepository.QueryAsync();
            return _mapper.Map<PatientDto>(list.FirstOrDefault(e => e.Id == id));
        }

        public async Task<PatientDto?> IsRegisteredAsync(LoginModel model)
        {
            CheckEntity(model);
            var user = (await _patientRepository.QueryAsync())
                .FirstOrDefault(element => element.Login.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase));
            if (user != null)
            {
                var tmp = new PasswordHasher<Patient>().VerifyHashedPassword(user, user.Password, model.Password);
                return _mapper.Map<PatientDto>(tmp == PasswordVerificationResult.Success ? user : null);
            }
            user = (await _patientRepository.QueryAsync())
                .FirstOrDefault(element =>
                {
                    if(element.PhoneNumber != null)
                        return element.PhoneNumber.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase);
                    return false;
                });
            if (user != null)
            {
                var tmp = new PasswordHasher<Patient>().VerifyHashedPassword(user, user.Password, model.Password);
                return _mapper.Map<PatientDto>(tmp == PasswordVerificationResult.Success ? user : null);
            }
            user = (await _patientRepository.QueryAsync())
                .FirstOrDefault(element =>
                {
                    if(element.Email != null)
                        return element.Email.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase);
                    return false;
                });
            if (user != null)
            {
                var tmp = new PasswordHasher<Patient>().VerifyHashedPassword(user, user.Password, model.Password);
                return _mapper.Map<PatientDto>(tmp == PasswordVerificationResult.Success ? user : null);
            }
            return null;
        }

        public PatientDto? FindByLogin(string login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));
            if (login.Trim() == "")
                return null;
            return _mapper.Map<PatientDto>(_patientRepository.Query().FirstOrDefault(element => element.Login.Contains(login, StringComparison.InvariantCultureIgnoreCase)));
        }

        public async Task<PatientDto?> FindByLoginAsync(string login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));
            if (login.Trim() == "")
                return null;
            return _mapper.Map<PatientDto>((await _patientRepository.QueryAsync()).FirstOrDefault(element => element.Login.Contains(login, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}
