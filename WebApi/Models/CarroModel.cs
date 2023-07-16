namespace WebApi.Models
{
    public class CarroModel : AbstractModel
    {
        public int? DonoId { get; set; }
        public string? Nome { get; set; }
        public string? Cor { get; set; }
        public DonoModel? Dono { get; set; }
        public ICollection<ServicoModel>? Servicos { get; set; }
    }
}
