using Business.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/Notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHistoryNodeService _notification;
        public NotificationController(IHistoryNodeService notification)
        {
            _notification = notification ?? throw new ArgumentNullException(nameof(notification));
        }

        [HttpPost, Route("Count")]
        public async Task<ActionResult<int>> GetCount(string token)
        {
            if (token == null)
                BadRequest("Токен не может быть пустым");
            try
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                string role = jwt.Claims.ToList()[1].Value;
                return (await _notification.GetByLoginAsync(jwt.Claims.ToList()[0].Value, jwt.Claims.ToList()[1].Value)).Count;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
    }
}
