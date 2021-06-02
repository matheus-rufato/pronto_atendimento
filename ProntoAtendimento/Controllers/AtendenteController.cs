using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Controllers
{
    public class AtendenteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
