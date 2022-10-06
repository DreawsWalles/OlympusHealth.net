using AutoMapper;
using Business.Enties.MedicModel;
using Business.Interop.Autefication;
using Business.Interop.ChiefOfMedicineModel;
using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.MedicineRegistratorModel;
using Business.Repository.DataRepository.MedicModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace Business.Service.MedicModel
{
    public class MedicService : IMedicService
    {
        private readonly IMedicRepository _medicRepository;
        private readonly IMapper _mapper;

        public MedicService(IMedicRepository medicRepository, IMapper mapper)
        {
            _medicRepository = medicRepository;
            _mapper = mapper;
        }

        #region
        public Medic Create(Medic entity)
        {
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
        public IEnumerable<Medic> FindByFullName(string Name)
        {
            throw new NotImplementedException();
        }

        public Medic? FindById(Guid id)
        {
            return _medicRepository.Query().FirstOrDefault(e => e.Id == id);
        }

        public Medic? FindByLogin(string login)
        {
            return _medicRepository.Query().FirstOrDefault(element => element.Login.Contains(login, System.StringComparison.InvariantCultureIgnoreCase));
        }

        public Medic? IsRegistered(LoginModel model)
        {
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

        #region Remove
        public void Remove(Medic entity)
        {
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
        #endregion
    }
}
