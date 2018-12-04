using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SmartTrash.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        private IConfiguration _config;
        public ApiController(IConfiguration config)
        {
            _config = config;
        }

        [Route("key/yandex")]
        public IActionResult Yandex()
        {
            string key = _config.GetSection("MapApiKeys").GetSection("Yandex").Value;
            return Content(key);
        }
    }
}