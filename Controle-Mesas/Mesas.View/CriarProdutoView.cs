using Mesas.DAO;
using Mesas.Model;
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
    public partial class frmCriarProduto : Form
    {
        public frmCriarProduto()
        {
            InitializeComponent();
            CarregarDados();
        }

        // carrega no grid
        private ProdutoDAO produtoDAO = new ProdutoDAO();
        private void CarregarDados()
        {
            try
            {
                DataTable dataTable = produtoDAO.GetAll();
                dataGridView1.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtPreco.Enabled = true;
            txtNome.Enabled = true;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string preco = txtPreco.Text;

                if (string.IsNullOrEmpty(nome))
                {
                    MessageBox.Show("O Nome é obrigatório.");
                    return;
                }

                if (string.IsNullOrEmpty(preco))
                {
                    MessageBox.Show("O Preco é obrigatório.");
                    return;
                }
                if (produtoIdSelecionado.HasValue)
                {
                    // atualiza
                    Produto produtoAtualizado = new Produto()
                    {
                        IdProduto = produtoIdSelecionado.Value,
                        Nome = nome,
                        Preco = Convert.ToDecimal(preco)

                    };

                    produtoDAO.Update(produtoAtualizado);
                    MessageBox.Show("Produto atualizado com sucesso!");
                }
                else
                {
                    // adiciona
                    Produto novoProduto = new Produto()
                    {
                        Nome = nome,
                        Preco = Convert.ToDecimal(preco)
                    };

                    produtoDAO.Add(novoProduto);
                    MessageBox.Show("Produto salvo com sucesso!");
                }

                txtPreco.Enabled = false;
                txtPreco.Text = string.Empty;
                txtNome.Enabled = false;
                txtNome.Text = string.Empty;
                produtoIdSelecionado = null;

                // recarrega
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cliente: {ex.Message}");
            }

        }
        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            txtPreco.Enabled = true;
            txtNome.Enabled = true;
            txtNome.ResetText();
            txtPreco.ResetText();
        }
        private int? produtoIdSelecionado = null;
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // pega o id
                    produtoIdSelecionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_Produto"].Value);
                }
                else
                {
                    MessageBox.Show("Selecione um produto para editar.");
                }

                if (produtoIdSelecionado.HasValue)
                {
                    // deleta
                    Produto produtoAtualizado = new Produto()
                    {
                        IdProduto = produtoIdSelecionado.Value,
                    };

                    produtoDAO.Delete(produtoAtualizado);
                    MessageBox.Show("Produto Excluído com sucesso!");

                    txtPreco.Enabled = false;
                    txtPreco.Text = string.Empty;
                    txtNome.Enabled = false;
                    txtNome.Text = string.Empty;

                    CarregarDados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Excluir cliente: {ex.Message}");
            }
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;

                if (string.IsNullOrEmpty(nome))
                {
                    MessageBox.Show("O Nome é obrigatório.");
                    return;
                }

                var produto = produtoDAO.GetByProduto(nome);

                if (produto != null)
                {
                    DataTable dataTable = produtoDAO.GetProdutoAsDataTable(nome);
                    dataGridView1.DataSource = dataTable;

                }
                else
                {
                    MessageBox.Show("Produto não encontrado.");
                }

                txtPreco.Enabled = false;
                txtPreco.Text = string.Empty;
                txtNome.Enabled = false;
                txtNome.Text = string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produto: {ex.Message}");
            }
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPreco.Enabled = false;
            txtPreco.Text = string.Empty;
            txtNome.Enabled = false;
            txtNome.Text = string.Empty;
            txtNome.ResetText();
            txtPreco.ResetText();
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                produtoIdSelecionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_Produto"].Value);

                string nome = dataGridView1.SelectedRows[0].Cells["Nome"].Value.ToString();
                string preco = dataGridView1.SelectedRows[0].Cells["Preco"].Value.ToString();

                txtNome.Text = nome;
                txtPreco.Text = preco;

                txtNome.Enabled = true;
                txtPreco.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selecione um produto para editar.");
            }
        }
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CarregarDados();
            txtNome.ResetText();
            txtPreco.ResetText();
        }
    }
}
