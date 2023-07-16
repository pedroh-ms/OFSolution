namespace WebApi.Models
{
    public class DonoModel : AbstractModel
    {
        public string? Nome { get; set; }
        public long? NumeroCelular { get; set; }
        public ICollection<CarroModel>? Carros { get; set; }
        public ICollection<ServicoModel>? Servicos { get; set; }
    }
}
