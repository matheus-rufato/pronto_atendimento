using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Models
{
    public class Medico:Pessoa
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


        [Display(Name = "CRM")]
        [Required(ErrorMessage = "Campo CRM obrigatório")]
        [MinLength(5)]
        [MaxLength(15)]
        public string CRM { get; set; }




    }
}
