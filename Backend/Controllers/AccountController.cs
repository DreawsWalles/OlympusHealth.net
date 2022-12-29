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

namespace Backend.Controllers
{
    public class Answer
    {
        public string Message { get; set; }
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

        public AccountController(ISysAdminService adminService, IMedicService medicService, IPatientService patientService)
        {
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
            _medicService = medicService ?? throw new ArgumentNullException(nameof(medicService));
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }

        
        [HttpPost, Route("Login")]
        public async Task<ActionResult<object>> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _adminService.IsRegisteredAsync(model) != null)
                {
                    model.Role = "SysAdmin";
                    return Token(new LoginModel() { Login = model.Login, Password = model.Password });
                }
                if (await _medicService.IsRegisteredAsync(model) != null)
                {
                    model.Role = "Medic";
                    return Token(new LoginModel() { Login = model.Login, Password = model.Password });
                }
                if (await _patientService.IsRegisteredAsync(model) != null)
                {
                    model.Role = "Patient";
                    return Token(new LoginModel() { Login = model.Login, Password = model.Password }); 
                }
                return NotFound(model);
            }
            ModelState.AddModelError("Error", "Неверный логин и(или) пароль");
            return BadRequest(model);
        }

        private bool checkLogin(string login)
        {
            var admins = _adminService.GetAll();
            foreach (var admin in admins)
                if (admin.Login == login)
                    return true;
            var medics = _medicService.GetAll();
            foreach (var medic in medics)
                if (medic.Login == login)
                    return true;
            var patients = _patientService.GetAll();
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
                return checkLogin(login) ? true : NotFound(login);
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
        private bool checkEmail(string email, string role)
        {
            switch (role)
            {
                case "medic":
                    var medics = _medicService.GetAll();
                    foreach (var medic in medics)
                        if (medic.Email == email)
                            return true;
                    return false;
                case "patient":
                    var patients = _patientService.GetAll();
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
                return checkEmail(email, role) ? true : NotFound(email);
            }
            return BadRequest("Переданы некорректные данные");
        }

        private static bool isValidPhoneNumber(string phoneNumber)
        {
            var trimPhoneNumber = phoneNumber.Trim();
            Regex validatePhoneNumberValid = new("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
            return validatePhoneNumberValid.IsMatch(trimPhoneNumber);
        }
        private bool checkPhoneNumber(string phoneNumber, string role)
        {
            switch (role)
            {
                case "medic":
                    var medics = _medicService.GetAll();
                    foreach (var medic in medics)
                        if (medic.PhoneNumber == phoneNumber)
                            return true;
                    return false;
                case "patient":
                    var patients = _patientService.GetAll();
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
                return checkPhoneNumber(phoneNumber, role) ? true : NotFound(phoneNumber);
            }
            return BadRequest("Переданы некорректные данные");      
        }

        private static bool isValidDate(string date)
        {
            DateOnly dateTime = new(Convert.ToInt32(date[..4]), Convert.ToInt32(date.Substring(5, 2)), Convert.ToInt32(date.Substring(7, 2)));
            DateOnly currentDate = new();
            if (dateTime.Year > currentDate.Year)
                return false;
            if (dateTime.Month > currentDate.Month)
                return false;
            if (dateTime.Day >= currentDate.Day)
                return false;
            return true;
        }

        [HttpPost, Route("RegisterUser")]
        public async Task<ActionResult<object>> RegisterUser(RegisterModelUser registerModelUser)
        {
            if(ModelState.IsValid)
            {
                if (checkLogin(registerModelUser.Login))
                    return NotFound("Пользователь с таким логином уже существует");
                if (!isValidEmail(registerModelUser.Email))
                    return BadRequest("Переданы некорректные данные");
                if (checkEmail(registerModelUser.Email, registerModelUser.Role))
                    return NotFound("Пользоатель с таким email уже существует");
                if (!isValidPhoneNumber(registerModelUser.PhoneNumber))
                    return BadRequest("Переданны некорректые данные");
                if (checkPhoneNumber(registerModelUser.PhoneNumber, registerModelUser.Role))
                    return NotFound("Пользователь с таким номером телефона уже существует");
                if (registerModelUser.Birthday != null && !isValidDate(registerModelUser.Birthday.ToString()))
                    return BadRequest("Переданы некорректные данные");
                switch(registerModelUser.Role)
                {
                    case "patient":
                        PatientDto patientDto = new()
                        {
                            Login = registerModelUser.Login,
                            Password = registerModelUser.Password,
                            Name = registerModelUser.Name,
                            Surname = registerModelUser.Surname,
                            Patronymic = registerModelUser.Patronymic,
                            Email = registerModelUser?.Email,
                            PhoneNumber = registerModelUser?.PhoneNumber,
                            Birthday = registerModelUser?.Birthday,
                            Gender = registerModelUser?.Gender
                        };
                        PatientDto patient = patientDto;
                        await _patientService.CreateAsync(patient);
                        try
                        {
                            var result = token(new LoginModel() { Login = registerModelUser.Login, Password = registerModelUser.Password });
                            return result;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return BadRequest("Не удалось зарегистрировать пользователя");
                        }
                }
            }
            return BadRequest("Переданы некорректные данные");
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


        [HttpPost, Route("Token")]
        public async Task<ActionResult<object>> Token(LoginModel model)
        {
            if(ModelState.IsValid)
                return token(model);
            return BadRequest("Передана некорректная модель данных");
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
