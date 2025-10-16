using Mesas.DAO;
using Org.BouncyCastle.Ocsp;
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
    public partial class frmAdicionarProdutoView : Form
    {
        private readonly int mesaId;
        public frmAdicionarProdutoView(int mesaId)
        {
            InitializeComponent();
            this.mesaId = mesaId;
            CarregarProdutosComboBox();
        }
        private void MesaView_Load(object sender, EventArgs e)
        {
            this.Text = $"Mesa {mesaId:D2}";

            lblTitulo.Text = $"Mesa {mesaId:D2}";
            MesasProdutosDAO mesasProdutosDAO = new MesasProdutosDAO();

        }
        private void CarregarProdutosComboBox()

        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            var produtos = produtoDAO.GetProdutosParaComboBox();

            cmbProduto.DataSource = produtos;
            cmbProduto.DisplayMember = "NomeComValor";
            cmbProduto.ValueMember = "IdProduto";
            cmbProduto.SelectedIndex = -1; 
            cmbProduto.DropDownStyle = ComboBoxStyle.DropDownList; // nao deixa digitar digitar
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (cmbProduto.SelectedValue != null && int.TryParse(mskQuantidade.Text, out int quantidade))
            {
                int produtoId = (int)cmbProduto.SelectedValue;
                MesasProdutosDAO dao = new MesasProdutosDAO();
                dao.AdicionarProduto(mesaId, produtoId, quantidade);

                MessageBox.Show("Produto adicionado com sucesso!");
                this.Close(); // fecha o form ou atualiza a tela da mesa
            }
            else
            {
                MessageBox.Show("Selecione um produto e informe a quantidade.");
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
