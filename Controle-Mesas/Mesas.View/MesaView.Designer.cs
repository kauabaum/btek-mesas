namespace Controle_Mesas
{
    partial class frmMesaView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMesaView));
            this.btnFinalizarMesa = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gridPedidos = new System.Windows.Forms.DataGridView();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnAtualizarMesa = new System.Windows.Forms.Button();
            this.btnAdicionarPedido = new System.Windows.Forms.Button();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtNumeroPessoas = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFinalizarMesa
            // 
            this.btnFinalizarMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarMesa.Location = new System.Drawing.Point(12, 393);
            this.btnFinalizarMesa.Name = "btnFinalizarMesa";
            this.btnFinalizarMesa.Size = new System.Drawing.Size(114, 61);
            this.btnFinalizarMesa.TabIndex = 2;
            this.btnFinalizarMesa.Text = "F7 - Finalizar Mesa";
            this.toolTip1.SetToolTip(this.btnFinalizarMesa, "Finalizar a Mesa");
            this.btnFinalizarMesa.UseVisualStyleBackColor = true;
            this.btnFinalizarMesa.Click += new System.EventHandler(this.btnFinalizarMesa_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(137, 31);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Mesa XX |";
            this.toolTip1.SetToolTip(this.lblTitulo, "Mesa");
            // 
            // gridPedidos
            // 
            this.gridPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPedidos.Location = new System.Drawing.Point(12, 67);
            this.gridPedidos.Name = "gridPedidos";
            this.gridPedidos.Size = new System.Drawing.Size(949, 319);
            this.gridPedidos.TabIndex = 6;
            this.toolTip1.SetToolTip(this.gridPedidos, "Pedidos da Mesa");
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(713, 421);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(248, 33);
            this.txtValor.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtValor, "Valor Final");
            // 
            // btnAtualizarMesa
            // 
            this.btnAtualizarMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarMesa.Location = new System.Drawing.Point(132, 393);
            this.btnAtualizarMesa.Name = "btnAtualizarMesa";
            this.btnAtualizarMesa.Size = new System.Drawing.Size(114, 61);
            this.btnAtualizarMesa.TabIndex = 11;
            this.btnAtualizarMesa.Text = "F5 - Atualizar Mesa";
            this.toolTip1.SetToolTip(this.btnAtualizarMesa, "Atualizar Pedidos na Mesa");
            this.btnAtualizarMesa.UseVisualStyleBackColor = true;
            this.btnAtualizarMesa.Click += new System.EventHandler(this.CarregarMesa_Click);
            // 
            // btnAdicionarPedido
            // 
            this.btnAdicionarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarPedido.Location = new System.Drawing.Point(252, 393);
            this.btnAdicionarPedido.Name = "btnAdicionarPedido";
            this.btnAdicionarPedido.Size = new System.Drawing.Size(114, 61);
            this.btnAdicionarPedido.TabIndex = 12;
            this.btnAdicionarPedido.Text = "F3 - Adicionar Pedido";
            this.toolTip1.SetToolTip(this.btnAdicionarPedido, "Adicionar Pedido na Mesa");
            this.btnAdicionarPedido.UseVisualStyleBackColor = true;
            this.btnAdicionarPedido.Click += new System.EventHandler(this.AdicionarProduto_Click);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(537, 15);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(187, 38);
            this.txtPesquisar.TabIndex = 15;
            this.toolTip1.SetToolTip(this.txtPesquisar, "Pesquisar Pedido");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 31);
            this.label1.TabIndex = 19;
            this.label1.Text = "№ de Pessoas :";
            this.toolTip1.SetToolTip(this.label1, "Mesa");
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarTodos.BackgroundImage = global::Controle_Mesas.Properties.Resources.mostratudo;
            this.btnMostrarTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMostrarTodos.FlatAppearance.BorderSize = 0;
            this.btnMostrarTodos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnMostrarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarTodos.Location = new System.Drawing.Point(817, 12);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(44, 43);
            this.btnMostrarTodos.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnMostrarTodos, "Mostrar tudo");
            this.btnMostrarTodos.UseVisualStyleBackColor = false;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // btPesquisar
            // 
            this.btPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.btPesquisar.BackgroundImage = global::Controle_Mesas.Properties.Resources.pesquisar2;
            this.btPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPesquisar.FlatAppearance.BorderSize = 0;
            this.btPesquisar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btPesquisar.Location = new System.Drawing.Point(730, 12);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(44, 43);
            this.btPesquisar.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btPesquisar, "Pesquisar");
            this.btPesquisar.UseVisualStyleBackColor = false;
            this.btPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackgroundImage = global::Controle_Mesas.Properties.Resources.remover;
            this.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Location = new System.Drawing.Point(917, 12);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(44, 43);
            this.btnExcluir.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnExcluir, "Excluir");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.Transparent;
            this.btnSalvar.BackgroundImage = global::Controle_Mesas.Properties.Resources.confirmarnovo;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Location = new System.Drawing.Point(867, 12);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(44, 43);
            this.btnSalvar.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnSalvar, "Salvar");
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvarAlteracoes_Click);
            // 
            // txtNumeroPessoas
            // 
            this.txtNumeroPessoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroPessoas.Location = new System.Drawing.Point(357, 15);
            this.txtNumeroPessoas.Name = "txtNumeroPessoas";
            this.txtNumeroPessoas.Size = new System.Drawing.Size(121, 38);
            this.txtNumeroPessoas.TabIndex = 20;
            this.toolTip1.SetToolTip(this.txtNumeroPessoas, "Numero de Pessoas");
            this.txtNumeroPessoas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantidadePessoas_KeyDown);
            // 
            // frmMesaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(973, 466);
            this.Controls.Add(this.txtNumeroPessoas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.btPesquisar);
            this.Controls.Add(this.btnAdicionarPedido);
            this.Controls.Add(this.btnAtualizarMesa);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.gridPedidos);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnFinalizarMesa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmMesaView";
            this.Text = "Mesa";
            this.Load += new System.EventHandler(this.MesaView_Load);
            this.Click += new System.EventHandler(this.MesaView_Click);
            ((System.ComponentModel.ISupportInitialize)(this.gridPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFinalizarMesa;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView gridPedidos;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAtualizarMesa;
        private System.Windows.Forms.Button btnAdicionarPedido;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroPessoas;
    }
}