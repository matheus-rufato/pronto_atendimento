using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProntoAtendimento.Models;

namespace ProntoAtendimento.Data
{
    public class MedicoData : Data
    {



        // O Crud
        // Metódos para manipular a tabela Cliente do banco de dados
        // Create é uma operação de INSERT no banco de dados

        public void Create(Medico medico)
        {
            //cmd é um comando que permitirá executar um comando SQL
            SqlCommand cmd = new SqlCommand();
            //Conectando com o banco de dados
            cmd.Connection = base.connectionDB;
            //Criando a string SQL
            cmd.CommandText = @"CadMedico @nome, @cpf, @endereco, @telefone,@crm, @login, @senha";


            //Colocando os dados recebidos pelo objeto cliente, na string SQL
            cmd.Parameters.AddWithValue("@nome", medico.Nome);
            cmd.Parameters.AddWithValue("@cpf", medico.Cpf);
            cmd.Parameters.AddWithValue("@endereco", medico.Endereco);
            cmd.Parameters.AddWithValue("@telefone", medico.Telefone);
            cmd.Parameters.AddWithValue("@crm", medico.CRM);
            cmd.Parameters.AddWithValue("@login", medico.Login);
            cmd.Parameters.AddWithValue("@senha", medico.Senha);

            //Execução da string SQL no banco de dados
            cmd.ExecuteNonQuery();
        }


        /* O metódo Read é uma operação SELECT no banco de dados
         * Este metódo faz uma consulta no banco de dados e retorna uma lista
         * com vários registros (no caso todos os registros da tabela) 
         * caso a tabela esteja vazia ele retornará uma lista vazia
         */
        public List<Medico> Read()
        {
            List<Medico> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
                cmd.Connection = base.connectionDB; //Conexão com o banco de dados
                cmd.CommandText = "select * from v_medicos where Situação = 'Ativo'";

                /*O objeto reader receberá os dados da tabela cliente,
                 * quando executado o comando SELECT (resultado do select)
                 * 
                 * @nome varchar(50), @cpf varchar(14), @endereco varchar(50), @telefone varchar(14), 
                @crm varchar(6), @login varchar(14), @senha varchar(14)
                 */
                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Medico>();
                while (reader.Read())
                {
                    Medico medico = new Medico();
                    medico.Id = (int)reader["Id"];
                    medico.Nome = (string)reader["nome"];
                    medico.Cpf = (string)reader["cpf"];
                    medico.Endereco = (string)reader["endereco"];
                    medico.Telefone = (string)reader["telefone"];
                    medico.Status = (string)reader["Situação"];
                    medico.CRM = (string)reader["crm"];
                    /*medico.Login = (string)reader["login"];
                    medico.Senha = (string)reader["senha"];*/


                    lista.Add(medico);
                }
            }
            catch (SqlException sqlerror) { Console.WriteLine("Erro na Leitura." + sqlerror); }
            return lista;
        }



        public List<Medico> ReadAll()
        {
            List<Medico> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
                cmd.Connection = base.connectionDB; //Conexão com o banco de dados
                cmd.CommandText = "select * from v_medicos ";

                /*O objeto reader receberá os dados da tabela cliente,
                 * quando executado o comando SELECT (resultado do select)
                 * 
                 * @nome varchar(50), @cpf varchar(14), @endereco varchar(50), @telefone varchar(14), 
                @crm varchar(6), @login varchar(14), @senha varchar(14)
                 */
                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Medico>();
                while (reader.Read())
                {
                    Medico medico = new Medico();
                    medico.Id = (int)reader["Id"];
                    medico.Nome = (string)reader["nome"];
                    medico.Cpf = (string)reader["cpf"];
                    medico.Endereco = (string)reader["endereco"];
                    medico.Telefone = (string)reader["telefone"];
                    medico.Status = (string)reader["Situação"];
                    medico.CRM = (string)reader["crm"];
                    medico.Login = (string)reader["login"];
                    medico.Senha = (string)reader["senha"];


                    lista.Add(medico);
                }
            }
            catch (SqlException sqlerror) { Console.WriteLine("Erro na Leitura." + sqlerror); }
            return lista;
        }




        //Metódo que fará uma consulta do cliente pelo id
        public Medico Read(int id)
        {
            //Declarando um objeto cliente e incializando como null
            Medico medico = null;

            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; //Conexão com o banco de dados

            //String SQL para ser executada no banco de dados
            cmd.CommandText = @" select * from v_medicos WHERE Id = @id";

            //Inserindo o valor do id recebido a string SQL
            cmd.Parameters.AddWithValue("@Id", id);

            //Executando o comando SQL no banco de dados
            SqlDataReader reader = cmd.ExecuteReader();

            //Verificando se, após a consulta, retornou um registro
            if (reader.Read())
            {
                /*Instanciando o objeto declarado anteriormente
                 *e colocando os dados do registro da tabela no objeto
                 */
                medico = new Medico
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["nome"],
                    Cpf = (string)reader["cpf"],
                    Endereco = (string)reader["endereco"],
                    Telefone = (string)reader["telefone"],
                    Status = (string)reader["Situação"],
                    CRM = (string)reader["crm"]
                    //Login = (string)reader["login"],
                    //Senha = (string)reader["senha"]
                };
            }

            /*Retornando o objeto cliente, que pode ser null ou com as informações
             *que foram recebidas da consulta
             */
            return medico;
        }



        public Medico Read(string cpf)
        {
            //Declarando um objeto cliente e inicializando como null
            Medico medico = null;

            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; // Conexão com o banco de dados

            //String SQL para ser executada no banco de dados
            cmd.CommandText = @"select * from v_medicos WHERE cpf = @cpf";

            //Inserindo o valor do id recebido na string SQL
            cmd.Parameters.AddWithValue("@cpf", cpf);

            //Executando o comando SQL no banco
            SqlDataReader reader = cmd.ExecuteReader();

            //Verificando se, após a consulta, retornou um registro
            if (reader.Read())
            {
                /*Instanciando o objeto declarado anteriormente
                 *e colocando os dados do registro da tabela no objeto
                 */
                medico = new Medico
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["nome"],
                    Cpf = (string)reader["cpf"],
                    Endereco = (string)reader["endereco"],
                    Telefone = (string)reader["telefone"],
                    Status = (string)reader["Situação"],
                    CRM = (string)reader["crm"],
                    Login = (string)reader["login"],
                    Senha = (string)reader["senha"]
                };
            }

            /*Retornando o objeto cliente, que pode ser null ou com as informações
             *que foram recebidas da consulta
             */
            return medico;
        }


        public void Update(Medico medico)
        {
            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; // Conexão com o banco de dados

            //Criação da string SQL (comando SQL)
            cmd.CommandText = @"AltMedico @id, @nome, @cpf, @endereco, @telefone, @status,@crm, @login, @senha";

            //Colocando os dados recebidos pelo objeto cliente, na string SQL


            cmd.Parameters.AddWithValue("@id", medico.Id);
            cmd.Parameters.AddWithValue("@nome", medico.Nome);
            cmd.Parameters.AddWithValue("@cpf", medico.Cpf);
            cmd.Parameters.AddWithValue("@endereco", medico.Endereco);
            cmd.Parameters.AddWithValue("@telefone", medico.Telefone);
            cmd.Parameters.AddWithValue("@status", Convert.ToInt32(medico.Status));
            cmd.Parameters.AddWithValue("@crm", medico.CRM);
            cmd.Parameters.AddWithValue("@login", medico.Login);
            cmd.Parameters.AddWithValue("@senha", medico.Senha);

            //Execução da string SQL no banco de dados
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; // Conexão com o banco de dados

            //Criação da string SQL (comando SQL)
            cmd.CommandText = @"DELETE FROM medicos WHERE medico_id=@id";   //ARRUMAR

            //Colocando os dados recebidos pelo objeto cliente, na string SQL
            cmd.Parameters.AddWithValue("@id", id);

            //Execução da string SQL no banco de dados
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"DELETE FROM pessoas WHERE Id=@id2";
            cmd.Parameters.AddWithValue("@id2", id);
        }

        public Medico Read(MedicoViewModel model)
        {
            //declarando um objeto cliente e inicializando como null

            Medico medico = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;//conexão com o Banco de Dados

            //string SQL para ser executada no Banco de Dados
            cmd.CommandText = @"select v_med.Id, v_med.nome, v_med.telefone, med.login from medicos med, v_medicos v_med 
                                where med.login = @login and med.senha = @senha and v_med.Id = med.medico_id ";

            //inserindo o valor do id recebido a string SQL
            cmd.Parameters.AddWithValue("@login", model.Login);
            cmd.Parameters.AddWithValue("@senha", model.Senha);

            //Executando o comando SQL no Banco de Dados
            SqlDataReader reader = cmd.ExecuteReader();

            //verificando se, após a consulta, retornou um registro
            if (reader.Read())
            {
                //instanciando o objeto cliente declarado anteriormente
                //e colocando os dados do registro da tabela no objeto

                medico = new Medico
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["nome"],
                    Telefone = (string)reader["telefone"],
                    Login = (string)reader["login"]
                };
            }

            //retornando o objeto cliente, que pode ser null ou com as informações
            //recebidas na consulta
            return medico;
        }//consulta id




    }
}
