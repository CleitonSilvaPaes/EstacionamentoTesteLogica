namespace Estacionamento.Model
{
    public class TabelaPreco
    {
        public int Id { get; set; } // Chave primária
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorHoraInicial { get; set; }
        public decimal ValorHoraAdicional { get; set; }
    }
}
