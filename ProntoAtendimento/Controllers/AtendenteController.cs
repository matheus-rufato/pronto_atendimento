using ProntoAtendimento.Data;
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
    public class AtendenteController : Controller
    {
        public IActionResult Index(Atendente novoAtendente)
        {
            return View(novoAtendente);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(IFormCollection atendente)
        {
            string nome = atendente["Nome"];
            string cpf = atendente["CPF"];
            string endereco = atendente["Endereco"];
            string telefone = atendente["Telefone"];
            string login = atendente["Login"];
            string senha = atendente["Senha"];



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

            var novoAtendente = new Atendente();
            novoAtendente.Nome = atendente["Nome"];
            novoAtendente.Cpf = atendente["Cpf"];
            novoAtendente.Endereco = atendente["Endereco"];
            novoAtendente.Telefone = atendente["Telefone"];
            novoAtendente.Login = atendente["Login"];
            novoAtendente.Senha = atendente["Senha"];

            using (var data = new AtendenteData())
                data.Create(novoAtendente);

            return RedirectToAction("Index", novoAtendente);
        }


        [HttpPost]
        public IActionResult Read(IFormCollection atendente)
        {
            string nome = atendente["Nome"];
            string cpf = atendente["CPF"];
            string endereco = atendente["Endereco"];
            string telefone = atendente["Telefone"];
            string login = atendente["Login"];
            string senha = atendente["Senha"];

            if (!login.Equals(" "))
            {
                var atn = new Atendente();

                atn.Nome = atendente["Nome"];
                atn.Cpf = atendente["Cpf"];
                atn.Endereco = atendente["Endereco"];
                atn.Telefone = atendente["Telefone"];
                atn.Login = atendente["Login"];
                atn.Senha = atendente["Senha"];

                Atendente a = new Atendente();

                using (var data = new AtendenteData())
                    a = data.Read(atn.Cpf);

                if (a.Senha == atn.Senha)
                {
                    ViewBag.Mensagem = "Olá";
                    return View("Index", a);
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
            using (var data = new AtendenteData())
                data.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new AtendenteData())
                return View(data.Read(id));
        }


        [HttpPost]
        public IActionResult Update(int id, Atendente atendente)
        {
            atendente.Id = id;

            if (!ModelState.IsValid)
                return View(atendente);

            using (var data = new AtendenteData())
                data.Update(atendente);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View(new AtendenteViewModel());
        }

        [HttpPost]
        public IActionResult Login(AtendenteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var data = new AtendenteData())
            {
                var user = data.Read(model);

                if (user == null)
                {
                    ViewBag.Message = "Email e/ou senha incorretos!";
                    return View(model);
                }

                //HttpContext.Session.SetString("user", JsonSerializer.Serialize<Atendente>(user)); // Ta dando erro

                return RedirectToAction("Index", "Produto");
            }

        }


    }
}
