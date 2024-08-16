namespace Estacionamento.View
{
    partial class SaidaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPesquisa;
        private System.Windows.Forms.Button buttonConfirmarSaida;
        private System.Windows.Forms.DataGridView dataGridViewMovimentacoes;

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
            maskedTextBoxPesquisa = new MaskedTextBox();
            buttonConfirmarSaida = new Button();
            dataGridViewMovimentacoes = new DataGridView();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimentacoes).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // maskedTextBoxPesquisa
            // 
            maskedTextBoxPesquisa.Location = new Point(14, 14);
            maskedTextBoxPesquisa.Margin = new Padding(4, 3, 4, 3);
            maskedTextBoxPesquisa.Mask = "AAA-0000";
            maskedTextBoxPesquisa.Name = "maskedTextBoxPesquisa";
            maskedTextBoxPesquisa.Size = new Size(233, 23);
            maskedTextBoxPesquisa.TabIndex = 0;
            maskedTextBoxPesquisa.TextChanged += maskedTextBoxPesquisa_TextChanged;
            // 
            // buttonConfirmarSaida
            // 
            buttonConfirmarSaida.Location = new Point(254, 12);
            buttonConfirmarSaida.Margin = new Padding(4, 3, 4, 3);
            buttonConfirmarSaida.Name = "buttonConfirmarSaida";
            buttonConfirmarSaida.Size = new Size(117, 27);
            buttonConfirmarSaida.TabIndex = 1;
            buttonConfirmarSaida.Text = "Confirmar Saída";
            buttonConfirmarSaida.UseVisualStyleBackColor = true;
            buttonConfirmarSaida.Click += buttonConfirmarSaida_Click;
            // 
            // dataGridViewMovimentacoes
            // 
            dataGridViewMovimentacoes.AllowUserToAddRows = false;
            dataGridViewMovimentacoes.AllowUserToDeleteRows = false;
            dataGridViewMovimentacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMovimentacoes.Dock = DockStyle.Fill;
            dataGridViewMovimentacoes.Location = new Point(0, 0);
            dataGridViewMovimentacoes.Margin = new Padding(4, 3, 4, 3);
            dataGridViewMovimentacoes.Name = "dataGridViewMovimentacoes";
            dataGridViewMovimentacoes.ReadOnly = true;
            dataGridViewMovimentacoes.Size = new Size(351, 90);
            dataGridViewMovimentacoes.TabIndex = 2;
            dataGridViewMovimentacoes.CellDoubleClick += dataGridViewMovimentacoes_CellDoubleClick;

            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridViewMovimentacoes);
            panel1.Location = new Point(14, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(351, 90);
            panel1.TabIndex = 3;
            // 
            // SaidaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 135);
            Controls.Add(panel1);
            Controls.Add(buttonConfirmarSaida);
            Controls.Add(maskedTextBoxPesquisa);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SaidaForm";
            Text = "Saída de Veículos";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimentacoes).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
    }
}