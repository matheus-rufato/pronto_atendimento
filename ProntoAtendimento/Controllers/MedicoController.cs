﻿using ProntoAtendimento.Data;
using ProntoAtendimento.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProntoAtendimento.Controllers
{
    public class MedicoController : Controller
    {
        public IActionResult Index(Medico novoMedico)
        {
            using (var data = new MedicoData())
                return View(data.Read());
        }
        public IActionResult Erro()
        {
            return View();
        }
        public IActionResult Listagem(Medico novoMedico)
        {

            using (var data = new MedicoData())
                return View(data.ReadAll());
        }

        public IActionResult Consulta(Paciente novoPaciente)
        {
            

            HttpContext.Session.SetString("paciente", JsonSerializer.Serialize<Paciente>(novoPaciente));





           

            using (var data = new MedicoData())
                return View(data.Read());
        }

        public IActionResult Espera(Consulta novaConsulta)
        {
            using (var data = new ConsultaData())
                return View(data.Read());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(IFormCollection medico)
        {
            string nome = medico["Nome"];
            string cpf = medico["CPF"];
            string endereco = medico["Endereco"];
            string telefone = medico["Telefone"];
            string login = medico["Login"];
            string senha = medico["Senha"];
            string CRM = medico["CRM"];

            if (nome.Length < 6)
            {
                ViewBag.Mensagem = "Nome deve conter 6 ou mais carecteres";
            }
            /*if (!email.Contains("@"))
            {
                ViewBag.Mensagem = "Email inválido";
                return View();
            }*/
            if (senha.Length < 6)
            {
                ViewBag.Mensagem = "Senha deve conter 6 caracteres ou mais";
                return View();
            }

            var novoMedico = new Medico();
            novoMedico.Nome = medico["Nome"];
            novoMedico.Cpf = medico["Cpf"];
            novoMedico.Endereco = medico["Endereco"];
            novoMedico.Telefone = medico["Telefone"];
            novoMedico.Login = medico["Login"];
            novoMedico.Senha = medico["Senha"];
            novoMedico.CRM = medico["CRM"];

            using (var data = new MedicoData())
                data.Create(novoMedico);

            return RedirectToAction("Index", novoMedico);
        }


        [HttpPost]
        public IActionResult Read(IFormCollection medico)
        {
            string nome = medico["Nome"];
            string cpf = medico["CPF"];
            string endereco = medico["Endereco"];
            string telefone = medico["Telefone"];
            string login = medico["Login"];
            string senha = medico["Senha"];
            string CRM = medico["CRM"];

            if (!login.Equals(" "))
            {
                var med = new Medico();

                med.Nome = medico["Nome"];
                med.Cpf = medico["Cpf"];
                med.Endereco = medico["Endereco"];
                med.Telefone = medico["Telefone"];
                med.Login = medico["Login"];
                med.Senha = medico["Senha"];
                med.Status = medico["Status"];
                med.CRM = medico["CRM"];

                Medico m = new Medico();

                using (var data = new MedicoData())
                    m = data.Read(med.Cpf);

                if (m.Senha == med.Senha)
                {
                    ViewBag.Mensagem = "Olá";
                    return View("Index", m);
                }
                else
                {
                    ViewBag.Mensagem = "Usuário ou senha inválidos";
                    return View("Index", null);
                }

            }

            return View("Create");
        }


        public IActionResult Delete(int id)
        {

            HttpContext.Session.SetString("medicoupdate", JsonSerializer.Serialize<int>(id));

            try
            {
                using (var data = new MedicoData())
                    data.Delete(id);

                return RedirectToAction("Index");
            }
            catch(Exception er)
            {
                return RedirectToAction("erro", "medico");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new MedicoData())
                return View(data.Read(id));
        }


        [HttpPost]
        public IActionResult Update(int id, Medico medico)
        {
            medico.Id = id;

            if (!ModelState.IsValid)
                return View(medico);

            using (var data = new MedicoData())
                data.Update(medico);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update2()
        {



            var idmed = HttpContext.Session.GetString("medicoupdate");
            int id = System.Text.Json.JsonSerializer.Deserialize<int>(idmed);
            
            using (var data = new MedicoData())
                return View(data.Read(id));
        }


        [HttpPost]
        public IActionResult Update2(int id, Medico medico)
        {
            medico.Id = id;

            if (!ModelState.IsValid)
                return View(medico);

            using (var data = new MedicoData())
                data.Update(medico);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View(new MedicoViewModel());
        }

        [HttpPost]
        public IActionResult Login(MedicoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var data = new MedicoData())
            {
                var user2 = data.Read(model);

                if (user2 == null)
                {
                    ViewBag.Message = "Email e/ou senha incorretos!";
                    return View(model);
                }

                HttpContext.Session.SetString("user2", JsonSerializer.Serialize<Medico>(user2)); // Ta dando erro

                return RedirectToAction("Atender", "Consulta");
            }

        }


    }
}
