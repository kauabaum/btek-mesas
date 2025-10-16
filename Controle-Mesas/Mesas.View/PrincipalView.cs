using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_Mesas
{
    public partial class frmPrincipalView : Form
    {
        public frmPrincipalView()
        {
            InitializeComponent();
        }
        private void CriarProduto_Click(object sender, EventArgs e)
        {
            frmCriarProduto add = new frmCriarProduto();
            add.ShowDialog();
        }
        private void Cardapio_Click(object sender, EventArgs e)
        {
            frmCardapio add = new frmCardapio();
            add.ShowDialog();
        }
        private void Config_Click(object sender, EventArgs e)
        {
            frmConfig add = new frmConfig();
            add.ShowDialog();
        }
    }
}
