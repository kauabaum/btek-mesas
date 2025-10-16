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
    public class ProdutoDAO
    {
        private DbContext dbContext = new DbContext();

        // carrega os dados
        public DataTable GetAll()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT produto.id AS Id_Produto, \r\n" +
                    "   produto.nome AS Nome, \r\n" +
                    "   produto.preco AS Preco \r\n" +
                    "FROM \r\n" +
                    "   produto \r\n" +
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

        // carrega no grid
        public DataTable GetProdutoAsDataTable(string nome)
        {

            string query = "SELECT produto.id AS Id_Produto, \r\n" +
                "   produto.nome AS Nome, \r\n" +
                "   produto.preco AS Preco \r\n" +
                "FROM \r\n" +
                "   produto \r\n" +
                "WHERE \r\n" +
                "   produto.nome LIKE CONCAT('%',@nome,'%') \r\n" +
                "ORDER BY \r\n" +
                "   produto.nome \r\n";


            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", nome);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        // carrega pelo produto
        public Produto GetByProduto(string Nome)
        {
            Produto produto = null;

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();


                string query = "SELECT produto.id AS Id_Produto, \r\n" +
                    "   produto.nome AS Nome, \r\n" +
                    "   produto.preco AS Preco \r\n" +
                    "FROM \r\n" +
                    "   produto \r\n" +
                    "WHERE \r\n" +
                    "   produto.nome LIKE CONCAT('%',@nome,'%') \r\n" +
                    "ORDER BY \r\n" +
                    "   produto.nome \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", Nome);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        produto = new Produto()
                        {
                            IdProduto = reader.GetInt32("Id_Produto"),
                            Nome = reader.GetString("Nome"),
                            Preco = reader.GetDecimal("Preco")
                        };
                    }
                }
            }
            return produto;
        }

        // adicona o produto
        public void Add(Produto produto)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                // insere no produto
                string query = "INSERT INTO \r\n" +
                    "produto \r\n" +
                        "(nome, preco) \r\n" +
                    "VALUES \r\n" +
                        "(@nome, @preco) \r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", produto.Nome);
                cmd.Parameters.AddWithValue("@preco", produto.Preco);
                cmd.ExecuteNonQuery();
            }
        }

        // atualiza ou edita
        public void Update(Produto produto)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "UPDATE \r\n" +
                    "   produto \r\n" +
                    "SET \r\n" +
                    "   produto.nome = @nome, \r\n" +
                    "   produto.preco = @preco \r\n" +
                    "WHERE \r\n" +
                    "   produto.id = @id_produto\r\n";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_produto", produto.IdProduto);
                cmd.Parameters.AddWithValue("@nome", produto.Nome);
                cmd.Parameters.AddWithValue("@preco", produto.Preco);
                cmd.ExecuteNonQuery();
            }
        }

        // exclui os dados
        public void Delete(Produto produto)
        {
            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "DELETE \r\n" +
                    "FROM \r\n" +
                    "   produto \r\n" +
                    "WHERE \r\n" +
                    "   produto.id = @id_produto";


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_produto", produto.IdProduto);
                cmd.ExecuteNonQuery();
            }
        }
        // carregar no combobox
        public List<Produto> GetProdutosParaComboBox()
        {
            List<Produto> produtos = new List<Produto>();

            using (MySqlConnection conn = dbContext.GetConnection())
            {
                conn.Open();

                string query = "SELECT produto.id, produto.nome, produto.preco " +
                               "FROM produto " +
                               "ORDER BY produto.nome";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Produto produto = new Produto
                        {
                            IdProduto = reader.GetInt32("id"),
                            Nome = reader.GetString("nome"),
                            Preco = reader.GetDecimal("preco")
                        };

                        produtos.Add(produto);
                    }
                }
            }

            return produtos;
        }
    }
}
