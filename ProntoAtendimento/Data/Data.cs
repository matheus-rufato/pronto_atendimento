﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProntoAtendimento.Data
{
    public abstract class Data : IDisposable
    {

        // Atributo vai nos permitir conectar com o BD
        protected SqlConnection connectionDB;

        public Data()
        {
            try
            {
                // String conexão com o BD
                string strConexao = @"Data Source = localhost;
                                    Initial Catalog = prontoAtendimento
                                    Integrated Security= true";
                //User Id=sa; Password = Matheus123; //Complementa

                connectionDB = new SqlConnection(strConexao);
                connectionDB.Open();

            }
            catch (SqlException er)
            {
                Console.WriteLine("Erro do banco " + er);
            }
        }
        public void Dispose()
        {
                connectionDB.Close();
        }

    }
}
