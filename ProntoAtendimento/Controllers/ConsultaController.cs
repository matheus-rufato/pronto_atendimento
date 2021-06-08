using Microsoft.AspNetCore.Mvc;
using ProntoAtendimento.Data;
using ProntoAtendimento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Controllers
{
    public class ConsultaController : Controller
    {
        public IActionResult Index(Consulta novaConsulta)
        {
            using (var data = new ConsultaData())
            return View(data.ReadAll());
        }

        public IActionResult Atender(Consulta novaConsulta)
        {
            using (var data = new ConsultaData())
                return View(data.Read());
        }



        /* public IActionResult Index(string cpf)
         {
             using (var data = new ConsultaData())
                 return View(data.Read(cpf));
         }*/

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                return View(consulta);
            }

            using (var data = new ConsultaData())
                data.Create(consulta);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {


            using (var data = new ConsultaData())
                return View(data.Read(id));
            /*Consulta consulta = new Consulta();
            if(consulta.Status != "2")
            {
                using (var data = new ConsultaData())
                    return View(data.Read(Nr));
            }
            else
           {
                return RedirectToAction("Index");
            }*/
        }

        [HttpPost]
        public IActionResult Update(int id, Consulta consulta)
        {
            consulta.Nr = id;
            

            if (!ModelState.IsValid)
            {
                return View(consulta);
            }

            using (var data = new ConsultaData())
                data.Update(consulta);
            


            return RedirectToAction("Atender", "Consulta");
        }
    }
}
