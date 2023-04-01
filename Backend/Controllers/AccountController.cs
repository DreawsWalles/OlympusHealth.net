using Business.Service.MedicModel;
using Business.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Interop.Autefication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Cors;
using Business.Service.PatientModel;
using Business.Enties.MedicModel;
using System.Text.RegularExpressions;
using Business.Interop.PatientModel;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using XSystem.Security.Cryptography;
using Business.Interop.Address;
using Business.Interop.DoctorModel;
using Business.Interop.HeadOfDepartmentModel;
using Business.Interop.MedicineRegistratorModel;
using Business.Interop.ChiefOfMedicineModel;
using Business.Enties.Address;
using MimeKit;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Business.Enties;
using Business.Enties.PatientModel;
using Business.Interop;
using AutoMapper;

namespace Backend.Controllers
{
    public class Answer
    {
        public string Message { get; set; }
    }
    public class TokenRole
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }

    public static class AuthOptions
    {
        public static string ISSUER { get; set; } = "MyAuthServer";
        public static string AUDIENCE { get; set; } = "MyAuthCkeint";
        const string KEY = "mysupersecret_secretkey!123";
        public const int LIFETIME = 60;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

    }

    [EnableCors("CorsPolicy")]
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISysAdminService _adminService;
        private readonly IMedicService _medicService;
        private readonly IPatientService _patientService;
        private readonly IHistoryNodeService _notification;
        private readonly IMapper _mapper;

        public AccountController(ISysAdminService adminService, IMedicService medicService, IPatientService patientService, IHistoryNodeService historyNodeService, IMapper mapper)
        {
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
            _medicService = medicService ?? throw new ArgumentNullException(nameof(medicService));
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            _notification = historyNodeService ?? throw new ArgumentNullException(nameof(historyNodeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        
        [HttpPost, Route("Login")]
        public async Task<ActionResult<object>> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                SysAdminDto admin;
                Medic medic;
                PatientDto patient;
                if ((admin = await _adminService.IsRegisteredAsync(model)) != null)
                {
                    model.Role = "SysAdmin";
                    try
                    {
                        await _notification.CreateAsync(new HistoryNode()
                        {
                            Text = $"Пользователь {admin.Login} авторизовался в приложении",
                            SysAdmin = _mapper.Map<SysAdmin>(admin)
                        }, IHistoryNodeService.Action.Auntification);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return token(new LoginModel() { Login = model.Login, Password = model.Password });
                }
                if ((medic = await _medicService.IsRegisteredAsync(model)) != null)
                {
                    model.Role = "Medic";
                    await _notification.CreateAsync(new HistoryNode()
                    {
                        Text = $"Пользователь {medic.Login} авторизовался в приложении",
                        Medic = medic
                    }, IHistoryNodeService.Action.Auntification);
                    return token(new LoginModel() { Login = model.Login, Password = model.Password });
                }
                if ((patient = await _patientService.IsRegisteredAsync(model)) != null)
                {
                    model.Role = "Patient";
                    await _notification.CreateAsync(new HistoryNode()
                    {
                        Text = $"Пользователь {patient.Login} авторизовался в приложении",
                        Patient = new Patient()
                        {
                            Id = patient.Id
                        }
                    }, IHistoryNodeService.Action.Auntification);
                    return token(new LoginModel() { Login = model.Login, Password = model.Password }); 
                }
                return NotFound(model);
            }
            ModelState.AddModelError("Error", "Неверный логин и(или) пароль");
            return BadRequest(model);
        }

        private async Task<bool> checkLogin(string login)
        {
            var admins = await _adminService.GetAllAsync();
            foreach (var admin in admins)
                if (admin.Login == login)
                    return true;
            var medics = await _medicService.GetAllAsync();
            foreach (var medic in medics)
                if (medic.Login == login)
                    return true;
            var patients = await _patientService.GetAllAsync();
            foreach (var patient in patients)
                if (patient.Login == login)
                    return true;
            return false;
        }

        [HttpPost, Route("CheckLogin")]
        public async Task<ActionResult<bool>> CheckLogin(string login)
        {
            if (ModelState.IsValid)
            {
                return await checkLogin(login) ? true : NotFound(login);
            }
            return BadRequest("Переданы некорректные данные");
                      
        }
        private static bool isValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> checkEmail(string email, string role)
        {
            switch (role)
            {
                case "medic":
                    var medics = await _medicService.GetAllAsync();
                    foreach (var medic in medics)
                        if (medic.Email == email)
                            return true;
                    return false;
                case "patient":
                    var patients = await _patientService.GetAllAsync();
                    foreach (var patient in patients)
                        if (patient.Email == email)
                            return true;
                    return false;
                default:
                    return false;
            }
        }

        [HttpPost, Route("CheckEmail")]
        public async Task<ActionResult<bool>> CheckEmail(string email, string role)
        {
            if (ModelState.IsValid)
            {
                if (!isValidEmail(email))
                    return BadRequest("Переданы некорректные данные");
                return await checkEmail(email, role) ? true : NotFound(email);
            }
            return BadRequest("Переданы некорректные данные");
        }

        private static bool isValidPhoneNumber(string phoneNumber)
        {
            var trimPhoneNumber = phoneNumber.Trim();
            Regex validatePhoneNumberValid = new("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
            return validatePhoneNumberValid.IsMatch(trimPhoneNumber);
        }
        private async Task<bool> checkPhoneNumber(string phoneNumber, string role)
        {
            switch (role)
            {
                case "medic":
                    var medics = await _medicService.GetAllAsync();
                    foreach (var medic in medics)
                        if (medic.PhoneNumber == phoneNumber)
                            return true;
                    return false;
                case "patient":
                    var patients = await _patientService.GetAllAsync();
                    foreach (var patient in patients)
                        if (patient.PhoneNumber == phoneNumber)
                            return true;
                    return false;
                default:
                    return false;
            }
        }

        [HttpPost, Route("CheckPhoneNumber")]
        public async Task<ActionResult<bool>> CheckPhoneNumber(string phoneNumber, string role)
        {
            if(ModelState.IsValid)
            {
                if (!isValidPhoneNumber(phoneNumber))
                    return BadRequest("Переданы некорректные данные");
                return await checkPhoneNumber(phoneNumber, role) ? true : NotFound(phoneNumber);
            }
            return BadRequest("Переданы некорректные данные");      
        }

        private static bool isValidDate(string date)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(date);
                return dateTime.CompareTo(DateTime.Now) < 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        private static bool IsValidAddress(RegisterModelUser entity)
        {
            if(entity == null) 
                return false;
            if (entity.Country == null && entity.Region == null && entity.City == null && entity.Street?.Name == null && entity.Street?.NumberOfHouse == null)
                return true;
            if(entity.Country != null && entity.Region != null && entity.City != null && entity.Street?.Name != null && entity.Street?.NumberOfHouse != null) 
                return true;
            return false;
        }

        [HttpPost, Route("RegisterSysAdmin")]
        public async Task<ActionResult<object>> RegisterUser(RegisterModelSysAdmin entity)
        {
            if(ModelState.IsValid)
            {
                if (await checkLogin(entity.Login))
                    return NotFound("Пользователь с таким логином уже существует");
                try
                {
                    var user = await _adminService.CreateAsync(entity);
                    await _notification.CreateAsync(new HistoryNode()
                    {
                        Text = $"Зарегистритован пользователь {user.Login}",
                        SysAdmin = _mapper.Map<SysAdmin>(user)
                    }, IHistoryNodeService.Action.Create);
                    var result = token(new LoginModel() { Login = entity.Login, Password = entity.Password });
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest("Не удалось зарегистрировать пользователя");
                }
            }
            return BadRequest("Переданы некорректные данные");
        }

        [HttpPost, Route("RegisterUser")]
        public async Task<ActionResult<object>> RegisterUser(RegisterModelUser registerModelUser)
        {
            if(ModelState.IsValid)
            {
                if (await checkLogin(registerModelUser.Login))
                    return NotFound("Пользователь с таким логином уже существует");
                if (registerModelUser.Email != "" && !isValidEmail(registerModelUser.Email))
                    return BadRequest("Переданы некорректные данные");
                if (registerModelUser.Email != "" && await checkEmail(registerModelUser.Email, registerModelUser.Role))
                    return NotFound("Пользоатель с таким email уже существует");
                if (registerModelUser.PhoneNumber != "" && !isValidPhoneNumber(registerModelUser.PhoneNumber))
                    return BadRequest("Переданны некорректые данные");
                if (registerModelUser.PhoneNumber != "" && await checkPhoneNumber(registerModelUser.PhoneNumber, registerModelUser.Role))
                    return NotFound("Пользователь с таким номером телефона уже существует");
                if (registerModelUser.Birthday != null && !isValidDate(registerModelUser.Birthday.ToString()))
                    return BadRequest("Переданы некорректные данные");
                if(!IsValidAddress(registerModelUser))
                    return BadRequest("Переданы некорректные данные");
                switch (registerModelUser.Role)
                {
                    case "patient":
                        try
                        {
                            var user = await _patientService.CreateAsync(registerModelUser);
                            var result = token(new LoginModel() { Login = registerModelUser.Login, Password = registerModelUser.Password });
                            await _notification.CreateAsync(new HistoryNode()
                            {
                                Text = $"Зарегистрирован пользователь {user.Login}",
                                Patient = new Patient()
                                {
                                    Id = user.Id
                                }
                            }, IHistoryNodeService.Action.Create);
                            if (registerModelUser.Email != null)
                                SendMessage($"Логин: ${registerModelUser.Login}, Пароль:{registerModelUser.Password}", registerModelUser.Email);
                            return result;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return BadRequest("Не удалось зарегистрировать пользователя");
                        }
                    case "medic":
                        try
                        {
                            var user = await _medicService.CreateAsync(registerModelUser);
                            var result = token(new LoginModel() { Login = registerModelUser.Login, Password = registerModelUser.Password });
                            await _notification.CreateAsync(new HistoryNode()
                            {
                                Text = $"Зарегистрирован пользователь {user.Login}",
                                Medic = user
                            }, IHistoryNodeService.Action.Create);
                            if (registerModelUser.Email != null)
                                SendMessage($"Логин: ${registerModelUser.Login}, Пароль:{registerModelUser.Password}", registerModelUser.Email);
                            return result;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return BadRequest("Не удалось зарегистрировать пользователя");
                        }
                       
                }
            }
            return BadRequest("Переданы некорректные данные");
        }

        private void SendMessage(string message, string email)
        {
            try
            {
                MimeMessage msg = new();
                msg.From.Add(new MailboxAddress("Олимп здоровья", "olympus.health.service@gmail.com"));
                msg.To.Add(new MailboxAddress("", email));
                msg.Subject = "Данные для авторизации";
                msg.Body = new BodyBuilder() { HtmlBody = $"<div style=\"color: green;\">{message}</div>" }.ToMessageBody();
                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("olympus.health.service@gmail.com", "qqReflexik"); //логин-пароль от аккаунта
                    client.Send(msg);

                    client.Disconnect(true);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost, Route("GetRole")]
        public async Task<ActionResult<Answer>> GetRole(string token)
        {
            if (token == null)
                return BadRequest("Поле токен не должно быть пустым");
            try
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                return new Answer() { Message = jwt.Claims.ToList()[1].Value };
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost, Route("IsAccept")]
        public async Task<object> IsAccept(string token)
        {
            if (token == null)
                return BadRequest("Поле токен не должно быть пустым");
            try
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                
                switch(jwt.Claims.ToList()[1].Value)
                {
                    case "SysAdmin":
                        {
                            var tmp = await _adminService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                            return tmp.Accept;
                        }
                    case "Medic":
                        {
                            var tmp = await _medicService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                            return tmp.Accept;
                        }
                    case "Patient":
                        return true;
                    default:
                        return BadRequest();
                }
                
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost, Route("CheckToken")]
        public async Task<ActionResult<object>> CheckToken(string token)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                    switch (jwt.Claims.ToList()[1].Value)
                    {
                        case "SysAdmin":
                            {
                                var tmp = await _adminService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                                return tmp != null ? true : BadRequest();
                            }
                        case "Medic":
                            {
                                var tmp = await _medicService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                                return tmp != null ? true : BadRequest();
                            }
                        case "Patient":
                            {
                                var tmp = await _patientService.FindByLoginAsync(jwt.Claims.ToList()[0].Value);
                                return tmp != null ? true : BadRequest();
                            }
                        default:
                            return BadRequest();
                    }
                }
                catch(Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest("Передана некорректная модель данных");
        }

        [HttpPost, Route("Token")]
        public async Task<ActionResult<object>> Token(LoginModel model)
        {
            if(ModelState.IsValid)
                return token(model);
            return BadRequest("Передана некорректная модель данных");
        }
        [HttpPost, Route("Confirm")]
        public async Task<ActionResult<object>> Confirm(string token, string password)
        {
            if(token == null)
                return BadRequest("Поле токен не должно быть пустым");
            if (password == null)
                return BadRequest("Поле пароль не должно быть пустым");
            try
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                switch (jwt.Claims.ToList()[1].Value)
                {
                    case "SysAdmin":
                        {
                            var tmp = await _adminService.IsRegisteredAsync(new LoginModel() { Login = jwt.Claims.ToList()[0].Value, Password = password });
                            return tmp == null ? BadRequest() : true;
                        }
                    case "Medic":
                        {
                            var tmp = await _medicService.IsRegisteredAsync(new LoginModel() { Login = jwt.Claims.ToList()[0].Value, Password = password });
                            return tmp == null ? BadRequest() : true;
                        }
                    case "Patient":
                        {
                            var tmp = await _patientService.IsRegisteredAsync(new LoginModel() { Login = jwt.Claims.ToList()[0].Value, Password = password });
                            return tmp == null ? BadRequest() : true;
                        }
                    default:
                        return BadRequest();
                }
            }
            catch
            {
                return BadRequest(); 
            }

        }
        private object token(LoginModel model)
        {
            var identity = GetIdentity(model.Login, model.Password);
            if (identity == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name,
                role = identity.Claims.ToList()[1].Value
            };
            return response;
        }
        private ClaimsIdentity GetIdentity(string userName, string password)
        {
            LoginModel model = new()
            {
                Login = userName,
                Password = password
            };
            string? role = null;
            if (_adminService.IsRegistered(model) != null)
            {
                role = "SysAdmin";
            }
            else if (_medicService.IsRegistered(model) != null)
            {
                role = "Medic";
            }
            else if (_patientService.IsRegistered(model) != null)
            {
                role = "Patient";
            }
            if (role is null)
                return null;
            var sha256 = new SHA256Managed();
            List<Claim> claims = new()
            {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, model.Login),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
                    };
            ClaimsIdentity claimsIdentity = new(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
