using Estacionamento.DTOs;
using Estacionamento.Interface;
using Estacionamento.Repositorio;
using Estacionamento.Service;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Estacionamento.View
{
    public partial class MainForm : Form
    {
        private readonly EstacionamentoService _Service;
        private readonly EstacionamentoContext _Context;

        public MainForm()
        {
            InitializeComponent();
            _Context = new EstacionamentoContext();
            _Service = new EstacionamentoService(_Context);
            CarregarTabelaEstacionamento();
        }

        public void CarregarTabelaEstacionamento()
        {
            using (var context = _Context.Create())
            {
                var movimentacoes = context.Movimentacoes
                    .Include(m => m.Veiculo)
                    .Include(m => m.TabelaPreco)
                    .OrderByDescending(m => m.Saida)
                    .ToList();

                var data = movimentacoes.Select(m => new TabelaMovimentacaoDTO
                {
                    Id = m.Id,
                    Placa = m.Veiculo.Placa,
                    HorarioChegada = m.Entrada,
                    HorarioSaida = m.Saida,
                    Duracao = m.Saida.HasValue ? _Service.CalcularDuracao(m.Entrada, m.Saida.Value) : "00:00",
                    TempoCobrado = m.Saida.HasValue ? _Service.CalcularTempoCobrado(m.Entrada, m.Saida.Value).ToString(@"hh\:mm") : "00:00",
                    Preco = m.Saida.HasValue ? _Service.CalcularValorCobrado(m.Entrada, m.Saida.Value, m.TabelaPreco) : 0
                }).ToList();

                dataGridView1.DataSource = data;

                // Ajusta os nomes das colunas
                dataGridView1.Columns["Id"].HeaderText = "ID";
                dataGridView1.Columns["Placa"].HeaderText = "Placa";
                dataGridView1.Columns["HorarioChegada"].HeaderText = "Horário Chegada";
                dataGridView1.Columns["HorarioSaida"].HeaderText = "Horário Saída";
                dataGridView1.Columns["Duracao"].HeaderText = "Duração (Horas)";
                dataGridView1.Columns["TempoCobrado"].HeaderText = "Tempo Cobrado (Horas)";
                dataGridView1.Columns["Preco"].HeaderText = "Preço (R$)";

                // Ajusta o modo de redimensionamento automático das colunas
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Certifique-se de que o DataGridView preenche o contêiner pai
                dataGridView1.Dock = DockStyle.Fill;
            }
        }


        private void tabelaDePrecosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabelaPrecoForm tabelaPrecoForm = new TabelaPrecoForm(_Context, _Service);
            tabelaPrecoForm.ShowDialog();
        }

        private void buttonEntrada_Click(object sender, EventArgs e)
        {
            // Verifica se existe uma tabela de preços válida para o período atual
            bool exiteTabela = _Service.ExisteTabelaPrecoValida();

            if (!exiteTabela)
            {
                // Se não existe uma tabela de preços válida, exibe uma mensagem de erro
                MessageBox.Show("Não existe uma tabela de preços válida para o período atual. Por favor, cadastre uma nova tabela de preços.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Se existe uma tabela de preços válida, abre o formulário de entrada e saída
            EntradaForm entradaSaindaForm = new EntradaForm(_Service);
            entradaSaindaForm.ShowDialog();
            CarregarTabelaEstacionamento();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSaida_Click(object sender, EventArgs e)
        {
            bool existeMovimentacao = _Service.ExisteMovimentacaoSaida();

            if (!existeMovimentacao)
            {
                MessageBox.Show("Não existe veiculos no estacionamento pendente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaidaForm saidaForm = new SaidaForm(_Service);
            saidaForm.ShowDialog();
            CarregarTabelaEstacionamento();
        }
    }
}
