using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Models
{
    public class ItensUtilizados
    {

        //Propriedades e Atributos
        public int IdProcedmento { get; set; }
        public decimal ValorTotal { get; set; }
        public string Observacao { get; set; }
        public Procedimento Procedimento { get; set; } // Is a 
        
    }
}
