namespace Estacionamento.Model
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public decimal ValorCobrado { get; set; }
        public int TabelaPrecoId { get; set; }
        public TabelaPreco TabelaPreco { get; set; }
    }
}
