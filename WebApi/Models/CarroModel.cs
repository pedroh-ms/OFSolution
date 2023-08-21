namespace WebApi.Models
{
    /// <summary>
    /// This is the <c>carros</c> table.
    /// </summary>
    public class CarroModel : BaseModel
    {
        /// <value>
        /// <c>dono_id</c> column.
        /// </value>
        public int? DonoId { get; set; }
        /// <value>
        /// <c>nome</c> column.
        /// </value>
        public string? Nome { get; set; }
        /// <value>
        /// <c>cor</c> column.
        /// </value>
        public string? Cor { get; set; }
        /// <value>
        /// <c>dono</c> object.
        /// </value>
        public DonoModel? Dono { get; set; }
        /// <value>
        /// bag of <c>servicos</c>.
        /// </value>
        public ICollection<ServicoModel>? Servicos { get; set; }
    }
}
