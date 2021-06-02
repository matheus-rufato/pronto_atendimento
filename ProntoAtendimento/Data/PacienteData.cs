using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProntoAtendimento.Models;




namespace ProntoAtendimento.Data
{
    public class PacienteData:Data
    {


        // O Crud
        // Metódos para manipular a tabela Cliente do banco de dados
        // Create é uma operação de INSERT no banco de dados

        public void Create(Paciente paciente)
        {
            //cmd é um comando que permitirá executar um comando SQL
            SqlCommand cmd = new SqlCommand();
            //Conectando com o banco de dados
            cmd.Connection = base.connectionDB;
            //Criando a string SQL
            cmd.CommandText = @"CadPaciente(@nome, @cpf, @endereco, @telefone,@convenio)";


            //Colocando os dados recebidos pelo objeto cliente, na string SQL
            cmd.Parameters.AddWithValue("@nome", paciente.Nome);
            cmd.Parameters.AddWithValue("@cpf", paciente.Cpf);
            cmd.Parameters.AddWithValue("@endereco", paciente.Endereco);
            cmd.Parameters.AddWithValue("@telefone", paciente.Telefone);
            cmd.Parameters.AddWithValue("@convenio", paciente.Convenio);

            //Execução da string SQL no banco de dados
            cmd.ExecuteNonQuery();
        }


        /* O metódo Read é uma operação SELECT no banco de dados
         * Este metódo faz uma consulta no banco de dados e retorna uma lista
         * com vários registros (no caso todos os registros da tabela) 
         * caso a tabela esteja vazia ele retornará uma lista vazia
         */
        public List<Paciente> Read()
        {
            List<Paciente> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
                cmd.Connection = base.connectionDB; //Conexão com o banco de dados
                cmd.CommandText = "v_pacientes order by nome";

                /*O objeto reader receberá os dados da tabela cliente,
                 * quando executado o comando SELECT (resultado do select)
                 */
                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Paciente>();
                while (reader.Read())
                {
                    Paciente paciente = new Paciente();
                    paciente.Id = (int)reader["Id"];
                    paciente.Nome = (string)reader["nome"];
                    paciente.Cpf = (string)reader["cpf"];
                    paciente.Endereco = (string)reader["endereco"];
                    paciente.Telefone = (string)reader["telefone"];
                    paciente.Convenio = (string)reader["convenio"];


                    lista.Add(paciente);
                }
            }
            catch (SqlException sqlerror) { Console.WriteLine("Erro na Leitura." + sqlerror); }
            return lista;
        }





        //Metódo que fará uma consulta do cliente pelo id
        public Paciente Read(int id)
        {
            //Declarando um objeto cliente e incializando como null
            Paciente paciente = null;

            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; //Conexão com o banco de dados

            //String SQL para ser executada no banco de dados
            cmd.CommandText = @"v_pacientes WHERE Id = @id";

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
                paciente = new Paciente
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["nome"],
                    Cpf = (string)reader["cpf"],
                    Endereco = (string)reader["endereco"],
                    Telefone = (string)reader["telefone"],
                    Convenio = (string)reader["convenio"]

                };
            }

            /*Retornando o objeto cliente, que pode ser null ou com as informações
             *que foram recebidas da consulta
             */
            return paciente;
        }



        public Paciente Read(string cpf)
        {
            //Declarando um objeto cliente e inicializando como null
            Paciente paciente = null;

            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; // Conexão com o banco de dados

            //String SQL para ser executada no banco de dados
            cmd.CommandText = @"v_pacientes WHERE cpf = @cpf";

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
                paciente = new Paciente
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["nome"],
                    Cpf = (string)reader["cpf"],
                    Endereco = (string)reader["endereco"],
                    Telefone = (string)reader["telefone"],
                    Convenio = (string)reader["convenio"]
                };
            }

            /*Retornando o objeto cliente, que pode ser null ou com as informações
             *que foram recebidas da consulta
             */
            return paciente;
        }


        public void Update(Paciente paciente)
        {
            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; // Conexão com o banco de dados

            //Criação da string SQL (comando SQL)
            cmd.CommandText = @"AltPaciente(@id, @nome, @cpf, @endereco, @telefone, @status, @convenio)";

            //Colocando os dados recebidos pelo objeto cliente, na string SQL


            cmd.Parameters.AddWithValue("@id", paciente.Id);
            cmd.Parameters.AddWithValue("@nome", paciente.Nome);
            cmd.Parameters.AddWithValue("@cpf", paciente.Cpf);
            cmd.Parameters.AddWithValue("@endereco", paciente.Endereco);
            cmd.Parameters.AddWithValue("@telefone", paciente.Telefone);
            cmd.Parameters.AddWithValue("@status", paciente.Status);
            cmd.Parameters.AddWithValue("@convenio", paciente.Convenio);

            //Execução da string SQL no banco de dados
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(); //cmd é um comando que permitirá executar um comando SQL
            cmd.Connection = base.connectionDB; // Conexão com o banco de dados

            //Criação da string SQL (comando SQL)
            cmd.CommandText = @"DELETE FROM Cliente WHERE IdCliente=@id";   //ARRUMAR

            //Colocando os dados recebidos pelo objeto cliente, na string SQL
            cmd.Parameters.AddWithValue("@id", id);

            //Execução da string SQL no banco de dados
            cmd.ExecuteNonQuery();
        }


    }
}
