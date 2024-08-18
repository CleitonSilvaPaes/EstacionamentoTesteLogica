using Estacionamento.DTOs;
using Estacionamento.Repositorio;
using Estacionamento.Service;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Estacionamento.View
{
    public partial class SaidaForm : Form
    {
        // Variável de classe para armazenar os dados originais
        private List<TabelaMovimentacaoDTO> dadosOriginais;
        private EstacionamentoService _Serive;

        public SaidaForm(EstacionamentoService service)
        {
            InitializeComponent();
            _Serive = service;
            CarregarTabelaEstacionamento();
        }

        private void CarregarTabelaEstacionamento()
        {
            using (var context = new EstacionamentoContext())
            {
                var movimentacoes = context.Movimentacoes
                    .Include(m => m.Veiculo)
                    .Where(m => m.Saida == null)
                    .ToList();

                dadosOriginais = movimentacoes.Select(m => new TabelaMovimentacaoDTO
                {
                    Id = m.Id,
                    Placa = m.Veiculo.Placa
                }).ToList();

                dataGridViewMovimentacoes.AutoGenerateColumns = false;
                dataGridViewMovimentacoes.DataSource = dadosOriginais;

                dataGridViewMovimentacoes.Columns.Clear();

                dataGridViewMovimentacoes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Id",
                    HeaderText = "ID",
                    Name = "Id"
                });

                dataGridViewMovimentacoes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Placa",
                    HeaderText = "Placa",
                    Name = "Placa"
                });

                dataGridViewMovimentacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewMovimentacoes.Dock = DockStyle.Fill;
            }
        }

        private void maskedTextBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            string pesquisa = maskedTextBoxPesquisa.Text.ToUpper().Replace("-", "").Trim();

            if (string.IsNullOrEmpty(pesquisa))
            {
                dataGridViewMovimentacoes.DataSource = dadosOriginais;
            }
            else
            {
                var data = dadosOriginais
                    .Where(m => m.Placa.ToUpper().Replace("-", "").ToLower().Contains(pesquisa) || m.Id.ToString().Contains(pesquisa))
                    .ToList();
                dataGridViewMovimentacoes.DataSource = data;
            }
        }

        private void buttonConfirmarSaida_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovimentacoes.SelectedRows.Count > 0)
            {
                int movimentacaoId = (int)dataGridViewMovimentacoes.SelectedRows[0].Cells["Id"].Value;
                ConfirmarSaida(movimentacaoId);
            }
            else
            if (dataGridViewMovimentacoes.CurrentCell != null)
            {
                var movimentacaoId = (int)dataGridViewMovimentacoes.CurrentRow.Cells["Id"].Value;
                ConfirmarSaida(movimentacaoId);
            }
            else
            {
                MessageBox.Show("Selecione uma movimentação para confirmar a saída.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfirmarSaida(int movimentacaoId)
        {
            if (_Serive.RegistrarSaida(movimentacaoId))
            {
                CarregarTabelaEstacionamento();
                MessageBox.Show("Saída confirmada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Movimentação não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridViewMovimentacoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obter o valor da célula 2 (placa)
                string placa = dataGridViewMovimentacoes.Rows[e.RowIndex].Cells[1].Value.ToString().ToUpper();
                maskedTextBoxPesquisa.Text = placa;

                // Efetuar a saída
                var data = dadosOriginais
                    .FirstOrDefault(m => m.Placa.Replace("-", "").ToUpper().Contains(placa) || m.Id.ToString().Contains(placa));

                if (data != null)
                {
                    int movimentacaoId = data.Id;
                    ConfirmarSaida(movimentacaoId);
                }

            }
        }
    }
}
