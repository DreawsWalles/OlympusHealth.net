using AutoMapper;
using Business.Enties.MedicModel;
using Business.Interop.Autefication;
using Business.Interop.ChiefOfMedicineModel;
using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.MedicineRegistratorModel;
using Business.Repository.DataRepository.MedicModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace Business.Service.MedicModel
{
    public class MedicService : IMedicService
    {
        private readonly IMedicRepository _medicRepository;
        private readonly IMapper _mapper;

        public MedicService(IMedicRepository medicRepository, IMapper mapper)
        {
            _medicRepository = medicRepository ?? throw new ArgumentNullException(nameof(medicRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #region check
        private static void CheckEntity(LoginModel entity)
        {
            if(entity == null) 
                throw new ArgumentNullException(nameof(entity));
            if(entity.Login == null || entity.Login == "")
                throw new ArgumentNullException(nameof(entity.Login));
            if(entity.Password == null || entity.Password == "")
                throw new ArgumentNullException(nameof(entity.Password));
        }

        private static void CheckEntity(Medic entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Login == null || entity.Login == "")
                throw new ArgumentNullException(nameof(entity.Login));
            if (entity.Password == null || entity.Password == "")
                throw new ArgumentNullException(nameof(entity.Password));
            if (entity.Name == null || entity.Name == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.Surname == null || entity.Surname == "")
                throw new ArgumentNullException(nameof(entity.Surname));
            try
            {
                if (entity.Address != null)
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
            DateTime currentDate = new();
            if (entity.DateEmployment.Year > currentDate.Year)
                throw new ArgumentException(nameof(entity.DateEmployment.Year));
            if (entity.DateEmployment.Month > currentDate.Month)
                throw new ArgumentException(nameof(entity.DateEmployment.Month));
            if (entity.DateEmployment.Day >= currentDate.Day)
                throw new ArgumentException(nameof(entity.DateEmployment.Year));
            if (entity.DateBirthday != null)
            {
                DateTime birthday = (DateTime)entity.DateBirthday;
                if (birthday.Year > currentDate.Year)
                    throw new ArgumentException(nameof(birthday.Year));
                if (birthday.Month > currentDate.Month)
                    throw new ArgumentException(nameof(birthday.Month));
                if (birthday.Day >= currentDate.Day)
                    throw new ArgumentException(nameof(birthday.Year));
            }
            if (entity.Gender == null)
                throw new ArgumentNullException(nameof(entity.Gender));
            if (entity.Role == null)
                throw new ArgumentNullException(nameof(entity.Role));
            if (entity.Address == null)
                throw new ArgumentNullException(nameof(entity.Address));
            Regex validatePhoneNumberValid = new("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
            if (entity.PhoneNumber != null && validatePhoneNumberValid.IsMatch(entity.PhoneNumber))
                throw new ArgumentException(nameof(entity.PhoneNumber));
        }
        #endregion
        #region
        public Medic Create(Medic entity)
        {
            CheckEntity(entity);
            _medicRepository.Create(entity);
            return entity;
        }

        public ChiefOfMedicine Create(ChiefOfMedicine entity)
        {
            return _mapper.Map<ChiefOfMedicine>(Create(_mapper.Map<Medic>(entity)));
        }

        public Doctor Create(Doctor entity)
        {
            return _mapper.Map<Doctor>(Create(_mapper.Map<Medic>(entity)));
        }

        public HeadOfDepartment Create(HeadOfDepartment entity)
        {
            return _mapper.Map<HeadOfDepartment>(Create(_mapper.Map<Medic>(entity)));
        }

        public MedicRegistrator Create(MedicRegistrator entity)
        {
            return _mapper.Map<MedicRegistrator>(Create(_mapper.Map<Medic>(entity)));
        }

        #endregion

        private static ICollection<Medic> FindByOneWord(string word, ICollection<Medic> list)
        {
            List<Medic> result = new();
            foreach (Medic element in list)
                if (element.Surname.Contains(word))
                    result.Add(element);
            foreach (Medic element in list)
                if (element.Name.Contains(word))
                    result.Add(element);
            foreach (Medic element in list)
                if (element.Patronymic == null || element.Patronymic.Contains(word))
                    result.Add(element);
            return result;
        }
        private static ICollection<Medic> FindByOneWordAsync(string word, ICollection<Medic> list)
        {
            List<Medic> result = new();
            Parallel.ForEach(list, element =>
            {
                if (element.Surname.Contains(word))
                    result.Add(element);
            });
            Parallel.ForEach(list, element =>
            {
                if (element.Name.Contains(word))
                    result.Add(element);
            });
            Parallel.ForEach(list, element =>
            {
                if (element.Patronymic == null || element.Patronymic.Contains(word))
                    result.Add(element);
            });
            return result;
        }


        private static ICollection<Medic> FindByTwoWord(string oneWord, string twoWord, ICollection<Medic> list)
        {
            List<Medic> result = new();
            foreach(Medic element in list)
                if(element.Surname == oneWord && element.Name == twoWord)
                    result.Add(element);
            foreach(Medic element in list)
                if(element.Name == oneWord && element.Surname == twoWord)
                    result.Add(element);
            return result;
        }
        private static ICollection<Medic> FindByTwoWordAsync(string oneWord, string twoWord, ICollection<Medic> list)
        {
            List<Medic> result = new();
            Parallel.ForEach(list, element =>
            {
                if (element.Surname == oneWord && element.Name == twoWord)
                    result.Add(element);
            });
            Parallel.ForEach(list, element =>
            {
                if (element.Name == oneWord && element.Surname == twoWord)
                    result.Add(element);
            });
            return result;
        }


        private static ICollection<Medic> FindByThreeWord(string oneWord, string twoWord, string threeWord, ICollection<Medic> list)
        {
            List<Medic> result = new();
            foreach (Medic element in list)
                if (element.Patronymic == null)
                {
                    if (element.Surname == oneWord && element.Name == twoWord)
                        result.Add(element);
                }
                else
                {
                    if (element.Surname == oneWord && element.Name == twoWord && element.Patronymic.Contains(threeWord))
                        result.Add(element);
                }
            foreach (Medic element in list)
                if (element.Patronymic == null)
                {
                    if (element.Name == oneWord)
                        result.Add(element);
                }
                else
                {
                    if (element.Name == oneWord && element.Patronymic == twoWord && element.Surname.Contains(threeWord))
                        result.Add(element);
                }
            return result;
        }

        private static ICollection<Medic> FindByThreeWordAsync(string oneWord, string twoWord, string threeWord, ICollection<Medic> list)
        {
            List<Medic> result = new();
            Parallel.ForEach(list, element =>
            {
                if (element.Patronymic == null)
                {
                    if (element.Surname == oneWord && element.Name == twoWord)
                        result.Add(element);
                }
                else
                {
                    if (element.Surname == oneWord && element.Name == twoWord && element.Patronymic.Contains(threeWord))
                        result.Add(element);
                }
            });
            Parallel.ForEach(list, element =>
            {
                if (element.Patronymic == null)
                {
                    if (element.Name == oneWord)
                        result.Add(element);
                }
                else
                {
                    if (element.Name == oneWord && element.Patronymic == twoWord && element.Surname.Contains(threeWord))
                        result.Add(element);
                }
            });
            return result;
        }



        public ICollection<Medic> FindByFullName(string Name)
        {
            if(Name == null)
                throw new ArgumentNullException(nameof(Name));
            Name = Name.Trim();
            string[] tmp = Name.Split(new char[] {' '}, System.StringSplitOptions.RemoveEmptyEntries);
            List<Medic> list = _medicRepository.Query();
            switch (tmp.Length)
            {
                default:
                    return new List<Medic>();
                case 1:
                    return FindByOneWord(tmp[0], list);
                case 2:
                    return FindByTwoWord(tmp[0], tmp[1], list);
                case 3:
                    return FindByThreeWord(tmp[0], tmp[1], tmp[2], list);
            }
        }

        public async Task<ICollection<Medic>> FindByFullNameAsync(string Name)
        {
            if (Name == null)
                throw new ArgumentNullException(nameof(Name));
            Name = Name.Trim();
            string[] tmp = Name.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            List<Medic> list = await _medicRepository.QueryAsync();
            switch (tmp.Length)
            {
                default:
                    return new List<Medic>();
                case 1:
                    return FindByOneWordAsync(tmp[0], list);
                case 2:
                    return FindByTwoWordAsync(tmp[0], tmp[1], list);
                case 3:
                    return FindByThreeWordAsync(tmp[0], tmp[1], tmp[2], list);
            }
        }

        public Medic? FindById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(id));
            return _medicRepository.Query().FirstOrDefault(e => e.Id == id);
        }

        public Medic? FindByLogin(string login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));
            if (login.Trim() == "")
                return null;
            return _medicRepository.Query().FirstOrDefault(element => element.Login.Contains(login, System.StringComparison.InvariantCultureIgnoreCase));
        }
        public async Task<Medic?> FindByLoginAsync(string login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));
            if (login.Trim() == "")
                return null;
            var users = await _medicRepository.QueryAsync();
            return users.FirstOrDefault(element => element.Login.Contains(login, System.StringComparison.InvariantCultureIgnoreCase));
        }

        public ICollection<Medic> GetAll()
        {
            return _medicRepository.Query();
        }
        public async Task<ICollection<Medic>> GetAllAsync()
        {
            return await _medicRepository.QueryAsync();
        }

        public Medic? IsRegistered(LoginModel model)
        {
            CheckEntity(model);
            var user = _medicRepository.Query()
                .FirstOrDefault(element => element.Login.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase));
            if (user != null)
            {
                var tmp = new PasswordHasher<Medic>().VerifyHashedPassword(user, user.Password, model.Password);
                return tmp == PasswordVerificationResult.Success ? user : null;
            }
            user = _medicRepository.Query()
                .FirstOrDefault(element => element.PhoneNumber.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase));
            if (user != null)
            {
                var tmp = new PasswordHasher<Medic>().VerifyHashedPassword(user, user.Password, model.Password);
                return tmp == PasswordVerificationResult.Success ? user : null;
            }
            user = _medicRepository.Query()
                .FirstOrDefault(element => element.Email.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase));
            if (user != null)
            {
                var tmp = new PasswordHasher<Medic>().VerifyHashedPassword(user, user.Password, model.Password);
                return tmp == PasswordVerificationResult.Success ? user : null;
            }
            return null;
        }

        public Task<Medic?> IsRegisteredAsync(LoginModel model)
        {
            CheckEntity(model);
            bool check = false;
            Medic? user = null;

            Parallel.Invoke
                (
                async () =>
                {
                    if (!check)
                    {
                        var usersOne = await _medicRepository.QueryAsync();
                        var userOne = usersOne.FirstOrDefault(element => element.Login.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase));
                        if (!check && usersOne != null)
                        {
                            var tmp = new PasswordHasher<Medic>().VerifyHashedPassword(userOne, userOne.Password, model.Password);
                            check = tmp == PasswordVerificationResult.Success;
                            if (check)
                                user = userOne;
                        }

                    }
                },
                async () =>
                {
                    if (!check)
                    {
                        var usersTwo = await _medicRepository.QueryAsync();
                        var userTwo = usersTwo.FirstOrDefault(element => element.PhoneNumber.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase));
                        if (!check && userTwo != null)
                        {
                            var tmp = new PasswordHasher<Medic>().VerifyHashedPassword(userTwo, userTwo.Password, model.Password);
                            check = tmp == PasswordVerificationResult.Success;
                            if (check)
                                user = userTwo;
                        }
                    }
                },
                async () =>
                {
                    if (!check)
                    {
                        var usersThree = await _medicRepository.QueryAsync();
                        var userThree = usersThree.FirstOrDefault(element => element.Email.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase));
                        if (!check && userThree != null)
                        {
                            var tmp = new PasswordHasher<Medic>().VerifyHashedPassword(userThree, userThree.Password, model.Password);
                            check = tmp == PasswordVerificationResult.Success;
                            if (check)
                                user = userThree;
                        }
                    }
                }
                );

            return Task.FromResult(user);
        }

        #region Remove
        public void Remove(Medic entity)
        {
            CheckEntity(entity);
            if(entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            _medicRepository.Delete(entity);
        }

        public void Remove(ChiefOfMedicine entity)
        {
            Remove(_mapper.Map<Medic>(entity));
        }

        public void Remove(Doctor entity)
        {
            Remove(_mapper.Map<Medic>(entity));
        }

        public void Remove(HeadOfDepartment entity)
        {
            Remove(_mapper.Map<Medic>(entity));
        }

        public void Remove(MedicRegistrator entity)
        {
            Remove(_mapper.Map<Medic>(entity));
        }
        #endregion

        #region Update

        public Medic Update(Medic entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            _medicRepository.Update(entity);
            return entity;
        }

        public ChiefOfMedicine Update(ChiefOfMedicine entity)
        {
            return _mapper.Map<ChiefOfMedicine>(Update(_mapper.Map<Medic>(entity)));
        }

        public Doctor Update(Doctor entity)
        {
            return _mapper.Map<Doctor>(Update(_mapper.Map<Medic>(entity)));
        }

        public HeadOfDepartment Update(HeadOfDepartment entity)
        {
            return _mapper.Map<HeadOfDepartment>(Update(_mapper.Map<Medic>(entity)));
        }

        public MedicRegistrator Update(MedicRegistrator entity)
        {
            return _mapper.Map<MedicRegistrator>(Update(_mapper.Map<Medic>(entity)));
        }

        public async Task<Medic> CreateAsync(Medic entity)
        {
            CheckEntity(entity);
            await _medicRepository.CreateAsync(entity);
            return entity;
        }

        public async Task<Medic> UpdateAsync(Medic entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            await _medicRepository.CreateOrUpdateAsync(entity);
            return entity;
        }

        public async Task<ChiefOfMedicine> CreateAsync(ChiefOfMedicine entity)
        {
            return _mapper.Map<ChiefOfMedicine>(await CreateAsync(_mapper.Map<Medic>(entity)));
        }

        public async Task<ChiefOfMedicine> UpdateAsync(ChiefOfMedicine entity)
        {
            return _mapper.Map<ChiefOfMedicine>(await UpdateAsync(_mapper.Map<Medic>(entity)));
        }

        public async Task<Doctor> CreateAsync(Doctor entity)
        {
            return _mapper.Map<Doctor>(await CreateAsync(_mapper.Map<Medic>(entity)));
        }

        public async Task<Doctor> UpdateAsync(Doctor entity)
        {
            return _mapper.Map<Doctor>(await UpdateAsync(_mapper.Map<Medic>(entity)));
        }

        public async Task<HeadOfDepartment> CreateAsync(HeadOfDepartment entity)
        {
            return _mapper.Map<HeadOfDepartment>(await CreateAsync(_mapper.Map<Medic>(entity)));
        }

        public async Task<HeadOfDepartment> UpdateAsync(HeadOfDepartment entity)
        {
            return _mapper.Map<HeadOfDepartment>(await UpdateAsync(_mapper.Map<Medic>(entity)));
        }

        public async Task<MedicRegistrator> CreateAsync(MedicRegistrator entity)
        {
            return _mapper.Map<MedicRegistrator>(await CreateAsync(_mapper.Map<Medic>(entity)));
        }

        public async Task<MedicRegistrator> UpdateAsync(MedicRegistrator entity)
        {
            return _mapper.Map<MedicRegistrator>(await UpdateAsync(_mapper.Map<Medic>(entity)));
        }

        #endregion
    }
}
