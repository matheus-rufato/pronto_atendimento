﻿using ProntoAtendimento.Data;
using ProntoAtendimento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Controllers
{
    //Um controlador é apenas uma classe que deriva (herda) da classe base
    //System.Web.Mvc.Controller.  Como um controlador herda dessa classe
    //base, um controlador herda vários métodos úteis
    public class ProcedimentoController : Controller
    {
        //O IAction tipo de retorno é apropriado quando vários  ActionResult
        //tipos de retorno são possíveis em uma ação
        //Os tipo AcrionResult representam vários códigos de status HTTP
        public IActionResult Index()
        {
            //Criando um objeto data da classe ProdutoData
            using (var data = new ProcedimentoData())
                return View(data.Read());
            //data.Read() chama a execução do método Read (Select + From Produtos)
        }

        public IActionResult Selection()
        {
            //Criando um objeto data da classe ProdutoData
            using (var data = new ProcedimentoData())
                return View(data.Read());
            //data.Read() chama a execução do método Read (Select + From Produtos)
        }


        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag tem como objetibo trasnportar pequenas quantidades de dados
            //entre views ou de controllers para views
            

            return View();
        }

        // A ideia geral é a seguinte: seu serviço vai prover uma url base
        // e os verbos HTTP vão indicar qual ação está sendo requisitada pelo
        // consumidor do serviço. Por exemplo, considerando a URL
        // www.dominio.com/rest/notas/, se enviarmos para ela uma requisição
        // HTTP utilizando o verbo GET, provavelmente obteremos como resultado
        // uma listagem de registros(notas, nesse caso). Por outro lado,
        // se utilizarmos o verbo POST, provalmente estaremos tentando adicionar
        // um novo registro, cujos dados serão enviados no corpo da requisição.

        [HttpPost]
        public IActionResult Create(Procedimento procedimento)
        {
            //O ModeState é uma propriedade da classe Controller e pode ser
            //acessada a partir das classes que herdam de System.Web.Mvc.Controller.
            //Ele representa uma coleção de pares nome/valor que são submetidos
            //ao servidor durante o POST e também contém uma coleção de mensagens
            //de erros para cada calor submetido
            if (!ModelState.IsValid)
            {
                return View(procedimento);
            }

            if (procedimento.Valor < 0)
            {
                ViewBag.Message = "O Valor deve ser maior que 0";
                return View();
            }


            using (var data = new ProcedimentoData())
                data.Create(procedimento);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ItensUtilizados procUtizas = new ItensUtilizados();
            if(procUtizas.IdProcedmento == id)
            {
                using (var data = new ProcedimentoData())
                    data.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mensagem = "O procedimento não foi utilizado";
                return View("Index");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {           
            using (var data = new ProcedimentoData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Procedimento procedimento)
        {
            try
            {
                if (procedimento.Valor < 0)
                {
                    ViewBag.Message = "Valor inválido.";
                    using (var data = new ProcedimentoData())
                        return View(data.Read(id));
                }

                    procedimento.IdProcedimento = id;

                    if (!ModelState.IsValid)
                    {
                        return View(procedimento);
                    }

                    using (var data = new ProcedimentoData())
                        data.Update(procedimento);

                    return RedirectToAction("Index");
                
            }
            catch (Exception es)
            {
                ViewBag.Message = "CPF e/ou Login já cadastrado";
                return View();


            }

        }
    }
}