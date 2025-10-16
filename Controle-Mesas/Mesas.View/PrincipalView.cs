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
using static Mesas.Model.MesasProduto;

namespace Controle_Mesas
{
    public partial class frmPrincipalView : Form
    {
        private MesasProdutosDAO mesaDAO;
        public frmPrincipalView()
        {
            InitializeComponent();
            mesaDAO = new MesasProdutosDAO();
            AtualizarStatusMesas();
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
        private void BtnMesa_Click(object sender, EventArgs e)
        {
            Button botao = sender as Button;

            int mesaId = int.Parse(botao.Text);

            frmMesaView formMesa = new frmMesaView(mesaId);

            formMesa.Show();
        }
        private void AtualizarStatusMesas()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button btn && btn.Name.StartsWith("btnMesa"))
                {
                    // extrai o número da mesa do nome do botão
                    int numeroMesa = int.Parse(btn.Name.Replace("btnMesa", ""));
                    int mesaId = mesaDAO.ObterMesaIdPorNumero(numeroMesa); // pega o id real do banco

                    StatusMesa status = mesaDAO.ObterStatusMesa(mesaId);

                    // botão de pessoas correspondente
                    string nomeBtnPessoas = $"btnPessoaMesa{numeroMesa}";
                    Button btnPessoas = this.Controls.Find(nomeBtnPessoas, true).FirstOrDefault() as Button;

                    switch (status)
                    {
                        case StatusMesa.livre:
                            btn.BackColor = SystemColors.Control;
                            if (btnPessoas != null) btnPessoas.Visible = false;
                            break;

                        case StatusMesa.ocupada:
                            btn.BackColor = Color.LimeGreen;
                            int pessoas = mesaDAO.ObterQtdPessoasMesa(mesaId);

                            if (btnPessoas != null)
                            {
                                btnPessoas.Visible = true;
                                btnPessoas.Enabled = false; // torna impossível clicar
                                btnPessoas.BackColor = Color.DarkGreen;
                                btnPessoas.Text = pessoas.ToString();
                            }
                            break;

                        case StatusMesa.desativada:
                            btn.BackColor = Color.Gray;
                            btn.Enabled = false; // torna impossível clicar
                            if (btnPessoas != null) btnPessoas.Visible = false;

                            btn.Click -= BtnMesa_Click; // remove clique normal (se estiver atribuído)
                            btn.Click += (s, e) => MessageBox.Show("Mesa indisponível!");
                            break;


                    }
                    btn.Visible = true;
                }
            }
        }
        private void CarregarDados_Click(object sender, EventArgs e)
        {
            AtualizarStatusMesas();
        }
    }
}
