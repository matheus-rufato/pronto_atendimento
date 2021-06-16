using ProntoAtendimento.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProntoAtendimento.Data;
using Microsoft.AspNetCore.Http;
using System.Text.Json;


namespace ProntoAtendimento.Data
{
    public class ConsultaData:Data
    {
        public void Create(Consulta consulta)
        {
            //SqlTransaction transaction = this.connectionDB.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                //cmd.Transaction = transaction;
                cmd.CommandText = "CadConsulta @paciente, @medico, @atendente, @valor, @status";

                cmd.Parameters.AddWithValue("@paciente", consulta.IdPaciente);
                cmd.Parameters.AddWithValue("@medico", consulta.IdMedico);
                cmd.Parameters.AddWithValue("@atendente", consulta.IdAtendente);
                cmd.Parameters.AddWithValue("@valor", consulta.Valor);
                cmd.Parameters.AddWithValue("@status", consulta.Status);
                //cmd.Parameters.AddWithValue("@diagnostico", consulta.Diagnostico);

                cmd.ExecuteNonQuery();
                /*ExecuteScalar: executa a consulta e retorna a primeira coluna
                 *da primeira linha no conjuto de resultados retornado pela consulta.
                 *Colunas ou linhas adicionais são ignoradas.
                 */

                // int Nr = Convert.ToInt32(cmd.ExecuteScalar());

                /*foreach (var procedimentos in consulta.Procedimentos)
                {
                    SqlCommand cmdItem = new SqlCommand();
                    cmdItem.Connection = base.connectionDB;
                    cmdItem.Transaction = transaction;
                    cmdItem.CommandText = @"CadProdUtil @consulta, @procedimento, @obs";

                    cmdItem.Parameters.AddWithValue("@consulta", Nr);
                    cmdItem.Parameters.AddWithValue("@procedimento", procedimentos.Procedimento.IdProcedimento);
                    cmdItem.Parameters.AddWithValue("@obs", procedimentos.Observacao);

                    cmdItem.ExecuteNonQuery();
                }*/
                //Executa as inserç~eos da transação nas tabelas
                //transaction.Commit();
            }
            catch (Exception ex)
            {
                /*Desfaz as operações de insert caso dê algum problema e elas não
                 *possam ser executadas
                 */
                //transaction.Rollback();
            }
        }
        public List<Consulta> Read()
        {
            List<Consulta> lista = new List<Consulta>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"SELECT * FROM v_consultas where Situação != 'Encerrada'";

            SqlDataReader reader = cmd.ExecuteReader();
            Consulta consulta = null;

            while (reader.Read())
            {
                consulta = new Consulta();
                consulta.Medico = new Medico();
                consulta.Paciente = new Paciente();

                consulta.Nr = (int)reader["nr"];
                consulta.Medico.Nome = (string)reader["Nome Médico"];
                consulta.Medico.CRM = (string)reader["crm"];
                consulta.Paciente.Nome = (string)reader["Nome Paciente"];
                consulta.Paciente.Cpf = (string)reader["cpf"];
                consulta.Paciente.Convenio = (string)reader["convenio"];
                consulta.Data = (DateTime)reader["data"];
                consulta.Diagnostico = (string)reader["diagnostico"];
                consulta.Status = (string)reader["Situação"];







                /*Consulta consulta = new Consulta()
                {
                    Nr = (int)reader["nr"],
                    Status = (string)reader["Situação"],
                    Data = (DateTime)reader["data"],
                    Diagnostico = (string)reader["Diagnostico"],
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
                };*/
                lista.Add(consulta);
            }
            return lista;
        }



        public List<Consulta> ReadAll()
        {
            List<Consulta> lista = new List<Consulta>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"SELECT * FROM v_consultas ";

            SqlDataReader reader = cmd.ExecuteReader();
            Consulta consulta = null;

            while (reader.Read())
            {
                consulta = new Consulta();
                consulta.Medico = new Medico();
                consulta.Paciente = new Paciente();

                consulta.Nr = (int)reader["nr"];
                consulta.Medico.Nome = (string)reader["Nome Médico"];
                consulta.Medico.CRM = (string)reader["crm"];
                consulta.Paciente.Nome = (string)reader["Nome Paciente"];
                consulta.Paciente.Cpf = (string)reader["cpf"];
                consulta.Paciente.Convenio = (string)reader["convenio"];
                consulta.Data = (DateTime)reader["data"];
                consulta.Diagnostico = (string)reader["diagnostico"];
                consulta.Status = (string)reader["Situação"];







                /*Consulta consulta = new Consulta()
                {
                    Nr = (int)reader["nr"],
                    Status = (string)reader["Situação"],
                    Data = (DateTime)reader["data"],
                    Diagnostico = (string)reader["Diagnostico"],
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
                };*/
                lista.Add(consulta);
            }
            return lista;
        }



        public List<Consulta> ReadRelatorio(Consulta novaconsulta)
        {
            List<Consulta> lista = new List<Consulta>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"SELECT* FROM v_consultas v, consultas c where  v.nr = c.nr and c.medico_id = @idmed and paciente_id = @idpac ";
            


            cmd.Parameters.AddWithValue(@"idmed", novaconsulta.IdMedico);
            cmd.Parameters.AddWithValue(@"idpac", novaconsulta.IdPaciente);




            SqlDataReader reader = cmd.ExecuteReader();
            Consulta consulta = null;

            while (reader.Read())
            {
                consulta = new Consulta();
                consulta.Medico = new Medico();
                consulta.Paciente = new Paciente();

                consulta.Nr = (int)reader["nr"];
                consulta.Medico.Nome = (string)reader["Nome Médico"];
                consulta.Medico.CRM = (string)reader["crm"];
                consulta.Paciente.Nome = (string)reader["Nome Paciente"];
                consulta.Paciente.Cpf = (string)reader["cpf"];
                consulta.Paciente.Convenio = (string)reader["convenio"];
                consulta.Data = (DateTime)reader["data"];
                consulta.Diagnostico = (string)reader["diagnostico"];
                consulta.Valor = (Math.Round((decimal)reader["valor"],2));
                consulta.Status = (string)reader["Situação"];

                lista.Add(consulta);
            }
            return lista;
        }






        public List<Consulta> Read(int id)
        {
            /*List<Consulta> lista = new List<Consulta>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"SELECT * FROM v_consultas WHERE cpf = @cpf";

            cmd.Parameters.AddWithValue(@"cpf", cpf);

            SqlDataReader reader = cmd.ExecuteReader();
            Consulta consulta = null;

            while (reader.Read())
            {
                consulta = new Consulta();
                consulta.Medico = new Medico();
                consulta.Paciente = new Paciente();

                consulta.Nr = (int)reader["nr"];
                consulta.Medico.Nome = (string)reader["Nome Médico"];
                consulta.Medico.CRM = (string)reader["crm"];
                consulta.Paciente.Nome = (string)reader["Nome Paciente"];
                consulta.Paciente.Cpf = (string)reader["cpf"];
                consulta.Paciente.Convenio = (string)reader["convenio"];
                consulta.Data = (DateTime)reader["data"];
                consulta.Diagnostico = (string)reader["diagnostico"];
                consulta.Status = (string)reader["Situação"];
                lista.Add(consulta);
            }
            return lista;*/


            List<Consulta> lista = new List<Consulta>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"SELECT * FROM v_consultas v , consultas c where c.Nr = v.nr and v.Situação != 'Encerrada' and  c.medico_id = @id";

            cmd.Parameters.AddWithValue(@"id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            Consulta consulta = null;

            while (reader.Read())
            {
                consulta = new Consulta();
                consulta.Medico = new Medico();
                consulta.Paciente = new Paciente();

                consulta.Nr = (int)reader["nr"];
                consulta.Medico.Nome = (string)reader["Nome Médico"];
                consulta.Medico.CRM = (string)reader["crm"];
                consulta.Paciente.Nome = (string)reader["Nome Paciente"];
                consulta.Paciente.Cpf = (string)reader["cpf"];
                consulta.Paciente.Convenio = (string)reader["convenio"];
                consulta.Data = (DateTime)reader["data"];
                consulta.Diagnostico = (string)reader["diagnostico"];
                consulta.Status = (string)reader["Situação"];







                /*Consulta consulta = new Consulta()
                {
                    Nr = (int)reader["nr"],
                    Status = (string)reader["Situação"],
                    Data = (DateTime)reader["data"],
                    Diagnostico = (string)reader["Diagnostico"],
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
                };*/
                lista.Add(consulta);
            }
            return lista;


        }

        public Consulta Read2(int nr)
        {
            Consulta consulta = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"select * from v_consultas where nr = @Nr and Situação != 'Encerrada'";
            cmd.Parameters.AddWithValue("@nr", nr);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                consulta = new Consulta();
                consulta.Medico = new Medico();
                consulta.Paciente = new Paciente();

                consulta.Nr = (int)reader["nr"];
                consulta.Medico.Nome = (string)reader["Nome Médico"];
                consulta.Medico.CRM = (string)reader["crm"];
                consulta.Paciente.Nome = (string)reader["Nome Paciente"];
                consulta.Paciente.Cpf = (string)reader["cpf"];
                consulta.Paciente.Convenio = (string)reader["convenio"];
                consulta.Data = (DateTime)reader["data"];
                consulta.Diagnostico = (string)reader["diagnostico"];
                consulta.Status = (string)reader["Situação"];
            }

            return consulta;
        }

        public void Update(Consulta consulta)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;

            cmd.CommandText = @"AltConsulta @nr, @status, @diagnostico";

            cmd.Parameters.AddWithValue("@nr", consulta.Nr);
            cmd.Parameters.AddWithValue("@status", Convert.ToInt32(consulta.Status));
            cmd.Parameters.AddWithValue("@diagnostico", consulta.Diagnostico);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int nr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"delete c from consulta c where nr = @nr and status != 2";
            cmd.Parameters.AddWithValue("@Nr", nr);
            cmd.ExecuteNonQuery();
        }
    }
}
