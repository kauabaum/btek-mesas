using Mesas.Control;
using Mesas.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Mesas.Model.MesasProduto;


namespace Mesas.DAO
{
    public class MesasProdutosDAO
    {
        private DbContext dbContext = new DbContext();

        //Carregar todos os dados
        public DataTable GetAll()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT mesas.id AS Id_MesasProduto, \r\n" +
                    "   mesas.numero AS Numero, \r\n" +
                    "   mesas.status AS Status, \r\n" +
                    "   mesas.quantidade_pessoas AS Quantidade_Pessoas \r\n" +
                    "FROM \r\n" +
                    "   mesas \r\n" +
                    "ORDER BY \r\n" +
                    "   mesas.numero \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
        public int ObterQtdPessoasMesa(int mesaId)
        {
            int qtdPessoas = 0;

            string query = "SELECT quantidade_pessoas FROM mesas WHERE id = @mesaId";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mesaId", mesaId);

                    object result = cmd.ExecuteScalar(); // retorna a primeira linha

                    if (result != null && result != DBNull.Value)
                    {
                        qtdPessoas = Convert.ToInt32(result);
                    }
                }
            }

            return qtdPessoas;
        }
        public void AtualizarQtdPessoasMesa(int mesaId, int quantidade)
        {
            string query = "UPDATE mesas SET quantidade_pessoas = @quantidade WHERE id = @mesaId";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@quantidade", quantidade);
                    cmd.Parameters.AddWithValue("@mesaId", mesaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public StatusMesa ObterStatusMesa(int mesaId)
        {
            // busca as pessoas
            int qtdPessoas = ObterQtdPessoasMesa(mesaId);

            int qtdPedidos = 0;
            string query = "SELECT COUNT(*) FROM pedido WHERE mesa_id = @mesaId";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mesaId", mesaId);
                    qtdPedidos = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            // status
            if (qtdPessoas > 0 || qtdPedidos > 0)
                return StatusMesa.ocupada;
            else
                return StatusMesa.livre;
        }

        public int ObterMesaIdPorNumero(int numeroMesa)
        {
            int mesaId = 0; // deixa padrao

            string query = "SELECT id FROM mesas WHERE numero = @numeroMesa";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@numeroMesa", numeroMesa);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        mesaId = Convert.ToInt32(result);
                    }
                }
            }

            return mesaId;
        }
        public void AtualizarStatusMesa(int mesaId, string status)
        {
            string query = "UPDATE mesas SET status = @status WHERE id = @mesaId";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mesaId", mesaId);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarQtdPessoas(int mesaId, int quantidade)
        {
            string query = "UPDATE mesas SET quantidade_pessoas = @pessoas WHERE id = @mesaId";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mesaId", mesaId);
                    cmd.Parameters.AddWithValue("@pessoas", quantidade);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AdicionarProduto(int mesaId, int produtoId, int quantidade)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                // verifica se ja tem
                string checkQuery = @"
            SELECT quantidade 
            FROM pedido 
            WHERE mesa_id = @mesaId AND produto_id = @produtoId";

                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@mesaId", mesaId);
                checkCmd.Parameters.AddWithValue("@produtoId", produtoId);

                object result = checkCmd.ExecuteScalar();

                if (result != null)
                {
                    // se tiver atualiza
                    int quantidadeAtual = Convert.ToInt32(result);
                    string updateQuery = @"
                UPDATE pedido 
                SET quantidade = @quantidade 
                WHERE mesa_id = @mesaId AND produto_id = @produtoId";

                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@quantidade", quantidadeAtual + quantidade);
                    updateCmd.Parameters.AddWithValue("@mesaId", mesaId);
                    updateCmd.Parameters.AddWithValue("@produtoId", produtoId);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    // se nao tiver cria um novo
                    string insertQuery = @"
                INSERT INTO pedido (mesa_id, produto_id, quantidade)
                VALUES (@mesaId, @produtoId, @quantidade)";

                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@mesaId", mesaId);
                    insertCmd.Parameters.AddWithValue("@produtoId", produtoId);
                    insertCmd.Parameters.AddWithValue("@quantidade", quantidade);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

    }
}
