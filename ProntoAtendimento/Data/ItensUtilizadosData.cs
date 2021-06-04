using ProntoAtendimento.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Data
{
    public class ItensUtilizadosData : Data
    {
      /*  public List<ItensUtilizados> Read(int id)
        {
            List<ItensUtilizados> lista = new List<ItensUtilizados>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"select * from v_proc_utilizas where Nr = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ItensUtilizados procedimentos = new ItensUtilizados();
                procedimentos.IdConsulta = (int)reader["Nr"];
                procedimentos.Procedimento = new Procedimento()
                {
                    Nome    = (string)reader["Nome"],
                    Tipo    = (string)reader["Tipo"],
                    Valor   = (decimal)reader["Valor"]
                };
                lista.Add(procedimentos);
            }

            return lista;
        }*/
    }
}
