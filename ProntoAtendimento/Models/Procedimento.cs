using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Models
{
    public class Procedimento
    {
        public int? IdProcedimento { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome obrigatório")]
        [MinLength(3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo procedimento obrigatório")]
        public string Tipo { get; set; }

        

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Campo valor obrigatório")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }        
    }
}
