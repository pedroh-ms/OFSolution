namespace WebApi.Models
{
    public class ServicoFromBody
    {
        public int? DonoId { get; set; }
        public int? CarroId { get; set; }
        public DateTime? DataEntrega { get; set; }
        public decimal? Preco { get; set; }
        public string? Observacao { get; set; }
    }
}
