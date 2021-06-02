using ProntoAtendimento.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Data
{
    public class ProcedimentoData : Data
    {
        public void Create(Procedimento procedimento)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"CadProcedimento(@nome, @tipo, @valor)";

            cmd.Parameters.AddWithValue("@nome", procedimento.Nome);
            cmd.Parameters.AddWithValue("@tipo", procedimento.Tipo == "Ativo"? 1:0);
            cmd.Parameters.AddWithValue("@valor", procedimento.Valor);
            
        }
        
        public List<Procedimento> Read()
        {
            List<Procedimento> lista = new List<Procedimento>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = "SELECT * FROM v_procedimento";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Procedimento procedimento = new Procedimento();

                procedimento.IdProcedimento = (int)reader["Id"];
                procedimento.Nome = (string)reader["nome"];
                procedimento.Tipo = (string)reader["Tipo"];
                procedimento.Valor = (decimal)reader["valor"];

                lista.Add(procedimento);
            }
            return lista;
        }

        public Procedimento Read(int id)
        {
            Procedimento procedimento = null;

            SqlCommand cmd = new SqlCommand();
            // Como conectar com o banco? O base.connectionDB está certo?
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"SELECT * FROM v_procedimento WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                procedimento = new Procedimento
                {
                    IdProcedimento = (int)reader["Id"],
                    Nome = (string)reader["nome"],
                    Tipo = (string)reader["Tipo"],
                    Valor = (decimal)reader["valor"]
                };
            }
            return procedimento;
        }

        public void Update(Procedimento procedimento)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"AltProcedimento (@Id, @nome, @tipo, @valor)";

            // Onde o atributo Tipo será convertido para inteiro? 
            cmd.Parameters.AddWithValue("@nome", procedimento.Nome);
            cmd.Parameters.AddWithValue("@tipo", procedimento.Tipo == "Ativo"? 1:0); 
            cmd.Parameters.AddWithValue("@valor", procedimento.Valor);
            cmd.Parameters.AddWithValue("@Id", procedimento.IdProcedimento);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }





























}
