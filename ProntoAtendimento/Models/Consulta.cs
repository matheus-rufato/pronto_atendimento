using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ProntoAtendimento.Models
{
    public class Consulta
    {
        //Propriedades e Atributos
        public int Nr { get; set; }
        public int IdPaciente { get; set; }
        public int IdAtendente { get; set; }
        public int IdMedico { get; set; }
        public DateTime Data { get; set; }
        public List<ItensUtilizados> Procedimentos { get; set; } = new List<ItensUtilizados>();
        public decimal Valor 
        {
            get
            {
                return Procedimentos.Sum(i => i.ValorTotal);
            }

            set { Valor = value; }
        }

        public string Status { get; set; }

        [Required(ErrorMessage = "Campo Diagnóstico obrigatório")]
        public string Diagnostico { get; set; }

        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }


    }
}
