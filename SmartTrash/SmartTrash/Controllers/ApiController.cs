using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartTrash.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        [Route("key/yandex")]
        public IActionResult Yandex()
        {
            string key = "здесь должен быть API KEY";
            return Content(key);
        }
    }
}