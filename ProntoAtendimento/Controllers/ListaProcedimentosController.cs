using ProntoAtendimento.Data;
using ProntoAtendimento.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;


namespace ProntoAtendimento.Controllers
{
    public class ListaProcedimentosController : Controller
    {
        public IActionResult Index()
        {
            List<ItensUtilizados> lista = new List<ItensUtilizados>();

            var listaprocedimentos = HttpContext.Session.GetString("ListaProcedimentos");

            if(listaprocedimentos != null)
            {
                //TODO Converter String para Lista(Json)
                lista = JsonSerializer.Deserialize<List<ItensUtilizados>>(listaprocedimentos);
            }

            return View(lista);

        }


        public IActionResult Meus_pedidos()
        {
            List<ItensUtilizados> lista = new List<ItensUtilizados>();

            var listaprocedimentos = HttpContext.Session.GetString("ListaProcedimentos");

            if (listaprocedimentos != null)
            {
                //TODO Converter String para Lista(Json)
                lista = JsonSerializer.Deserialize<List<ItensUtilizados>>(listaprocedimentos);
            }

            return View(lista);

        }


        [HttpGet]
        public IActionResult Escolher(int id)
        {
            List<ItensUtilizados> lista = new List<ItensUtilizados>();

            var listaprocedimentos = HttpContext.Session.GetString("ListaProcedimentos");

            if(listaprocedimentos != null)
            {
                //TODO Converter String para Lista(Json)
                lista = JsonSerializer.Deserialize<List<ItensUtilizados>>(listaprocedimentos);
            }


            using (var data = new ProcedimentoData())
            {

                var item = lista.SingleOrDefault(i => i.Procedimento.IdProcedimento == id);

                if(item == null)
                {
                    Procedimento procedimento = data.Read(id);
                    
                    item = new ItensUtilizados();
                    item.Procedimento = procedimento;
                    item.ValorTotal = item.Procedimento.Valor;
                    lista.Add(item);
                }            



                //TODO Converter Lista para String (Json)
                listaprocedimentos = JsonSerializer.Serialize<List<ItensUtilizados>>(lista);
                
                HttpContext.Session.SetString("ListaProcedimentos", listaprocedimentos);

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Remover(int id)
        {
            List<ItensUtilizados> lista = new List<ItensUtilizados>();

            var listaprocedimentos = HttpContext.Session.GetString("ListaProcedimentos");

            if(listaprocedimentos != null)
            {
                //TODO Converter String para Lista(Json)
                lista = JsonSerializer.Deserialize<List<ItensUtilizados>>(listaprocedimentos);
            }


            using (var data = new ProcedimentoData())
            {

                var item = lista.SingleOrDefault(i => i.Procedimento.IdProcedimento == id);    

                if(item != null)
                { 
                    lista.Remove(item);
                }


                //TODO Converter Lista para String (Json)
                listaprocedimentos = JsonSerializer.Serialize<List<ItensUtilizados>>(lista);
                
                HttpContext.Session.SetString("ListaProcedimentos", listaprocedimentos);

                return RedirectToAction("Index");
            }
        }
    }
}
