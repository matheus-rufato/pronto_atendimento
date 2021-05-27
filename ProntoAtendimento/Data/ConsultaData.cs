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


                /*ExecuteScalar: executa a consulta e retora a primeira coluna
                 *da primeira linha no conjuto de resultados retornado pela consulta.
                 *Colunas ou linhas adicionais são ignoradas.
                 */

                int Nr = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (var item in consulta.Itens)
                {
                    SqlCommand cmdItem = new SqlCommand();
                    cmdItem.Connection = base.connectionDB;
                    cmdItem.Transaction = transaction;
                    cmdItem.CommandText = @"CadUtiliza(@consulta, @procedimento, @obs)";

                    cmdItem.Parameters.AddWithValue("@consulta", idPedido);
                    cmdItem.Parameters.AddWithValue("@procedimento", item.Produto.IdProduto);
                    cmdItem.Parameters.AddWithValue("@obs", item.Quantidade);
                    cmdItem.Parameters.AddWithValue("@preco", item.Valor);


                    @consulta int, @procedimento int, @obs varchar(max) = null
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

        public List<Pedido> Read(int idCliente)
        {
            List<Pedido> lista = new List<Peidido>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = "SELECT * FROM pedido WHERE IdCliente = @idCliente";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pedido p = new Pedido();
                p.IdPedido = (int)reader["IdPedido"];
                p.IdCliente = (int)reader["IdCliente"];
                p.Data = (DateTime)reader["Data"];

                lista.Add(p);
            }
            return lista;
        }
    }












}
}
