using AutoMapper;
using Business.Enties;
using Business.Enties.MedicModel;
using Business.Enties.PatientModel;
using Business.Interop;
using Business.Interop.ChiefOfMedicineModel;
using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.MedicineRegistratorModel;
using Business.Interop.PatientModel;
using Business.Service;
using Business.Service.MedicModel;
using Business.Service.PatientModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.Controllers
{
    public class AllUsers
    {
        public List<SysAdminDto> SysAdmins { get; set; }
        public List<ChiefOfMedicine> ChiefsOfMedicine { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<HeadOfDepartment> HeadOfDepartments { get; set; }
        public List<MedicRegistrator> medicRegistrations { get; set; }
        public List<PatientDto> Patients { get; set; }
    }

    [EnableCors("CorsPolicy")]
    [Route("api/SysAdmin")]
    [ApiController]
    public class SysAdminController : ControllerBase
    {
        private readonly ISysAdminService _adminService;
        private readonly IMedicService _medicService;
        private readonly IPatientService _patientService;
        private readonly IHistoryNodeService _notification;
        private readonly IMapper _mapper;

        public SysAdminController(ISysAdminService adminService, IMedicService medicService, IPatientService patientService, IHistoryNodeService notification, IMapper mapper)
        {
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
            _medicService = medicService ?? throw new ArgumentNullException(nameof(medicService));
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            _notification = notification ?? throw new ArgumentNullException(nameof(notification));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost, Route("RemoveAllUsers")]
        public async Task<ActionResult<object>> RemoveAllUsers(string token)
        {
            if (token == null) 
                throw new ArgumentNullException(nameof(token));
            try
            {
                if(! await CheckToken(token))
                    throw new ArgumentNullException(nameof(token)); 
                var admins = await _adminService.GetAllAsync();
                foreach(var admin in admins)
                    _adminService.Remove(admin);
                var patients = await _patientService.GetAllAsync();
                foreach(var patient in patients)
                    _patientService.Remove(patient);
                var medics = await _medicService.GetAllAsync();
                foreach (var medic in medics)
                    _medicService.Remove(medic);
                return true;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private async Task<bool> CheckToken(string token)
        {
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            switch (jwt.Claims.ToList()[1].Value)
            {
                case "SysAdmin":
                    {
                        var tmp = await _adminService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                        return tmp != null;
                    }
                //case "Medic":
                //    {
                //        var tmp = await _medicService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                //        return tmp != null;
                //    }
                //case "Patient":
                //    {
                //        var tmp = await _patientService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                //        return tmp != null;
                //    }
                default:
                    return false;
            }
        }
        [HttpPost, Route("RemoveUsers")]
        public async Task<ActionResult<object>> RemoveUsers(string token, List<Guid> keys)
        {
            if (token == null)
                return BadRequest("Токен не может быть пустым");
            if (keys == null || keys.Count == 0)
                return BadRequest("Список ключей не может быть пустым");
            try
            {
                SysAdminDto? t = await _adminService.GetByIdAsync(keys[0]);
                if (!await CheckToken(token))
                    throw new ArgumentException(nameof(token));
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var tmp = await _adminService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                foreach (Guid key in keys)
                {
                    SysAdminDto? admin = await _adminService.GetByIdAsync(key);
                    Medic? medic = admin == null ? await _medicService.FindByIdAsync(key) : null;
                    PatientDto? patient = medic == null ? await _patientService.GetByIdAsync(key) : null;
                    if (admin == null && medic == null && patient == null)
                        throw new ArgumentException(nameof(keys));
                    if (admin !=null)
                    {
                        _adminService.Remove(admin);
                        await _notification.CreateAsync(new HistoryNode()
                        {
                            Text = $"Пользователь {jwt.Claims.ToList()[0].Value} удалил пользователя ${admin.Login}",
                            SysAdmin = _mapper.Map<SysAdmin>(tmp)
                        }, IHistoryNodeService.Action.Remove);
                        continue;
                    }
                    if(medic != null)
                    {
                        _medicService.Remove(medic);
                        await _notification.CreateAsync(new HistoryNode()
                        {
                            Text = $"Пользователь {jwt.Claims.ToList()[0].Value} удалил пользователя ${medic.Login}",
                            SysAdmin = _mapper.Map<SysAdmin>(tmp)
                        }, IHistoryNodeService.Action.Remove);
                        continue;
                    }
                    if(patient != null)
                    {
                        _patientService.Remove(patient);
                        await _notification.CreateAsync(new HistoryNode()
                        {
                            Text = $"Пользователь {jwt.Claims.ToList()[0].Value} удалил пользователя ${patient.Login}",
                            SysAdmin = _mapper.Map<SysAdmin>(tmp)
                        }, IHistoryNodeService.Action.Remove);
                        continue;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                BadRequest("Передан некорректный токен");
            }
            return BadRequest();
        }

        [HttpPost, Route("RemoveUserById")]
        public async Task<ActionResult<object>> RemoveUserById(string token, Guid id)
        {
            if (token == null)
                return BadRequest("Токен не может быть пустым");
            if (id.CompareTo(new Guid()) == 0)
                return BadRequest("Передан некорректный Id");
            try
            {
                if (!await CheckToken(token))
                    throw new ArgumentException(nameof(token));
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var tmp = await _adminService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                SysAdminDto? admin = await _adminService.GetByIdAsync(id);
                Medic? medic = admin == null ? await _medicService.FindByIdAsync(id) : null;
                PatientDto? patient = medic == null ? await _patientService.GetByIdAsync(id) : null;
                if (admin == null && medic == null && patient == null)
                    throw new ArgumentException(nameof(id));
                if (admin != null)
                {
                    _adminService.Remove(admin);
                    await _notification.CreateAsync(new HistoryNode()
                    {
                        Text = $"Пользователь {jwt.Claims.ToList()[0].Value} удалил пользователя ${admin.Login}",
                        SysAdmin = _mapper.Map<SysAdmin>(tmp)
                    }, IHistoryNodeService.Action.Remove);
                    return true;
                }
                if (medic != null)
                {   
                    _medicService.Remove(medic);
                    await _notification.CreateAsync(new HistoryNode()
                    {
                        Text = $"Пользователь {jwt.Claims.ToList()[0].Value} удалил пользователя ${medic.Login}",
                        SysAdmin = _mapper.Map<SysAdmin>(tmp)
                    }, IHistoryNodeService.Action.Remove);
                    return true;
                }
                if (patient != null)
                {
                    _patientService.Remove(patient);
                    await _notification.CreateAsync(new HistoryNode()
                    {
                        Text = $"Пользователь {jwt.Claims.ToList()[0].Value} удалил пользователя ${patient.Login}",
                        SysAdmin = _mapper.Map<SysAdmin>(tmp)
                    }, IHistoryNodeService.Action.Remove);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                BadRequest("Передан некорректный токен");
            }
            return BadRequest();
        }

        [HttpPost, Route("GetUsers")]
        public async Task<ActionResult<object>> GetAllUsers(string token)
        {
            if (token == null)
                return BadRequest("Токен не может быть пустым");
            try
            {
                if (!await CheckToken(token))
                    throw new ArgumentException(nameof(token));
                return new AllUsers()
                {
                    SysAdmins = (await _adminService.GetAllAsync()).ToList(),
                    ChiefsOfMedicine = _mapper.Map<ICollection<Medic>, List<ChiefOfMedicine>>((await _medicService.GetAllAsync()).Where(e => e.Role.Name == "Chief of medical").ToList()),
                    Doctors = _mapper.Map<ICollection<Medic>, List<Doctor>>((await _medicService.GetAllAsync()).Where(e => e.Role.Name == "Doctor").ToList()),
                    HeadOfDepartments = _mapper.Map<ICollection<Medic>, List<HeadOfDepartment>>((await _medicService.GetAllAsync()).Where(e => e.Role.Name == "HeadOfDepartment").ToList()),
                    medicRegistrations = _mapper.Map<ICollection<Medic>, List<MedicRegistrator>>((await _medicService.GetAllAsync()).Where(e => e.Role.Name == "MedicRegistrator").ToList()),
                    Patients =  (await _patientService.GetAllAsync()).ToList()
                };
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                BadRequest("Передан некорректный токен");
            }
            return BadRequest();
        }
        [HttpPost, Route("AcceptUser")]
        public async Task<ActionResult<object>> AcceptUser(string token, Guid id)
        {
            if (token == null)
                return BadRequest("Токен не может быть пустым");
            if (id.CompareTo(new Guid()) == 0)
                return BadRequest("Передан некорректный Id");
            try
            {
                if (!await CheckToken(token))
                    throw new ArgumentException(nameof(token));
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var tmp = await _adminService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                SysAdminDto? admin = await _adminService.GetByIdAsync(id);
                Medic? medic = admin == null ? await _medicService.FindByIdAsync(id) : null;
                if (admin == null && medic == null)
                    throw new ArgumentException(nameof(id));
                if (admin != null)
                {
                    admin.Accept = true;
                    await _adminService.AcceptAsync(id);
                    await _notification.CreateAsync(new HistoryNode()
                    {
                        Text = $"Пользователь {jwt.Claims.ToList()[0].Value} подтвердил пользователя ${admin.Login}",
                        SysAdmin = _mapper.Map<SysAdmin>(tmp)
                    }, IHistoryNodeService.Action.Remove);
                    return true;
                }
                if (medic != null)
                {
                    medic.Accept = true;
                    await _medicService.AcceptAsync(id);
                    await _notification.CreateAsync(new HistoryNode()
                    {
                        Text = $"Пользователь {jwt.Claims.ToList()[0].Value} подтвердил пользователя ${medic.Login}",
                        SysAdmin = _mapper.Map<SysAdmin>(tmp)
                    }, IHistoryNodeService.Action.Remove);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                BadRequest("Передан некорректный токен");
            }
            return BadRequest();
        }
    }
}
