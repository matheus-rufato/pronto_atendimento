using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ProntoAtendimento.Models
{
    public abstract class Pessoa
    {
        //Propriedades e Metodos
        public int? Id { get; set; }



        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo CPF obrigatório")]
        [MinLength(14)]
        public string Cpf { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Campo Endereço obrigatório")]
        [MinLength(10, ErrorMessage = "Mínimo de 10 caractéres")]
        [MaxLength(50)]
        public string Endereco { get; set; }


        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Campo Telefone obrigatório")]
        [MinLength(11)]
        [MaxLength(15)]
        public string Telefone { get; set; }


        public int Status { get; set; }

      



    }
}
