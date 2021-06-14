using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Models
{
    public class MedicoViewModel
    {

        //propriedades & atributos:
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Campo login obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo senha obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
        public string Senha { get; set; }

        public bool acesso { get; set; }

    }
}
