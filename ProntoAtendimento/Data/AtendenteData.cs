using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProntoAtendimento.Models;

namespace ProntoAtendimento.Data
{
    public class AtendenteData : Data
    {


        // O Crud
        // Metódos para manipular a tabela Cliente do banco de dados
        // Create é uma operação de INSERT no banco de dados

        public void Create(Atendente atendente)
        {
            
            //cmd é um comando que permitirá executar um comando SQL
            SqlCommand cmd = new SqlCommand();
            //Conectando com o banco de dados
            cmd.Connection = base.connectionDB;
            //Criando a string SQL
            cmd.CommandText = @"CadAtendente @nome, @cpf, @endereco, @telefone,@login, @senha";


            //Colocando os dados recebidos pelo objeto cliente, na string SQL
            cmd.Parameters.AddWithValue("@nome", atendente.Nome);
            cmd.Parameters.AddWithValue("@cpf", atendente.Cpf);
            cmd.Parameters.AddWithValue("@endereco", atendente.Endereco);
            cmd.Parameters.AddWithValue("@telefone", atendente.Telefone);
            cmd.Parameters.AddWithValue("@login", atendente.Login);
            cmd.Parameters.AddWithValue("@senha", atendente.Senha);
           

            //Execução da string SQL no banco de dados
            cmd.ExecuteNonQuery();
        }
        

        /* O metódo Read é uma operação SELECT no banco de dados
         * Este metódo faz uma consulta no banco de dados e retorna uma lista
         * com vários registros (no caso todos os registros da tabela) 
         * caso a tabela esteja vazia ele retornará uma lista vazia
         */
        public List<Atendente> Read()
        {
            List<Atendente> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
                cmd.Connection = base.connectionDB; //Conexão com o banco de dados
                cmd.CommandText = "select * from v_atendentes order by nome";

                /*O objeto reader receberá os dados da tabela cliente,
                 * quando executado o comando SELECT (resultado do select)
                 */
                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Atendente>();
                while (reader.Read())
                {
                    Atendente atendente = new Atendente();
                    atendente.Id = (int)reader["Id"];
                    atendente.Nome = (string)reader["nome"];
                    atendente.Cpf = (string)reader["cpf"];
                    atendente.Endereco = (string)reader["endereco"];
                    atendente.Telefone = (string)reader["telefone"];
                    atendente.Status = (string)reader["Situação"];
                    atendente.Login = (string)reader["login"];
                    atendente.Senha = (string)reader["senha"];


                    lista.Add(atendente);
                }
            }
            catch (SqlException sqlerror) { Console.WriteLine("Erro na Leitura." + sqlerror); }
            return lista;
        }





        //Metódo que fará uma consulta do cliente pelo id
        public Atendente Read(int id)
        {
            //Declarando um objeto cliente e incializando como null
            Atendente atendente = null;

            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; //Conexão com o banco de dados

            //String SQL para ser executada no banco de dados
            cmd.CommandText = @"select * from v_atendentes WHERE Id = @id ";

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
                atendente = new Atendente
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["nome"],
                    Cpf = (string)reader["cpf"],
                    Endereco = (string)reader["endereco"],
                    Telefone = (string)reader["telefone"],
                    Status = (string)reader["Situação"],
                    Login = (string)reader["login"],
                    Senha = (string)reader["senha"],

                };
            }

            /*Retornando o objeto cliente, que pode ser null ou com as informações
             *que foram recebidas da consulta
             */
            return atendente;
        }



        public Atendente Read(string cpf)
        {
            //Declarando um objeto cliente e inicializando como null
            Atendente atendente = null;

            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; // Conexão com o banco de dados

            //String SQL para ser executada no banco de dados
            cmd.CommandText = @"v_atendentes WHERE cpf = @cpf";

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
                atendente = new Atendente
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["nome"],
                    Cpf = (string)reader["cpf"],
                    Endereco = (string)reader["endereco"],
                    Telefone = (string)reader["telefone"],
                    Status = (string)reader["Situação"],
                    Login = (string)reader["login"],
                    Senha = (string)reader["senha"],
                };
            }

            /*Retornando o objeto cliente, que pode ser null ou com as informações
             *que foram recebidas da consulta
             */
            return atendente;
        }


        public void Update(Atendente atendente)
        {
            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; // Conexão com o banco de dados

            //Criação da string SQL (comando SQL)
            cmd.CommandText = @"AltAtendente @id, @nome, @cpf, @endereco, @telefone,@status, @login, @senha";

            //Colocando os dados recebidos pelo objeto cliente, na string SQL


            cmd.Parameters.AddWithValue("@id", atendente.Id);
            cmd.Parameters.AddWithValue("@nome", atendente.Nome);
            cmd.Parameters.AddWithValue("@cpf", atendente.Cpf);
            cmd.Parameters.AddWithValue("@endereco", atendente.Endereco);
            cmd.Parameters.AddWithValue("@telefone", atendente.Telefone);
            cmd.Parameters.AddWithValue("@status", Convert.ToInt32(atendente.Status));
            cmd.Parameters.AddWithValue("@login", atendente.Login);
            cmd.Parameters.AddWithValue("@senha", atendente.Senha);

            //Execução da string SQL no banco de dados
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; // Conexão com o banco de dados

            //Criação da string SQL (comando SQL)
            cmd.CommandText = @"DELETE FROM Atendentes WHERE atendente_id=@id";   //ARRUMAR

            //Colocando os dados recebidos pelo objeto cliente, na string SQL
            cmd.Parameters.AddWithValue("@id", id);

            //Execução da string SQL no banco de dados
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"DELETE FROM pessoas WHERE Id=@id2";
            cmd.Parameters.AddWithValue("@id2", id);

            //Execução da string SQL no banco de dados
            cmd.ExecuteNonQuery();
        }


        public Atendente Read(AtendenteViewModel model)
        {
            //declarando um objeto cliente e inicializando como null

            Atendente atendente = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;//conexão com o Banco de Dados

            //string SQL para ser executada no Banco de Dados
            cmd.CommandText = @"select v_ate.Id, v_ate.nome, v_ate.telefone, ate.login from atendentes ate, v_atendentes v_ate
                                         where  ate.login = @login and ate.senha= @senha and v_ate.Id = ate.atendente_id"; 
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

                atendente = new Atendente
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["nome"],
                    Login = (string)reader["login"],
                    
                };
            }

            //retornando o objeto cliente, que pode ser null ou com as informações
            //recebidas na consulta
            return atendente;
        }//consulta id















    }
}
