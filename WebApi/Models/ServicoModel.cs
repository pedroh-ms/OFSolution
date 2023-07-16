namespace WebApi.Models
{
    public class ServicoModel : AbstractModel
    {
        public int? DonoId { get; set; }
        public int? CarroId { get; set; }
        public DateTime? DataEntrega { get; set; }
        public decimal? Preco { get; set; }
        public string? Observacao { get; set; }
        public DonoModel? Dono { get; set; }
        public CarroModel? Carro { get; set; }
    }
}
