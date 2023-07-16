namespace WebApi.Models
{
    public class MaterialCompradoModel : AbstractModel
    {
        public string? Nome { get; set; }
        public DateTime? Dia { get; set; }
        public decimal? Preco { get; set; }
    }
}
