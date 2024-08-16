namespace Estacionamento.DTOs
{
    public class TabelaMovimentacaoDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime HorarioChegada { get; set; }
        public DateTime? HorarioSaida { get; set; }
        public string Duracao { get; set; }
        public string TempoCobrado { get; set; }
        public decimal Preco { get; set; }
    }

}