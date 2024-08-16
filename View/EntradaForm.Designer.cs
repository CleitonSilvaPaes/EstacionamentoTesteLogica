namespace Estacionamento.View
{
    partial class EntradaForm
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
            this.labelPlaca = new System.Windows.Forms.Label();
            this.maskedTextBoxPlaca = new System.Windows.Forms.MaskedTextBox();
            this.buttonEntrada = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPlaca
            // 
            this.labelPlaca.AutoSize = true;
            this.labelPlaca.Location = new System.Drawing.Point(12, 15);
            this.labelPlaca.Name = "labelPlaca";
            this.labelPlaca.Size = new System.Drawing.Size(34, 13);
            this.labelPlaca.TabIndex = 0;
            this.labelPlaca.Text = "Placa";
            // 
            // maskedTextBoxPlaca
            // 
            this.maskedTextBoxPlaca.Location = new System.Drawing.Point(52, 12);
            this.maskedTextBoxPlaca.Mask = "AAA-0000";
            this.maskedTextBoxPlaca.Name = "maskedTextBoxPlaca";
            this.maskedTextBoxPlaca.Size = new System.Drawing.Size(220, 20);
            this.maskedTextBoxPlaca.TabIndex = 1;
            // 
            // buttonEntrada
            // 
            this.buttonEntrada.Location = new System.Drawing.Point(197, 38);
            this.buttonEntrada.Name = "buttonEntrada";
            this.buttonEntrada.Size = new System.Drawing.Size(75, 23);
            this.buttonEntrada.TabIndex = 2;
            this.buttonEntrada.Text = "Registrar Entrada";
            this.buttonEntrada.UseVisualStyleBackColor = true;
            this.buttonEntrada.Click += new System.EventHandler(this.buttonEntrada_Click);
            // 
            // EntradaSaidaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 71);
            this.Controls.Add(this.buttonEntrada);
            this.Controls.Add(this.maskedTextBoxPlaca);
            this.Controls.Add(this.labelPlaca);
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "EntradaSaidaForm";
            this.Text = "Registrar Entrada";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private System.Windows.Forms.Label labelPlaca;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPlaca;
        private System.Windows.Forms.Button buttonEntrada;
    }
}