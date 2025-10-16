using Mesas.DAO;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mesas.Model.MesasProduto;

namespace Controle_Mesas
{
    public partial class frmPrincipalView : Form
    {
        private MesasProdutosDAO mesaDAO;
        private Dictionary<Control, Rectangle> controlesOriginais = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> fontesOriginais = new Dictionary<Control, float>();
        private Size formOriginalSize;
        private bool formatoBrasileiro = true;
        public frmPrincipalView()
        {
            InitializeComponent();
            mesaDAO = new MesasProdutosDAO();
            AtualizarStatusMesas();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            float scaleX = (float)this.ClientSize.Width / formOriginalSize.Width;
            float scaleY = (float)this.ClientSize.Height / formOriginalSize.Height;

            foreach (var kvp in controlesOriginais)
            {
                Control c = kvp.Key;
                Rectangle r = kvp.Value;

                // Redimensionamento proporcional separadamente
                c.Width = (int)(r.Width * scaleX);
                c.Height = (int)(r.Height * scaleY);
                c.Left = (int)(r.Left * scaleX);
                c.Top = (int)(r.Top * scaleY);

                // Se for botão btnPessoaMesa1 até btnPessoaMesa44, deixa redondo
                if (c is Button && c.Name.StartsWith("btnPessoaMesa"))
                {
                    int size = Math.Min(c.Width, c.Height); // garante círculo perfeito
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(0, 0, size, size);
                    c.Region = new Region(path);
                }
                if (controlesOriginais.ContainsKey(c))
                {
                    float originalFont = fontesOriginais[c];
                    float newFontSize = originalFont * Math.Min(scaleX, scaleY);
                    c.Font = new Font(c.Font.FontFamily, newFontSize, c.Font.Style);
                }
            }
        }
        private void MesaView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                // Exemplo: abrir tela de mesas
                AtualizarStatusMesas();
            }
        }
        private void SalvarControlesOriginais(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                controlesOriginais[c] = c.Bounds;
                fontesOriginais[c] = c.Font.Size; // salva tamanho da fonte

                if (c.HasChildren)
                    SalvarControlesOriginais(c); // recursivo para filhos
            }

            // Salva manualmente os labels do relógio
            fontesOriginais[lblHora] = lblHora.Font.Size;
            fontesOriginais[lblDataHora] = lblDataHora.Font.Size;
        }


        private void Form_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.ClientSize;   // salva o tamanho original do formulário
            SalvarControlesOriginais(this);       // salva todos os controles do form

            // Ativa o evento de redimensionamento
            this.Resize += Form1_Resize;
            for (int i = 1; i <= 44; i++)
            {
                // Busca o botão pelo nome
                Button btn = this.Controls["btnPessoaMesa" + i.ToString()] as Button;
                if (btn != null)
                {
                    // Define estilo flat e remove borda
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    // Cria região circular
                    GraphicsPath path = new GraphicsPath();
                    int size = Math.Min(btn.Width, btn.Height); // para ficar perfeitamente redondo
                    path.AddEllipse(0, 0, size, size);
                    btn.Region = new Region(path);
                }
            }
            Timer timerRelogio = new Timer();
            timerRelogio.Interval = 1000; // 1 segundo
            timerRelogio.Tick += TimerRelogio_Tick;
            timerRelogio.Start();
            this.WindowState = FormWindowState.Maximized;
        }
        private void CriarProduto_Click(object sender, EventArgs e)
        {
            frmCriarProduto add = new frmCriarProduto();
            add.ShowDialog();
        }
        private void PrincipalView_Click(object sender, EventArgs e)
        {
            AtualizarStatusMesas();
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
                            btn.BackColor = Color.FromArgb(40, 167, 69);
                            if (btnPessoas != null) btnPessoas.Visible = false;
                            break;

                        case StatusMesa.ocupada:
                            btn.BackColor = Color.FromArgb(220, 53, 69);
                            int pessoas = mesaDAO.ObterQtdPessoasMesa(mesaId);

                            if (btnPessoas != null)
                            {
                                btnPessoas.Visible = true;
                                btnPessoas.Enabled = false; // torna impossível clicar
                                btnPessoas.BackColor = Color.FromArgb(255, 193, 7);
                                btnPessoas.Text = pessoas.ToString();
                            }
                            if (btnPessoas.Text == "0")
                            {
                                btnPessoas.Visible = false;
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
        private void TimerRelogio_Tick(object sender, EventArgs e)
        {
            DateTime agora = DateTime.Now;

            // Hora atual: HH:mm:ss (24h)
            lblHora.Text = agora.ToString("HH:mm:ss");

            // Data e hora completa dependendo do formato
            if (formatoBrasileiro)
            {
                lblDataHora.Text = agora.ToString("dd/MM/yyyy"); // dd/MM/yyyy
            }
            else
            {
                lblDataHora.Text = agora.ToString("MM/dd/yyyy"); // MM/dd/yyyy
            }
        }

    }
}
