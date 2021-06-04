using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Models
{
    public class Paciente:Pessoa
    {



        [Display(Name="Convênio")]
        [Required(ErrorMessage ="Campo Convênio obrigatório")]
        [MinLength(5)]
        [MaxLength(15)]
        public string Convenio { get; set; }


        


    }
}
