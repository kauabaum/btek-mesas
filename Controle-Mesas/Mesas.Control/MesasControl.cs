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
    public class MesasProdutoControl
    {
        private MesasProdutosDAO mesasDAO = new MesasProdutosDAO();

        public DataTable GetAllMesasProdutos()
        {
            return mesasDAO.GetAll();
        }
    }
}
