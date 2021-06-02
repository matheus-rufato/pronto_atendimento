using ProntoAtendimento.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProntoAtendimento.Data
{
    public class ConsultaData:Data
    {
        public void Create(Consulta consulta)
        {
            SqlTransaction transaction = this.connectionDB.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.Transaction = transaction;
                cmd.CommandText = "CadConsulta(@paciente, @medico, @atendente, @valor, @status, @diagnostico)";

                cmd.Parameters.AddWithValue("@paciente", consulta.IdPaciente);
                cmd.Parameters.AddWithValue("@medico", consulta.IdMedico);
                cmd.Parameters.AddWithValue("@atendente", consulta.IdAtendente);
                cmd.Parameters.AddWithValue("@valor", consulta.Valor);
                cmd.Parameters.AddWithValue("@status", consulta.Status);
                cmd.Parameters.AddWithValue("@diagnostico", consulta.Diagnostico);


                /*ExecuteScalar: executa a consulta e retorna a primeira coluna
                 *da primeira linha no conjuto de resultados retornado pela consulta.
                 *Colunas ou linhas adicionais são ignoradas.
                 */

                int Nr = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (var procedimentos in consulta.Procedimentos)
                {
                    SqlCommand cmdItem = new SqlCommand();
                    cmdItem.Connection = base.connectionDB;
                    cmdItem.Transaction = transaction;
                    cmdItem.CommandText = @"CadProdUtil(@consulta, @procedimento, @obs)";

                    cmdItem.Parameters.AddWithValue("@consulta", Nr);
                    cmdItem.Parameters.AddWithValue("@procedimento", procedimentos.Procedimento.IdProcedimento);
                    cmdItem.Parameters.AddWithValue("@obs", procedimentos.Observacao);

                    cmdItem.ExecuteNonQuery();
                }
                //Executa as inserç~eos da transação nas tabelas
                transaction.Commit();
            }
            catch (Exception ex)
            {
                /*Desfaz as operações de insert caso dê algum problema e elas não
                 *possam ser executadas
                 */
                transaction.Rollback();
            }
        }

        public List<Consulta> Read(string cpf)
        {
            List<Consulta> lista = new List<Consulta>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"SELECT * FROM v_consultas WHERE cpf = @cpf";

            cmd.Parameters.AddWithValue(@"cpf", cpf);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Consulta consulta = new Consulta()
                {
                    Nr = (int)reader["nr"],
                    Status = (string)reader["Situação"],
                    Data = (DateTime)reader["data"],
                    Diagnostico = (string)reader["diagnostico"],
                    Valor = (decimal)reader["Valor Total"]
                };
                consulta.Paciente = new Paciente()
                {
                    Nome = (string)reader["Nome Paciente"],
                    Cpf = (string)reader["cpf"],
                    Convenio = (string)reader["convenio"]
                };
                consulta.Medico = new Medico()
                {
                    Nome = (string)reader["Nome Médico"],
                    CRM = (string)reader["crm"]
                };
                lista.Add(consulta);
            }
            return lista;
        }
    }
}
