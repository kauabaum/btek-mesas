namespace Controle_Mesas
{
    partial class frmCardapio
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btPesquisar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(6, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(139, 31);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Cardapio :";
            this.toolTip1.SetToolTip(this.lblTitulo, "Titulo");
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(580, 557);
            this.dataGridView1.TabIndex = 7;
            this.toolTip1.SetToolTip(this.dataGridView1, "Cardapio");
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(305, 21);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(207, 38);
            this.txtPesquisar.TabIndex = 16;
            this.toolTip1.SetToolTip(this.txtPesquisar, "Pesquisar Produto");
            // 
            // btPesquisar
            // 
            this.btPesquisar.BackColor = System.Drawing.SystemColors.Control;
            this.btPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPesquisar.Image = global::Controle_Mesas.Properties.Resources.pesquisa1;
            this.btPesquisar.Location = new System.Drawing.Point(527, 12);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(65, 55);
            this.btPesquisar.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btPesquisar, "Pesquisar Produto");
            this.btPesquisar.UseVisualStyleBackColor = false;
            // 
            // Cardapio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 648);
            this.Controls.Add(this.btPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Cardapio";
            this.Text = "Cardapio";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}