using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mesas.Model
{
    public class MesasProduto
    {
        public int IdMesa{ get; set; }
        public int Numero { get; set; }
        public StatusMesa Status { get; set; }
        public int QuantidadePessoas { get; set; }
        public enum StatusMesa
        {
            livre,
            ocupada,
            desativada
        }
    }

}