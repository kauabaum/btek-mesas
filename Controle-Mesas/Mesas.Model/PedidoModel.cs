using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mesas.Model
{
    public class Pedido
    {
        public int IdPedido{ get; set; }
        public int IdMesa { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

    }

}