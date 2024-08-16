using Estacionamento.DTOs;
using Estacionamento.Interface;
using Estacionamento.Model;
using Estacionamento.Repositorio;
using Estacionamento.Service;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Estacionamento.View
{
    public partial class TabelaPrecoForm : Form
    {
        private readonly IEstacionamentoContextFactory _ContextFactory;
        private List<TabelaPrecoDTO> tabelaPrecos;
        private EstacionamentoService _Service;

        private decimal valorHoraInicial = 0;
        private decimal valorHoraAdicional = 0;


        public TabelaPrecoForm(IEstacionamentoContextFactory contextFactory,
                               EstacionamentoService service)
        {
            InitializeComponent();
            _Service = service;
            _ContextFactory = contextFactory;
            CarregarTabelaPrecos();
        }

        private void CarregarTabelaPrecos()
        {
            using (var context = _ContextFactory.Create())
            {
                tabelaPrecos = context.TabelasPrecos
                .Select(x => new TabelaPrecoDTO
                {
                    Id = x.Id,
                    DataInicio = x.DataInicio.Date,
                    DataFim = x.DataFim.Date,
                    ValorHoraInicial = x.ValorHoraInicial,
                    ValorHoraAdicional = x.ValorHoraAdicional
                })
                .ToList();
            }
            
            dgvTabelaPrecos.DataSource = tabelaPrecos;

            // Ajustar a largura das colunas
            dgvTabelaPrecos.Columns["Id"].Width = 50;
            dgvTabelaPrecos.Columns["DataInicio"].Width = 100;
            dgvTabelaPrecos.Columns["DataFim"].Width = 100;
            dgvTabelaPrecos.Columns["ValorHoraInicial"].Width = 150;
            dgvTabelaPrecos.Columns["ValorHoraAdicional"].Width = 150;

            // Ajustar os cabeçalhos das colunas
            dgvTabelaPrecos.Columns["Id"].HeaderText = "ID";
            dgvTabelaPrecos.Columns["DataInicio"].HeaderText = "Data Início";
            dgvTabelaPrecos.Columns["DataFim"].HeaderText = "Data Fim";
            dgvTabelaPrecos.Columns["ValorHoraInicial"].HeaderText = "Valor Hora Inicial";
            dgvTabelaPrecos.Columns["ValorHoraAdicional"].HeaderText = "Valor Hora Adicional";
        }

        private bool ValidarCampo(int? id = null)
        {
            txtValorHoraAdicional.Text = txtValorHoraAdicional.Text.Replace(".", ",");
            txtValorHoraInicial.Text = txtValorHoraInicial.Text.Replace(".", ",");

            // Validação de datas
            if (dtpDataInicio.Value.Date > dtpDataFim.Value.Date)
            {
                MessageBox.Show("A data de início não pode ser maior que a data de fim.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ((dtpDataFim.Value.Date - dtpDataInicio.Value.Date).Days > 31)
            {
                MessageBox.Show("A diferença entre as datas não pode ser maior que 31 dias.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validação de sobreposição de datas
            if (ValidarSobreposicaoData(id))
            {
                MessageBox.Show("Já existe uma tabela de preços para o período especificado.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validação de valores
            if (!decimal.TryParse(txtValorHoraInicial.Text, out decimal valorHoraInicial))
            {
                MessageBox.Show("O valor da hora inicial deve ser um número válido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(txtValorHoraAdicional.Text, out decimal valorHoraAdicional))
            {
                MessageBox.Show("O valor da hora adicional deve ser um número válido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (valorHoraInicial <= 0 || valorHoraAdicional <= 0)
            {
                MessageBox.Show("O valor hora adicional ou inicial tem que ser maior que 0.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarSobreposicaoData(int? id = null)
        {
            var dataInicio = dtpDataInicio.Value.Date;
            var dataFim = dtpDataFim.Value.Date;
            return _Service.ValidarSobreposicaoData(dataInicio, dataFim, tabelaPrecos, id);
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (ValidarCampo())
            {
                var tabelaPreco = new TabelaPreco
                {
                    DataInicio = dtpDataInicio.Value.Date,
                    DataFim = dtpDataFim.Value.Date,
                    ValorHoraInicial = decimal.Parse(txtValorHoraInicial.Text),
                    ValorHoraAdicional = decimal.Parse(txtValorHoraAdicional.Text)
                };

                using (var context = _ContextFactory.Create())
                {
                    context.TabelasPrecos.Add(tabelaPreco);
                    context.SaveChanges();
                    tabelaPreco = null;
                }
            }
            CarregarTabelaPrecos();
        }


        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dgvTabelaPrecos.CurrentRow != null)
            {
                using (var context = _ContextFactory.Create())
                {
                    var id = (int)dgvTabelaPrecos.CurrentRow.Cells["Id"].Value;
                    var tabelaPreco = context.TabelasPrecos.Find(id);

                    if (tabelaPreco != null && ValidarCampo(id))
                    {
                        tabelaPreco.DataInicio = dtpDataInicio.Value.Date;
                        tabelaPreco.DataFim = dtpDataFim.Value.Date;
                        tabelaPreco.ValorHoraInicial = decimal.Parse(txtValorHoraInicial.Text);
                        tabelaPreco.ValorHoraAdicional = decimal.Parse(txtValorHoraAdicional.Text);
                        context.SaveChanges();
                        tabelaPreco = null;
                    }
                }
                CarregarTabelaPrecos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvTabelaPrecos.CurrentRow != null)
            {
                using (var context = _ContextFactory.Create())
                {
                    var id = (int)dgvTabelaPrecos.CurrentRow.Cells["Id"].Value;
                    var tabelaPreco = context.TabelasPrecos.Find(id);

                    context.TabelasPrecos.Remove(tabelaPreco);
                    context.SaveChanges();
                }
                CarregarTabelaPrecos();
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, ponto decimal e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Permitir apenas um ponto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
