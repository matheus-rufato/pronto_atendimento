using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProntoAtendimento.Models;
using ProntoAtendimento.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;


namespace ProntoAtendimento.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            HttpContext.Session.Clear();
           

            return View();
        }


        [HttpGet]
        public IActionResult Inicial()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Inicial(Home home)
        {


            if (home.opcao == 1)
            { return RedirectToAction("Editar", "Home"); }
            else
            { 
                
                
                
                return RedirectToAction("Consulta", "Paciente"); 
            
            }
        }


        [HttpGet]
        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(Home home)
        {
           


            if (home.opcao2 == 1)
            { return RedirectToAction("Listagem", "Medico"); }
            else if (home.opcao2 == 2)
            { return RedirectToAction("Index", "Atendente"); }
            else if (home.opcao2 == 3)
            { return RedirectToAction("Listagem", "Paciente"); }
            else if (home.opcao2 == 4)
            { return RedirectToAction("Index", "Procedimento"); }
            else 
            { return RedirectToAction("Index", "Consulta"); }



        }


        [HttpGet]
        public IActionResult EscolherConsulta()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EscolherConsulta(Home home)
        {
            if (home.opcao3 == 1)
            { return RedirectToAction("Consulta", "Medico"); }
            else 
            { return RedirectToAction("Consulta", "Paciente"); }

        }




        public IActionResult Privacy()
        {
            return View();
        }


        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
