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
    public class ItensUtilizadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Criar()
        {
            //pegar o id da consulta
            var consltanpn = HttpContext.Session.GetString("consultanpn");
            
            var novaconsultaid = System.Text.Json.JsonSerializer.Deserialize<int>(consltanpn);



             //pegar a lista de itens utilizados
            List<ItensUtilizados> lista = new List<ItensUtilizados>();

            var listaprocedimentos = HttpContext.Session.GetString("ListaProcedimentos");
            lista = JsonSerializer.Deserialize<List<ItensUtilizados>>(listaprocedimentos);

            ItensUtilizados novoitem = new ItensUtilizados();


            foreach (var item in lista)
            {
                novoitem.IdConsulta = novaconsultaid;
                novoitem.IdProcedmento = (int)item.Procedimento.IdProcedimento;
                novoitem.ValorTotal = item.Procedimento.Valor;

                using (var data = new ItensUtilizadosData())
                    data.Create(novoitem);
                using (var data2 = new ItensUtilizadosData())
                    data2.Valorar(novoitem);


            }

            
            return View(novoitem);

            }




        }
}
