using Estacionamento.Service;

namespace Estacionamento.View
{
    public partial class EntradaForm : Form
    {
        private readonly EstacionamentoService _service;

        public EntradaForm(EstacionamentoService service)
        {
            InitializeComponent();
            _service = service;
        }
        private void buttonEntrada_Click(object sender, EventArgs e)
        {
            string placa = maskedTextBoxPlaca.Text.Trim();

            if (string.IsNullOrEmpty(placa) || placa.Length < 8)
            {
                MessageBox.Show("Por favor, insira a placa do veículo corretamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool sucesso = _service.RegistrarEntrada(placa);
            if (sucesso)
            {
                MessageBox.Show("Entrada registrada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
                MessageBox.Show("O veículo já está no estacionamento.\r\n" +
                                   "Primeiro registre a saída do veículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
