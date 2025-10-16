using Mesas.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mesas.DAO;

namespace Controle_Mesas
{
    public partial class frmCardapio : Form
    {
        public frmCardapio()
        {
            InitializeComponent();
            CarregarDados();
        }
        private ProdutoDAO produtoDAO = new ProdutoDAO();
        private void CarregarDados()
        {
            try
            {
                DataTable dataTable = produtoDAO.GetAll();
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["Id_Produto"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtPesquisar.Text;

                if (string.IsNullOrEmpty(nome))
                {
                    MessageBox.Show("O Nome é obrigatório.");
                    return;
                }

                var produto = produtoDAO.GetByProduto(nome);

                if (produto != null)
                {
                    // mostra no grid
                    DataTable dataTable = produtoDAO.GetProdutoAsDataTable(nome);
                    dataGridView1.DataSource = dataTable;

                }
                else
                {
                    MessageBox.Show("Produto não encontrado.");
                }


                txtPesquisar.ResetText();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produto: {ex.Message}");
            }
        }
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}
