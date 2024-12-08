using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Basic_Dev_Pattern.Config;
using Microsoft.Extensions.Options;

namespace Basic_Dev_Pattern.Controllers
{
    [Route("api/mysetting")]
    [ApiController]
    public class MySettingController(IOptions<Setting> options) : ControllerBase
    {
        private readonly Setting _setting = options.Value;

        [Route("getconfig")]
        [HttpGet]
        public IActionResult GetConfigValues()
        {

            var user = new UserInfo
            {
                Username = _setting.User!.UserName,
                Password = _setting.Password!.UserPwd,
                Rememberme = _setting.Validation!.RememberMe,
                Languages = _setting.Programming!.Languages
            };

            return Ok(user);
        }
    }

    class UserInfo
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? Rememberme { get; set; }
        public IList<string>? Languages { get; set; }
    }
}
