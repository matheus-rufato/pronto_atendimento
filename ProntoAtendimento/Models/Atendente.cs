using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProntoAtendimento.Models
{
    public class Atendente:Pessoa
    {

        [Display( Name = "Login")]
        [Required(ErrorMessage = "Campo Login obrigatório")]
        [MinLength(5)]
        [MaxLength(15)]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo Senha obrigatório")]
        [MinLength(5)]
        [MaxLength(15)]
        public string Senha { get; set; }

    }
}
