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
    public class PacienteController : Controller
    {
        public IActionResult Index(Paciente novoPaciente)
        {

            using (var data = new PacienteData())
                return View(data.Read());
            
        }
        public IActionResult Index2(Paciente novoPaciente)
        {
            Paciente pacientenovo = new Paciente();
            using (var data = new PacienteData())
                pacientenovo = data.Read(novoPaciente.Cpf);
            return View(pacientenovo);

        }
        public IActionResult Sem()
        {

            
                return View();

        }


        public IActionResult Listagem(Paciente novoPaciente)
        {

            using (var data = new PacienteData())
                return View(data.ReadAll());

        }

        public IActionResult Consulta(Paciente novoPaciente)
        {



            HttpContext.Session.SetString("paciente", JsonSerializer.Serialize<Paciente>(novoPaciente));
            using (var data = new PacienteData())
                return View(data.Read());

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Erro()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(IFormCollection paciente)
        {
            try
            {
                string nome = paciente["Nome"];
                string cpf = paciente["Cpf"];
                string endereco = paciente["Endereco"];
                string telefone = paciente["Telefone"];
                string convenio = paciente["Convenio"];


                if (nome.Length < 6)
                {
                    ViewBag.Message = "Nome deve conter 6 ou mais carecteres";
                    return View();
                }
                
                

                var novoPaciente = new Paciente();

                novoPaciente.Nome = paciente["Nome"];
                novoPaciente.Cpf = paciente["Cpf"];
                novoPaciente.Endereco = paciente["Endereco"];
                novoPaciente.Telefone = paciente["Telefone"];
                novoPaciente.Convenio = paciente["Convenio"];


                using (var data = new PacienteData())
                    data.Create(novoPaciente);


                return RedirectToAction("Index", novoPaciente);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "CPF, CRM e/ou Login já cadastrado";
                return View();

            }
        }


        [HttpPost]
        public IActionResult Read(IFormCollection paciente)
        {
            string nome = paciente["Nome"];
            string cpf = paciente["Cpf"];
            string endereco = paciente["Endereco"];
            string telefone = paciente["Telefone"];
            string convenio = paciente["Convenio"];


            if (!cpf.Equals(" "))
            {
                var pac = new Paciente();

                pac.Nome = paciente["Nome"];
                pac.Cpf = paciente["Cpf"];
                pac.Endereco = paciente["Endereco"];
                pac.Telefone = paciente["Telefone"];
                pac.Convenio = paciente["Login"];
                pac.Status = paciente["Status"];


                Paciente p = new Paciente();

                using (var data = new PacienteData())
                    p = data.Read(pac.Cpf);
                
                if (p.Cpf == pac.Cpf)
                {
                    ViewBag.Mensagem = "Olá";
                    return View("Index", p);
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

            HttpContext.Session.SetString("pacienteupdate", JsonSerializer.Serialize<int>(id));
            try
            {
                using (var data = new PacienteData())
                    data.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception er)
            {
                ViewBag.Mensagem =  ("Erro ao deletar : " + er);
                return RedirectToAction("Erro","Paciente");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new PacienteData())
                return View(data.Read(id));
        }


        [HttpPost]
        public IActionResult Update(int id, Paciente paciente)
        {
            try
            {
                paciente.Id = id;

                if (!ModelState.IsValid)
                    return View(paciente);

                using (var data = new PacienteData())
                    data.Update(paciente);

                return RedirectToAction("Listagem", paciente);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "CPF já cadastrado";
                return View();

            }
        }



        [HttpGet]
        public IActionResult Update2()
        {

            var idpac = HttpContext.Session.GetString("pacienteupdate");
            int id = System.Text.Json.JsonSerializer.Deserialize<int>(idpac);


            using (var data = new PacienteData())
                return View(data.Read(id));
        }


        [HttpPost]
        public IActionResult Update2(int id, Paciente paciente)
        {
            try
            {
                paciente.Id = id;

                if (!ModelState.IsValid)
                    return View(paciente);

                using (var data = new PacienteData())
                    data.Update(paciente);

                return RedirectToAction("Index", paciente);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "CPF já cadastrado";
                return View();

            }
        }



        [HttpPost]
        public IActionResult Pesquisa(IFormCollection paciente)
        {
                var pac = new Paciente();

                
                pac.Cpf = paciente["Cpf"];
                


                Paciente p = new Paciente();

                using (var data = new PacienteData())
                    p = data.Read(pac.Cpf);

                if (p !=null)
                {
                    
                    return RedirectToAction("Index2", p);
                }
                else
                {
                    
                    return RedirectToAction("Sem","Paciente" );
                }

            

            
        }



    }

}