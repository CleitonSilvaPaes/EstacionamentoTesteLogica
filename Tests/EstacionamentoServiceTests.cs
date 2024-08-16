using Estacionamento.DTOs;
using Estacionamento.Interface;
using Estacionamento.Model;
using Estacionamento.Repositorio;
using Estacionamento.Service;
using Estacionamento.Tests.Extensions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Numerics;
using Xunit;

namespace Estacionamento.Tests
{
    public class EstacionamentoServiceTests
    {
        private readonly Mock<IEstacionamentoContextFactory> _mockContextFactory;
        private readonly Mock<EstacionamentoContext> _mockContext;
        private readonly EstacionamentoService _service;

        public EstacionamentoServiceTests()
        {
            _mockContextFactory = new Mock<IEstacionamentoContextFactory>();
            _mockContext = new Mock<EstacionamentoContext>();
            _mockContextFactory.Setup(f => f.Create()).Returns(_mockContext.Object);
            _service = new EstacionamentoService(_mockContextFactory.Object);
        }

        [Fact]
        public void TesteExisteMovimentacaoSaida()
        {
            // Arrange
            var mockMovimentacoes = new List<Movimentacao>
            {
                new Movimentacao { Saida = null }
            }.AsQueryable();

            var mockDbSet = mockMovimentacoes.CreateMockDbSet();

            _mockContext.Setup(c => c.Movimentacoes).Returns(mockDbSet.Object);

            // Act
            var result = _service.ExisteMovimentacaoSaida();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TesteExisteTabelaPrecoValida()
        {
            // Arrange
            var dataAtual = DateTime.Now.Date;
            var mockTabelasPrecos = new List<TabelaPreco>
            {
                new TabelaPreco { DataInicio = dataAtual.AddDays(-1), DataFim = dataAtual.AddDays(1) }
            };

            var mockDbSet = mockTabelasPrecos.CreateMockDbSet();
            _mockContext.Setup(c => c.TabelasPrecos).Returns(mockDbSet.Object);

            // Act
            var result = _service.ExisteTabelaPrecoValida();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidarSobreposicaoData_PositiveTest()
        {
            // Arrange
            var dataInicio = new DateTime(2024, 8, 1);
            var dataFim = new DateTime(2024, 8, 10);
            var tabelaPrecos = new List<TabelaPrecoDTO>
            {
                new TabelaPrecoDTO { Id = 1, DataInicio = new DateTime(2024, 8, 5), DataFim = new DateTime(2024, 8, 15) }
            };

            // Act
            var result = _service.ValidarSobreposicaoData(dataInicio, dataFim, tabelaPrecos);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidarSobreposicaoData_NegativeTest()
        {
            // Arrange
            var dataInicio = new DateTime(2024, 8, 1);
            var dataFim = new DateTime(2024, 8, 10);
            var tabelaPrecos = new List<TabelaPrecoDTO>
            {
                new TabelaPrecoDTO { Id = 1, DataInicio = new DateTime(2024, 8, 11), DataFim = new DateTime(2024, 8, 20) }
            };

            // Act
            var result = _service.ValidarSobreposicaoData(dataInicio, dataFim, tabelaPrecos);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidarSobreposicaoData_PositiveTest_WithId()
        {
            // Arrange
            var dataInicio = new DateTime(2024, 8, 1);
            var dataFim = new DateTime(2024, 8, 10);
            var tabelaPrecos = new List<TabelaPrecoDTO>
            {
                new TabelaPrecoDTO { Id = 1, DataInicio = new DateTime(2024, 8, 5), DataFim = new DateTime(2024, 8, 15) }
            };

            // Act
            var result = _service.ValidarSobreposicaoData(dataInicio, dataFim, tabelaPrecos, 2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidarSobreposicaoData_NegativeTest_WithId()
        {
            // Arrange
            var dataInicio = new DateTime(2024, 8, 1);
            var dataFim = new DateTime(2024, 8, 10);
            var tabelaPrecos = new List<TabelaPrecoDTO>
            {
                new TabelaPrecoDTO { Id = 1, DataInicio = new DateTime(2024, 8, 11), DataFim = new DateTime(2024, 8, 20) }
            };

            // Act
            var result = _service.ValidarSobreposicaoData(dataInicio, dataFim, tabelaPrecos, 1);

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void RegistrarEntrada_PositiveTest()
        {
            // Arrange
            var placa = "ABC1234";
            var mockMovimentacoes = new List<Movimentacao>().AsQueryable();
            var mockVeiculos = new List<Veiculo>
            {
                new Veiculo { Id = 1, Placa = placa }
            }.AsQueryable();
            var mockTabelasPrecos = new List<TabelaPreco>
            {
                new TabelaPreco { Id = 1, DataInicio = DateTime.Now.AddDays(-1), DataFim = DateTime.Now.AddDays(1) }
            }.AsQueryable();

            var mockMovimentacoesDbSet = mockMovimentacoes.CreateMockDbSet();
            var mockVeiculosDbSet = mockVeiculos.CreateMockDbSet();
            var mockTabelasPrecosDbSet = mockTabelasPrecos.CreateMockDbSet();

            _mockContext.Setup(c => c.Movimentacoes).Returns(mockMovimentacoesDbSet.Object);
            _mockContext.Setup(c => c.Veiculos).Returns(mockVeiculosDbSet.Object);
            _mockContext.Setup(c => c.TabelasPrecos).Returns(mockTabelasPrecosDbSet.Object);

            // Act
            var result = _service.RegistrarEntrada(placa);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RegistrarEntrada_NegativeTest()
        {
            // Arrange
            var placa = "ABC1234";
            var mockMovimentacoes = new List<Movimentacao>
            {
                new Movimentacao { Veiculo = new Veiculo { Placa = placa }, Saida = null }
            }.AsQueryable();
            var mockVeiculos = new List<Veiculo>
            {
                new Veiculo { Id = 1, Placa = placa }
            }.AsQueryable();
            var mockTabelasPrecos = new List<TabelaPreco>
            {
                new TabelaPreco { Id = 1, DataInicio = DateTime.Now.AddDays(-1), DataFim = DateTime.Now.AddDays(1) }
            }.AsQueryable();

            var mockMovimentacoesDbSet = mockMovimentacoes.CreateMockDbSet();
            var mockVeiculosDbSet = mockVeiculos.CreateMockDbSet();
            var mockTabelasPrecosDbSet = mockTabelasPrecos.CreateMockDbSet();

            _mockContext.Setup(c => c.Movimentacoes).Returns(mockMovimentacoesDbSet.Object);
            _mockContext.Setup(c => c.Veiculos).Returns(mockVeiculosDbSet.Object);
            _mockContext.Setup(c => c.TabelasPrecos).Returns(mockTabelasPrecosDbSet.Object);

            // Act
            var result = _service.RegistrarEntrada(placa);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RegistrarSaida_PositiveTest()
        {
            // Arrange
            var movimentacaoId = 1;
            var placa = "ABC1234";
            var mockMovimentacoes = new List<Movimentacao>
            {
                new Movimentacao { 
                    Id = movimentacaoId, 
                    Entrada = DateTime.Now.AddHours(-2),
                    Veiculo = new Veiculo{ Id = 1, Placa = placa},
                }
            }.AsQueryable();

            var mockMovimentacoesDbSet = mockMovimentacoes.CreateMockDbSet();

            _mockContext.Setup(c => c.Movimentacoes).Returns(mockMovimentacoesDbSet.Object);

            // Act
            var result = _service.RegistrarSaida(movimentacaoId);

            // Assert
            Assert.True(result);
            Assert.NotNull(mockMovimentacoes.First().Saida);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void RegistrarSaida_NegativeTest()
        {
            // Arrange
            var movimentacaoId = 1;
            var mockMovimentacoes = new List<Movimentacao>
            {
                new Movimentacao { Id = 2, Entrada = DateTime.Now.AddHours(-2) }
            }.AsQueryable();

            var mockMovimentacoesDbSet = mockMovimentacoes.CreateMockDbSet();

            _mockContext.Setup(c => c.Movimentacoes).Returns(mockMovimentacoesDbSet.Object);

            // Act
            var result = _service.RegistrarSaida(movimentacaoId);

            // Assert
            Assert.False(result);
            _mockContext.Verify(c => c.SaveChanges(), Times.Never);
        }

        [Fact]
        public void CalcularTempoCobrado_Exatamente30Minutos()
        {
            // Arrange
            var horaAtual = DateTime.Now;
            var entrada = horaAtual.AddMinutes(-30);
            var saida = horaAtual;
            var expected = TimeSpan.FromMinutes(30);
            

            // Act
            var result = _service.CalcularTempoCobrado(entrada, saida);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalcularTempoCobrado_Exatamente60Minutos()
        {
            // Arrange
            var dataAtual = DateTime.Now;
            var entrada = dataAtual.AddHours(-1);
            var saida = dataAtual;
            var expected = TimeSpan.FromHours(1);
            

            // Act
            var result = _service.CalcularTempoCobrado(entrada, saida);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalcularTempoCobrado_MaisDe60MinutosComTolerancia()
        {
            // Arrange
            var horaAtual = DateTime.Now;
            var entrada = horaAtual.AddHours(-1).AddMinutes(-10); // 70 minutos
            var saida = horaAtual;
            var expected = TimeSpan.FromHours(1); // Tolerância de 10 minutos
            

            // Act
            var result = _service.CalcularTempoCobrado(entrada, saida);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalcularTempoCobrado_MaisDe60MinutosSemTolerancia()
        {
            // Arrange
            var horaAtual = DateTime.Now;
            var entrada = horaAtual.AddHours(-1).AddMinutes(-20); // 80 minutos
            var saida = horaAtual;
            var expected = TimeSpan.FromMinutes(140); // Sem tolerância

            // Act
            var result = _service.CalcularTempoCobrado(entrada, saida);

            // Assert
            Assert.Equal(expected, TimeSpan.FromMinutes(Math.Round(result.TotalMinutes)));
        }

        [Fact]
        public void CalcularValorCobrado_Ate30Minutos()
        {
            // Arrange
            var dataAtual = DateTime.Now;
            var entrada = dataAtual.AddMinutes(-20);
            var saida = dataAtual;
            var tabelaPreco = new TabelaPreco { ValorHoraInicial = 10m, ValorHoraAdicional = 5m };
            var expected = tabelaPreco.ValorHoraInicial / 2;

            // Act
            var result = _service.CalcularValorCobrado(entrada, saida, tabelaPreco);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalcularValorCobrado_Ate60Minutos()
        {
            // Arrange
            var dataAtual = DateTime.Now;
            var entrada = dataAtual.AddMinutes(-60);
            var saida = dataAtual;
            var tabelaPreco = new TabelaPreco { ValorHoraInicial = 10m, ValorHoraAdicional = 5m };
            var expected = tabelaPreco.ValorHoraInicial;

            // Act
            var result = _service.CalcularValorCobrado(entrada, saida, tabelaPreco);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalcularValorCobrado_MaisDe60MinutosComTolerancia()
        {
            // Arrange
            var dataAtual = DateTime.Now;
            var entrada = dataAtual.AddMinutes(-70); // 1 hora e 10 minutos
            var saida = dataAtual;
            var tabelaPreco = new TabelaPreco { ValorHoraInicial = 10m, ValorHoraAdicional = 5m };
            var expected = tabelaPreco.ValorHoraInicial; // Tolerância de 10 minutos

            // Act
            var result = _service.CalcularValorCobrado(entrada, saida, tabelaPreco);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalcularValorCobrado_MaisDe60MinutosSemTolerancia()
        {
            // Arrange
            var dataAtual = DateTime.Now;
            var entrada = dataAtual.AddMinutes(-80); // 1 hora e 20 minutos
            var saida = dataAtual;
            var tabelaPreco = new TabelaPreco { ValorHoraInicial = 10m, ValorHoraAdicional = 5m };
            var expected = tabelaPreco.ValorHoraInicial + tabelaPreco.ValorHoraAdicional; // 1 hora inicial + 1 hora adicional

            // Act
            var result = _service.CalcularValorCobrado(entrada, saida, tabelaPreco);

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void CalcularValorCobrado_VariasHorasAdicionais()
        {
            // Arrange
            var dataAtual = DateTime.Now;
            var entrada = dataAtual.AddHours(-3); // 3 horas
            var saida = dataAtual;
            var tabelaPreco = new TabelaPreco { ValorHoraInicial = 10m, ValorHoraAdicional = 5m };
            var expected = tabelaPreco.ValorHoraInicial + 2 * tabelaPreco.ValorHoraAdicional; // 1 hora inicial + 2 horas adicionais

            // Act
            var result = _service.CalcularValorCobrado(entrada, saida, tabelaPreco);

            // Assert
            Assert.Equal(expected, result);
        }

    }
}
