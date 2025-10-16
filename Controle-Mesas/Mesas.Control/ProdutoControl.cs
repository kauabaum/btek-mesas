using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mesas.DAO;
using Mesas.Model;

namespace Mesas.Control
{
    public class ProdutoControl
    {
        private ProdutoDAO produtoDAO = new ProdutoDAO();

        public DataTable GetAllProdutos()
        {
            return produtoDAO.GetAll();
        }

        public DataTable GetProdutoAsDataTable(string nome)
        {
            return produtoDAO.GetProdutoAsDataTable(nome);
        }

        public Produto GetProdutoByProduto(string nome)
        {
            return produtoDAO.GetByProduto(nome);
        }

        public void AddProduto(Produto produto)
        {
            produtoDAO.Add(produto);
        }

        public void UpdateProduto(Produto produto)
        {
            produtoDAO.Update(produto);
        }

        public void DeleteProduto(Produto produto)
        {
            produtoDAO.Delete(produto);
        }
    }
}
