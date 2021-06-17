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


        public IActionResult Fim()
        {
            
                return View();
        }

        public IActionResult Atender(Consulta novaConsulta)
        {
            var medico = HttpContext.Session.GetString("user2");
            Medico novomedico = System.Text.Json.JsonSerializer.Deserialize<Medico>(medico);

            using (var data = new ConsultaData())
                return View(data.Read((int)novomedico.Id));
        }


        public IActionResult RelatorioPaciente()
        {



            //HttpContext.Session.SetString("pacienterelatorio", JsonSerializer.Serialize<Paciente>(novoPaciente));
            using (var data = new PacienteData())
                return View(data.Read());

        }

        public IActionResult RelatorioProcedimento(int id)
        {



            //HttpContext.Session.SetString("relatorioconsulta", JsonSerializer.Serialize<int>(id));
            using (var data = new ItensUtilizadosData())
                return View(data.Read(id));

        }

        public IActionResult RelatorioMedico(Paciente novoPaciente)
        {


            HttpContext.Session.SetString("pacienterelatorio", JsonSerializer.Serialize<Paciente>(novoPaciente));




            using (var data = new MedicoData())
                return View(data.Read());
        }



        public IActionResult Relatorio(Medico novomedico)
        {

            HttpContext.Session.SetString("medicorelatorio", JsonSerializer.Serialize<Medico>(novomedico));



            Consulta consurelato = new Consulta();

            var paciente = HttpContext.Session.GetString("pacienterelatorio");
            Paciente pacrelato = System.Text.Json.JsonSerializer.Deserialize<Paciente>(paciente);



            var medico = HttpContext.Session.GetString("medicorelatorio");
            Medico medrelato = System.Text.Json.JsonSerializer.Deserialize<Medico>(medico);



            consurelato.IdMedico = (int)medrelato.Id;
            consurelato.IdPaciente = (int)pacrelato.Id;


            using (var data = new ConsultaData())
                return View(data.ReadRelatorio(consurelato));
        }








        public IActionResult Finalizar(Medico novoMedico)
        {

            HttpContext.Session.SetString("medico", JsonSerializer.Serialize<Medico>(novoMedico));


            Consulta consulta = new Consulta();


            var paciente = HttpContext.Session.GetString("paciente");
            Paciente novopaciente = System.Text.Json.JsonSerializer.Deserialize<Paciente>(paciente);
            

            if (novopaciente.Id == null) {
                var paciente2 = HttpContext.Session.GetString("pacientevolta");
                novopaciente = System.Text.Json.JsonSerializer.Deserialize<Paciente>(paciente2);
            }
            else
            {

                HttpContext.Session.SetString("pacientevolta", JsonSerializer.Serialize<Paciente>(novopaciente));
            }


            var medico = HttpContext.Session.GetString("medico");
            Medico novomedico = System.Text.Json.JsonSerializer.Deserialize<Medico>(medico);


            var user = HttpContext.Session.GetString("user");
            Atendente atendente = System.Text.Json.JsonSerializer.Deserialize<Atendente>(user);

            Paciente novopaciente2 = new Paciente();

            using (var datapac = new PacienteData())
                novopaciente2 = datapac.Read((int)novopaciente.Id);
            using (var datamed = new MedicoData())
                novomedico = datamed.Read((int)novomedico.Id);
            using (var dataate = new AtendenteData())
                atendente = dataate.Read((int)atendente.Id);





            consulta.NomePaciente = novopaciente2.Nome;
            consulta.NomeMedico = novomedico.Nome;
            consulta.NomeAtendente = atendente.Nome;
            consulta.IdPaciente = (int)novopaciente2.Id;
            consulta.IdMedico = (int)novomedico.Id;
            consulta.IdAtendente = (int)atendente.Id;


            return View(consulta);
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


            HttpContext.Session.SetString("consultanpn", JsonSerializer.Serialize<int>(id));
           // var consltanpn = HttpContext.Session.GetString("consultanpn");
           // Consulta novaconsultanpn = new Consulta();
           // novaconsultanpn.Nr = System.Text.Json.JsonSerializer.Deserialize<int>(consltanpn);


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


            if (consulta.Status == "2")
            {
                return RedirectToAction("Fim", "Consulta");

            }
            else
            {
                return RedirectToAction("Atender", "Consulta");
            }
        }
    }
}
