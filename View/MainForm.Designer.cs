namespace Estacionamento.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            buttonSaida = new Button();
            buttonEntrada = new Button();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            labelDateTime = new Label();
            menuStrip1 = new MenuStrip();
            tabelaDePrecosToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonSaida);
            panel1.Controls.Add(buttonEntrada);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(labelDateTime);
            panel1.Controls.Add(menuStrip1);
            panel1.Controls.Add(flowLayoutPanel1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // buttonSaida
            // 
            resources.ApplyResources(buttonSaida, "buttonSaida");
            buttonSaida.Name = "buttonSaida";
            buttonSaida.UseVisualStyleBackColor = true;
            buttonSaida.Click += buttonSaida_Click;
            // 
            // buttonEntrada
            // 
            resources.ApplyResources(buttonEntrada, "buttonEntrada");
            buttonEntrada.Name = "buttonEntrada";
            buttonEntrada.UseVisualStyleBackColor = true;
            buttonEntrada.Click += buttonEntrada_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            // 
            // labelDateTime
            // 
            resources.ApplyResources(labelDateTime, "labelDateTime");
            labelDateTime.Name = "labelDateTime";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tabelaDePrecosToolStripMenuItem, sairToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // tabelaDePrecosToolStripMenuItem
            // 
            tabelaDePrecosToolStripMenuItem.Name = "tabelaDePrecosToolStripMenuItem";
            resources.ApplyResources(tabelaDePrecosToolStripMenuItem, "tabelaDePrecosToolStripMenuItem");
            tabelaDePrecosToolStripMenuItem.Click += tabelaDePrecosToolStripMenuItem_Click;
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            resources.ApplyResources(sairToolStripMenuItem, "sairToolStripMenuItem");
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tabelaDePrecosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Button buttonEntrada;
        private System.Windows.Forms.Button buttonSaida;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

