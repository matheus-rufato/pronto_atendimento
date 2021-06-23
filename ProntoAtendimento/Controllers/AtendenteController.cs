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


            using (var data = new AtendenteData())
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

        public IActionResult Admin()
        {
            ViewBag.Message = "Por favor, não modificar conta administrador.";
            return View();
        }

        public IActionResult ErroCreate()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(IFormCollection atendente)
        {
            try
            {
                string nome = atendente["Nome"];
                string cpf = atendente["CPF"];
                string endereco = atendente["Endereco"];
                string telefone = atendente["Telefone"];
                string login = atendente["Login"];
                string senha = atendente["Senha"];





                if (nome.Length < 6)
                {
                    ViewBag.Message = "Nome deve conter 6 ou mais carecteres";
                    return View();
                }
                if (senha.Length < 7)
                {
                    ViewBag.Message = "Senha deve conter 6 ou mais carecteres";
                    return View();
                }
                if (!login.Contains("@"))
                {
                    ViewBag.Message = "Email inválido";
                    return View();
                }


                var novoAtendente = new Atendente();
                novoAtendente.Nome = atendente["Nome"];
                novoAtendente.Cpf = atendente["Cpf"];
                novoAtendente.Endereco = atendente["Endereco"];
                novoAtendente.Telefone = atendente["Telefone"];
                novoAtendente.Login = atendente["Login"];
                novoAtendente.Senha = atendente["Senha"];

                if (!ModelState.IsValid)
                    return View(atendente);


                using (var data = new AtendenteData())
                    data.Create(novoAtendente);

                return RedirectToAction("Index", novoAtendente);
            }
            catch(Exception ex)
            {
                ViewBag.Message = "CPF e/ou Login já cadastrado";
                return View();

            }
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
                atn.Status = atendente["Status"];
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
            if(id==1)
            {
                ViewBag.Message = "Administrador não pode ser removido.";
                return RedirectToAction("Admin","Atendente");
            }

            HttpContext.Session.SetString("atendenteupdate", JsonSerializer.Serialize<int>(id));
            try
            {
                using (var data = new AtendenteData())
                    data.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception er)
            {
                ViewBag.Mensagem = "Email inválido";
                return RedirectToAction("Erro", "Atendente");
            }
        



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
            if (id == 1)
            {
                
                return RedirectToAction("Admin", "Atendente");
            }

            try
            {
                atendente.Id = id;

                if (!ModelState.IsValid)
                    return View(atendente);

                using (var data = new AtendenteData())
                    data.Update(atendente);



                var user = HttpContext.Session.GetString("user");
                Atendente atendente2 = System.Text.Json.JsonSerializer.Deserialize<Atendente>(user);

                if (atendente.Id == atendente2.Id)
                {
                    Atendente useratend = new Atendente();
                    useratend = atendente;
                    HttpContext.Session.SetString("user", JsonSerializer.Serialize<Atendente>(useratend));


                }


                return RedirectToAction("Index");
            }
            catch(Exception es)
            {
                ViewBag.Message = "CPF e/ou Login já cadastrado";
                return View();


            }
        }



        [HttpGet]
        public IActionResult Update2()
        {



            var idate = HttpContext.Session.GetString("atendenteupdate");
            int id = System.Text.Json.JsonSerializer.Deserialize<int>(idate);

            using (var data = new AtendenteData())
                return View(data.Read(id));
        }


        [HttpPost]
        public IActionResult Update2(int id, Atendente atendente)
        {
            try
            {
                atendente.Id = id;

                if (!ModelState.IsValid)
                    return View(atendente);

                using (var data = new AtendenteData())
                    data.Update(atendente);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "CPF e/ou Login já cadastrado";
                return View();

            }
        }


        [HttpGet]
        public IActionResult Update3(int id)
        {
            using (var data = new AtendenteData())
                return View(data.Read(id));
        }


        [HttpPost]
        public IActionResult Update3(int id, Atendente atendente)
        {
            try
            {
                atendente.Id = id;

                if (!ModelState.IsValid)
                    return View(atendente);

                using (var data = new AtendenteData())
                    data.Update(atendente);

                Atendente user = new Atendente();
                user = atendente;
                HttpContext.Session.SetString("user", JsonSerializer.Serialize<Atendente>(user));
                return RedirectToAction("Inicial", "home");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "CPF e/ou Login já cadastrado";
                return View();

            }
        }





        [HttpGet]
            public IActionResult Login()
           {
            HttpContext.Session.Clear();
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

                   HttpContext.Session.SetString("user", JsonSerializer.Serialize<Atendente>(user)); 

                   return RedirectToAction("Inicial","Home");
               }

           }
         

    }
}
