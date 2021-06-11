using Microsoft.AspNetCore.Mvc;
using ProntoAtendimento.Data;
using ProntoAtendimento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;



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
            var medico = HttpContext.Session.GetString("user2");
            Medico novomedico = System.Text.Json.JsonSerializer.Deserialize<Medico>(medico);

            using (var data = new ConsultaData())
                return View(data.Read((int)novomedico.Id));
        }

        public IActionResult Finalizar(Medico novoMedico)
        {

            HttpContext.Session.SetString("medico", JsonSerializer.Serialize<Medico>(novoMedico));


            Consulta consulta = new Consulta();

            var paciente = HttpContext.Session.GetString("paciente");
            Paciente novopaciente = System.Text.Json.JsonSerializer.Deserialize<Paciente>(paciente);



            var medico = HttpContext.Session.GetString("medico");
            Medico novomedico = System.Text.Json.JsonSerializer.Deserialize<Medico>(medico);


            var user = HttpContext.Session.GetString("user");
            Atendente atendente = System.Text.Json.JsonSerializer.Deserialize<Atendente>(user);



            using (var datapac = new PacienteData())
                novopaciente = datapac.Read((int)novopaciente.Id);
            using (var datamed = new MedicoData())
                novomedico = datamed.Read((int)novomedico.Id);
            using (var dataate = new AtendenteData())
                atendente = dataate.Read((int)atendente.Id);





            consulta.NomePaciente = novopaciente.Nome;
            consulta.NomeMedico = novomedico.Nome;
            consulta.NomeAtendente = atendente.Nome;
            consulta.IdPaciente = (int)novopaciente.Id;
            consulta.IdMedico = (int)novomedico.Id;
            consulta.IdAtendente = (int)atendente.Id;


            return View();
        }




        /* public IActionResult Index(string cpf)
         {
             using (var data = new ConsultaData())
                 return View(data.Read(cpf));
         }*/

        [HttpGet]
        public IActionResult Create()
        {
            Consulta consulta = new Consulta();

            var paciente = HttpContext.Session.GetString("paciente");
            Paciente novopaciente = System.Text.Json.JsonSerializer.Deserialize<Paciente>(paciente);



            var medico = HttpContext.Session.GetString("medico");
            Medico novomedico = System.Text.Json.JsonSerializer.Deserialize<Medico>(medico);


            var user = HttpContext.Session.GetString("user");
            Atendente atendente = System.Text.Json.JsonSerializer.Deserialize<Atendente>(user);



            using (var datapac = new PacienteData())
                novopaciente = datapac.Read((int)novopaciente.Id);
            using (var datamed = new MedicoData())
                novomedico = datamed.Read((int)novomedico.Id);
            using (var dataate = new AtendenteData())
                atendente = dataate.Read((int)atendente.Id);





            consulta.NomePaciente = novopaciente.Nome;
            consulta.NomeMedico = novomedico.Nome;
            consulta.NomeAtendente = atendente.Nome;
            consulta.IdPaciente = (int)novopaciente.Id;
            consulta.IdMedico = (int)novomedico.Id;
            consulta.IdAtendente = (int)atendente.Id;




            return View(consulta);

            
        }

       /* public IActionResult Criar()
        {
            Consulta consulta = new Consulta();

            var paciente = HttpContext.Session.GetString("paciente");
            Paciente novopaciente = System.Text.Json.JsonSerializer.Deserialize<Paciente>(paciente);
            


            var medico = HttpContext.Session.GetString("medico");
            Medico novomedico = System.Text.Json.JsonSerializer.Deserialize<Medico>(medico);
            

            var user = HttpContext.Session.GetString("user");
            Atendente atendente = System.Text.Json.JsonSerializer.Deserialize<Atendente>(user);
            


            using (var datapac = new PacienteData())
                novopaciente = datapac.Read((int)novopaciente.Id);
            using (var datamed = new MedicoData())
                novomedico = datamed.Read((int)novomedico.Id);
            using (var dataate = new AtendenteData())
                atendente = dataate.Read((int)atendente.Id);





            consulta.NomePaciente = novopaciente.Nome;
            consulta.NomeMedico = novomedico.Nome;
            consulta.NomeAtendente = atendente.Nome;
            consulta.IdPaciente = (int)novopaciente.Id;
            consulta.IdMedico = (int)novomedico.Id;
            consulta.IdAtendente = (int)atendente.Id;




            return View(consulta);
        }*/

        [HttpPost]
        public IActionResult Create(IFormCollection consulta)
        {

            /*Consulta consultanova = new Consulta();
            consultanova = consulta;


            var paciente = HttpContext.Session.GetString("paciente");
            Paciente novopaciente = new Paciente();
            novopaciente = System.Text.Json.JsonSerializer.Deserialize<Paciente>(paciente);


            var medico = HttpContext.Session.GetString("medico");
            Medico novomedico = new Medico();
            novomedico = System.Text.Json.JsonSerializer.Deserialize<Medico>(medico);

            var user = HttpContext.Session.GetString("user");
            Atendente atendente = new Atendente();
            atendente = System.Text.Json.JsonSerializer.Deserialize<Atendente>(user);




            consultanova.IdPaciente = (int)novopaciente.Id;
            consultanova.IdMedico = (int)novomedico.Id;
            consultanova.IdAtendente = (int)atendente.Id;*/

            var novoConsulta = new Consulta();
            novoConsulta.IdPaciente = Convert.ToInt32(consulta["IdPaciente"]);
            novoConsulta.IdMedico = Convert.ToInt32(consulta["IdMedico"]);
            novoConsulta.IdAtendente = Convert.ToInt32(consulta["IdAtendente"]);
            novoConsulta.Valor = Convert.ToInt32(consulta["Valor"]);
            novoConsulta.Status = (consulta["Status"]);



            if (!ModelState.IsValid)
            {
                return View(consulta);
            }

            using (var data = new ConsultaData())
               data.Create(novoConsulta);
            return RedirectToAction("Index");
        }



       


        [HttpGet]
        public IActionResult Update(int id)
        {


            using (var data = new ConsultaData())
                return View(data.Read2(id));
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
