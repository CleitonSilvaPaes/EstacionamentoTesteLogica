using Estacionamento.DTOs;
using Estacionamento.Interface;
using Estacionamento.Model;
using Estacionamento.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Estacionamento.Service
{
    public class EstacionamentoService
    {
        private readonly IEstacionamentoContextFactory _ContextFactory;

        public EstacionamentoService(IEstacionamentoContextFactory contextFactory)
        {
            _ContextFactory = contextFactory;
        }

        public bool ExisteMovimentacaoSaida()
        {
            using (var context = _ContextFactory.Create())
            {
                return context.Movimentacoes.Any(m => m.Saida == null);
            }
        }

        public bool ExisteTabelaPrecoValida()
        {
            using (var context = _ContextFactory.Create())
            {
                var dataAtual = DateTime.Now.Date;
                var tabelaPrecoExistente = context.TabelasPrecos
                    .FirstOrDefault(t => t.DataInicio <= dataAtual && t.DataFim >= dataAtual);
                return tabelaPrecoExistente != null;
            }
        }

        public bool ValidarSobreposicaoData(DateTime dataInicio, DateTime dataFim, List<TabelaPrecoDTO> tabelaPrecos, int? id = null)
        {
            var tabelaExistente = tabelaPrecos
                .FirstOrDefault(t => (!id.HasValue || t.Id != id) &&
                                     ((dataInicio >= t.DataInicio && dataInicio <= t.DataFim) ||
                                      (dataFim >= t.DataInicio && dataFim <= t.DataFim) ||
                                      (dataInicio <= t.DataInicio && dataFim >= t.DataFim)));
            return tabelaExistente != null;
        }

        public TabelaPreco GetTabalaPreco()
        {
            using (var context = _ContextFactory.Create())
            {
                var dataAtual = DateTime.Now.Date;
                var tabelaPrecoExistente = context.TabelasPrecos
                    .First(t => t.DataInicio <= dataAtual && t.DataFim >= dataAtual);
                return tabelaPrecoExistente;
            }
        }

        public bool RegistrarEntrada(string placa)
        {
            placa = placa.ToUpper();
            using (var context = _ContextFactory.Create())
            {
                // Verifica se o veículo já está no estacionamento sem saída confirmada
                var movimentacaoExistente = context.Movimentacoes
                    .FirstOrDefault(m => m.Veiculo.Placa.ToUpper() == placa && m.Saida == null);

                if (movimentacaoExistente != null)
                {
                    // Se já existe uma movimentação sem saída confirmada, não permite nova entrada
                    return false;
                }

                // Se não existe movimentação sem saída confirmada, registra a nova entrada
                var veiculo = context.Veiculos.SingleOrDefault(v => v.Placa.ToUpper() == placa);
                if (veiculo == null)
                {
                    veiculo = new Veiculo { Placa = placa };
                    context.Veiculos.Add(veiculo);
                    context.SaveChanges(); // Salva o novo veículo para obter o ID
                }

                TabelaPreco tabelaPreco = GetTabalaPreco();

                var movimentacao = new Movimentacao
                {
                    VeiculoId = veiculo.Id,
                    TabelaPrecoId = tabelaPreco.Id,
                    Entrada = DateTime.Now
                };

                context.Movimentacoes.Add(movimentacao);
                context.SaveChanges();
                return true;
            }
        }

        public bool RegistrarSaida(int movimentacaoId)
        {
            using (var context = _ContextFactory.Create())
            {
                var movimentacao = context.Movimentacoes.FirstOrDefault(m => m.Id == movimentacaoId);
                if (movimentacao != null)
                {
                    movimentacao.Saida = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        internal decimal CalcularValorCobrado(DateTime entrada, DateTime saida, TabelaPreco tabelaPreco)
        {
            var duracao = (saida - entrada).TotalMinutes;
            if (duracao <= 30)
            {
                return tabelaPreco.ValorHoraInicial / 2;
            }
            else if (duracao <= 60)
            {
                return tabelaPreco.ValorHoraInicial;
            }
            else
            {
                // Calcula as horas adicionais com tolerância de 10 minutos
                var horasAdicionais = Math.Floor((duracao - 60) / 60);
                var minutosRestantes = (duracao - 60) % 60;

                // Se os minutos restantes forem menores ou iguais a 10, não cobra adicional
                if (minutosRestantes > 10)
                {
                    horasAdicionais += 1;
                }

                return tabelaPreco.ValorHoraInicial + (decimal)horasAdicionais * tabelaPreco.ValorHoraAdicional;
            }
        }

        internal TimeSpan CalcularTempoCobrado(DateTime entrada, DateTime saida)
        {
            var duracao = (saida - entrada).TotalMinutes;
            if (duracao <= 30)
            {
                return TimeSpan.FromMinutes(30); // Metade do valor da hora inicial
            }
            else if (duracao <= 60)
            {
                return TimeSpan.FromHours(1); // Valor da hora inicial
            }
            else
            {
                // Calcula as horas adicionais com tolerância de 10 minutos
                var horasAdicionais = (duracao - 60) / 60;
                var minutosRestantes = (duracao - 60) % 60;

                // Se os minutos restantes forem menores ou iguais a 10, não cobra adicional
                if (minutosRestantes > 10)
                {
                    horasAdicionais += 1;
                }
                else
                {
                    horasAdicionais = 0;
                }

                return TimeSpan.FromHours(1 + horasAdicionais); // 1 hora inicial + horas adicionais
            }
        }

        internal string CalcularDuracao(DateTime entrada, DateTime saida)
        {
            var duracao = saida - entrada;
            return duracao.ToString(@"hh\:mm\:ss");
        }

    }
}
