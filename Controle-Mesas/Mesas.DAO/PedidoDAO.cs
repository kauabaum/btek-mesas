using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mesas.Model;
using Mesas.Control;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;


namespace Mesas.DAO
{
    public class PedidoDAO
    {
        private DbContext dbContext = new DbContext();

        // carregar dados
        public DataTable GetAll()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT pedido.id AS Id_Pedido, \r\n" +
                    "   pedido.produto_id AS Id_Produto, \r\n" +
                    "   pedido.mesa_id AS Id_Mesa, \r\n" +
                    "   produto.nome AS Nome_Produto, \r\n" +
                    "   pedido.quantidade AS Quantidade \r\n" +
                    "FROM \r\n" +
                    "   pedido \r\n" +
                    "INNER JOIN \r\n" +
                    "   produto ON produto.nome = produto.nome \r\n" +
                    "ORDER BY \r\n" +
                    "   produto.nome \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        // carregar no grid
        public DataTable GetPedidoAsDataTableMesa(int mesa_id)
        {
            string query = @"
        SELECT 
            pedido.id AS Id_Pedido,
            pedido.produto_id AS Id_Produto,
            pedido.mesa_id AS Id_Mesa,
            produto.nome AS Nome_Produto,
            pedido.quantidade AS Quantidade,
            produto.preco AS Preco_Unitario,
            (pedido.quantidade * produto.preco) AS Total
        FROM pedido
        INNER JOIN produto 
            ON pedido.produto_id = produto.id
        WHERE pedido.mesa_id = @mesa_id
        ORDER BY pedido.id;
    ";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mesa_id", mesa_id);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }



        // carregar pela mesa
        public Pedido GetByPedidoMesa(string Mesa)
        {
            Pedido pedido = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT pedido.id AS Id_Pedido, \r\n" +
                    "   pedido.produto_id AS Id_Produto, \r\n" +
                    "   pedido.mesa_id AS Id_Mesa, \r\n" +
                    "   produto.nome AS Nome_Produto, \r\n" +
                    "   pedido.quantidade AS Quantidade \r\n" +
                    "FROM \r\n" +
                    "   pedido \r\n" +
                    "INNER JOIN \r\n" +
                    "   produto ON produto.nome = produto.nome \r\n" +
                    "WHERE \r\n" +
                    "   pedido.mesa_id LIKE CONCAT('%',@mesa,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   pedido.mesa_id \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mesa", Mesa);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pedido = new Pedido()
                        {
                            IdPedido = reader.GetInt32("Id_Pedido"),
                            IdMesa = reader.GetInt32("Id_Mesa"),
                            IdProduto = reader.GetInt32("Id_Produto"),
                            Quantidade = reader.GetInt32("Quantidade")
                        };
                    }
                }
            }
            return pedido;
        }

        // adicionar pedido
        public void Add(Pedido pedido)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                // insere no pedidos
                string query = "INSERT INTO \r\n" +
                    "pedido \r\n" +
                        "(mesa_id, produto_id, quantidade) \r\n" +
                    "VALUES \r\n" +
                        "(@mesa_id, @produto_id, @quantidade) \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mesa_id", pedido.IdMesa);
                cmd.Parameters.AddWithValue("@produto_id", pedido.IdProduto);
                cmd.Parameters.AddWithValue("@quantidade", pedido.Quantidade);
                cmd.ExecuteNonQuery();
            }
        }

        // atualiza ou edita os dados
        public void Update(Pedido pedido)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "UPDATE \r\n" +
                    "   pedido \r\n" +
                    "SET \r\n" +
                    "   pedido.mesa_id = @mesa_id, \r\n" +
                    "   pedido.produto_id = @produto_id, \r\n" +
                    "   pedido.quantidade = @quantidade \r\n" +

                    "WHERE \r\n" +
                    "   pedido.id = @id_pedido\r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_pedido", pedido.IdPedido);
                cmd.Parameters.AddWithValue("@produto_id", pedido.IdProduto);
                cmd.Parameters.AddWithValue("@mesa_id", pedido.IdMesa);
                cmd.Parameters.AddWithValue("@quantidade", pedido.Quantidade);
                cmd.ExecuteNonQuery();
            }
        }

        // exclui os dados
        public void Delete(int idPedido)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM pedido WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idPedido);
                cmd.ExecuteNonQuery();
            }
        }

        public decimal ObterTotalMesa(int mesaId)
        {
            string query = @"
            SELECT 
                COALESCE(SUM(pedido.quantidade * produto.preco), 0) AS total
            FROM 
                pedido
            INNER JOIN 
                produto ON produto.id = pedido.produto_id
            WHERE 
            pedido.mesa_id = @mesaId;
    ";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mesaId", mesaId);
                    object result = cmd.ExecuteScalar();
                    return Convert.ToDecimal(result);
                }
            }
        }
        public void RemoverPedidosPorMesa(int mesaId)
        {
            string query = "DELETE FROM pedido WHERE mesa_id = @mesaId";

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mesaId", mesaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AtualizarQuantidade(int pedidoId, int quantidade)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = @"
            UPDATE pedido
            SET quantidade = @quantidade
            WHERE id = @pedidoId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@pedidoId", pedidoId);

                cmd.ExecuteNonQuery();
            }
        }


    }
}
