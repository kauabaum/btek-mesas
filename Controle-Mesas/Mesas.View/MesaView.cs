using Mesas.DAO;
using Mesas.Model;
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
using static Mesas.Model.MesasProduto;

namespace Controle_Mesas
{
    public partial class frmMesaView : Form
    {
        private readonly int mesaId;
        private MesasProdutosDAO mesaDAO;
        private ProdutoDAO produtoDAO;
        public frmMesaView(int mesaId)
        {
            InitializeComponent();
            this.mesaId = mesaId;
            mesaDAO = new MesasProdutosDAO();
            produtoDAO = new ProdutoDAO();
            CarregarDados();
            ConfigurarGrid();
        }
        private void MesaView_Load(object sender, EventArgs e)
        {
            this.Text = $"Mesa {mesaId:D2}";

            lblTitulo.Text = $"Mesa {mesaId:D2} |";
            MesasProdutosDAO mesasProdutosDAO = new MesasProdutosDAO();
            ProdutoDAO produtoDAO = new ProdutoDAO();

            txtValor.ReadOnly = true;
            txtValor.TabStop = false; // impede tabulação
            txtValor.BackColor = SystemColors.Control; // mesma cor do fundo padrão
            txtValor.BorderStyle = BorderStyle.None; // remove as borda
            txtValor.Cursor = Cursors.Default; // remove o cursor de texto
            txtValor.SelectionLength = 0; // tira seleção
            txtValor.SelectionStart = txtValor.Text.Length;
            this.ActiveControl = null; // tira o foco do textbox
            AtualizarValorTotal();

        }
        private PedidoDAO pedidoDAO = new PedidoDAO();
        private void CarregarDados()
        {
            try
            {
                // busca apenas os pedidos da mesa atual
                DataTable dataTable = pedidoDAO.GetPedidoAsDataTableMesa(mesaId);
                gridPedidos.DataSource = dataTable;

                gridPedidos.Columns["Id_Produto"].Visible = false;
                gridPedidos.Columns["Id_Pedido"].Visible = false;
                gridPedidos.Columns["Id_Mesa"].Visible = false;

                // busca quantidade de pessoas e preenche
                int pessoas = mesaDAO.ObterQtdPessoasMesa(mesaId);
                txtNumeroPessoas.Text = pessoas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }
        private void AtualizarQuantidadePessoas()
        {
            if (int.TryParse(txtNumeroPessoas.Text, out int novaQuantidade))
            {
                try
                {
                    mesaDAO.AtualizarQtdPessoasMesa(mesaId, novaQuantidade);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar quantidade de pessoas: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Informe um número válido!");
                txtNumeroPessoas.Text = mesaDAO.ObterQtdPessoasMesa(mesaId).ToString();
            }
        }
        private void txtQuantidadePessoas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // ao apertar Enter
            {
                AtualizarQuantidadePessoas();
                e.Handled = true;
                e.SuppressKeyPress = true;
                MessageBox.Show("Pessoas Atualizadas!");
            }
        }
        private void AtualizarValorTotal()
        {
            decimal total = pedidoDAO.ObterTotalMesa(mesaId);
            txtValor.Text = $"Total: R$ {total:N2}";
        }
        private void btnFinalizarMesa_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Tem certeza que deseja finalizar esta mesa?",
                "Finalizar Mesa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    pedidoDAO.RemoverPedidosPorMesa(mesaId);

                    mesaDAO.AtualizarQtdPessoas(mesaId, 0);

                    mesaDAO.AtualizarStatusMesa(mesaId, "livre");

                    txtValor.Text = "Total: R$ 0,00";
                    MessageBox.Show("Mesa finalizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // recarrega
                    CarregarDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao finalizar mesa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CarregarMesa_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
        private void AdicionarProduto_Click(object sender, EventArgs e)
        {
            frmAdicionarProdutoView add = new frmAdicionarProdutoView(mesaId);
            add.ShowDialog();
        }
        private void ConfigurarGrid()
        {
            gridPedidos.ReadOnly = false; // permite edição
            gridPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridPedidos.MultiSelect = false;

            // apenas a quantidade
            foreach (DataGridViewColumn col in gridPedidos.Columns)
            {
                if (col.Name != "Quantidade")
                    col.ReadOnly = true;
            }
        }
        private void gridPedidos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = gridPedidos.Rows[e.RowIndex];

            if (gridPedidos.Columns[e.ColumnIndex].Name == "Quantidade")
            {
                int pedidoId = Convert.ToInt32(row.Cells["Id_Pedido"].Value);
                int novaQuantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);

                PedidoDAO pedidoDAO = new PedidoDAO();
                pedidoDAO.AtualizarQuantidade(pedidoId, novaQuantidade);

                AtualizarValorTotal();
            }
        }
        private void btnSalvarAlteracoes_Click(object sender, EventArgs e)
        {
            PedidoDAO pedidoDAO = new PedidoDAO();

            foreach (DataGridViewRow row in gridPedidos.Rows)
            {
                if (row.IsNewRow) continue;

                int pedidoId = Convert.ToInt32(row.Cells["Id_Pedido"].Value);
                int novaQuantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);

                pedidoDAO.AtualizarQuantidade(pedidoId, novaQuantidade);
            }

            MessageBox.Show("Alterações salvas com sucesso!");
            CarregarDados();
            AtualizarValorTotal();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string filtro = txtPesquisar.Text.Trim().Replace("'", "''");

            if (gridPedidos.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.IsNullOrEmpty(filtro)
                    ? "" 
                    : $"Nome_Produto LIKE '%{filtro}%'";
            }
        }
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
        private int? pedidoIdSelecionado = null;
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridPedidos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um pedido para excluir.");
                    return;
                }

                int pedidoId = Convert.ToInt32(gridPedidos.SelectedRows[0].Cells["Id_Pedido"].Value);

                var confirm = MessageBox.Show(
                    "Deseja realmente excluir este pedido?",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    pedidoDAO.Delete(pedidoId);

                    MessageBox.Show("Pedido excluído com sucesso!");

                    CarregarDados();
                    AtualizarValorTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir pedido: {ex.Message}");
            }
        }

    }
}
