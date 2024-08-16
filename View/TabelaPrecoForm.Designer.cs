using System.Runtime.InteropServices;

namespace Estacionamento.View
{
    partial class TabelaPrecoForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtValorHoraInicial = new TextBox();
            txtValorHoraAdicional = new TextBox();
            dtpDataInicio = new DateTimePicker();
            dtpDataFim = new DateTimePicker();
            btnAdicionar = new Button();
            btnAtualizar = new Button();
            btnExcluir = new Button();
            panel1 = new Panel();
            dgvTabelaPrecos = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTabelaPrecos).BeginInit();
            SuspendLayout();
            // 
            // txtValorHoraInicial
            // 
            txtValorHoraInicial.Location = new Point(14, 272);
            txtValorHoraInicial.Margin = new Padding(4, 3, 4, 3);
            txtValorHoraInicial.Name = "txtValorHoraInicial";
            txtValorHoraInicial.PlaceholderText = "Valor Hora Inicial";
            txtValorHoraInicial.Size = new Size(116, 23);
            txtValorHoraInicial.TabIndex = 1;
            txtValorHoraInicial.KeyPress += txtValor_KeyPress;
            // 
            // txtValorHoraAdicional
            // 
            txtValorHoraAdicional.Location = new Point(172, 272);
            txtValorHoraAdicional.Margin = new Padding(4, 3, 4, 3);
            txtValorHoraAdicional.Name = "txtValorHoraAdicional";
            txtValorHoraAdicional.PlaceholderText = "Valor Hora Adicional";
            txtValorHoraAdicional.Size = new Size(116, 23);
            txtValorHoraAdicional.TabIndex = 2;
            txtValorHoraAdicional.KeyPress += txtValor_KeyPress;
            // 
            // dtpDataInicio
            // 
            dtpDataInicio.Format = DateTimePickerFormat.Short;
            dtpDataInicio.Location = new Point(353, 272);
            dtpDataInicio.Margin = new Padding(4, 3, 4, 3);
            dtpDataInicio.Name = "dtpDataInicio";
            dtpDataInicio.Size = new Size(83, 23);
            dtpDataInicio.TabIndex = 3;
            // 
            // dtpDataFim
            // 
            dtpDataFim.Format = DateTimePickerFormat.Short;
            dtpDataFim.Location = new Point(495, 272);
            dtpDataFim.Margin = new Padding(4, 3, 4, 3);
            dtpDataFim.Name = "dtpDataFim";
            dtpDataFim.Size = new Size(81, 23);
            dtpDataFim.TabIndex = 4;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(14, 320);
            btnAdicionar.Margin = new Padding(4, 3, 4, 3);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(88, 27);
            btnAdicionar.TabIndex = 5;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(110, 320);
            btnAtualizar.Margin = new Padding(4, 3, 4, 3);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(88, 27);
            btnAtualizar.TabIndex = 6;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(206, 320);
            btnExcluir.Margin = new Padding(4, 3, 4, 3);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(88, 27);
            btnExcluir.TabIndex = 7;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvTabelaPrecos);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(565, 245);
            panel1.TabIndex = 8;
            // 
            // dgvTabelaPrecos
            // 
            dgvTabelaPrecos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTabelaPrecos.Dock = DockStyle.Fill;
            dgvTabelaPrecos.Location = new Point(0, 0);
            dgvTabelaPrecos.Name = "dgvTabelaPrecos";
            dgvTabelaPrecos.Size = new Size(565, 245);
            dgvTabelaPrecos.ReadOnly = true;
            dgvTabelaPrecos.AllowUserToDeleteRows = false;
            dgvTabelaPrecos.AllowUserToAddRows = false;
            dgvTabelaPrecos.TabIndex = 0;
            // 
            // TabelaPrecoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 359);
            Controls.Add(panel1);
            Controls.Add(btnExcluir);
            Controls.Add(btnAtualizar);
            Controls.Add(btnAdicionar);
            Controls.Add(dtpDataFim);
            Controls.Add(dtpDataInicio);
            Controls.Add(txtValorHoraAdicional);
            Controls.Add(txtValorHoraInicial);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "TabelaPrecoForm";
            Text = "Gerenciamento de Tabela de Preços";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTabelaPrecos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtValorHoraInicial;
        private System.Windows.Forms.TextBox txtValorHoraAdicional;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.DateTimePicker dtpDataFim;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private Panel panel1;
        private DataGridView dgvTabelaPrecos;
    }
}