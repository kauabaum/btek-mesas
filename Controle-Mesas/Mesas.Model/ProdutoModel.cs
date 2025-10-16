using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mesas.Model
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string NomeComValor
        {
            get
            {
                return $"{Nome} - R${Preco:F2}";
            }
        }
    }

}