namespace WebApi.Models
{
    /// <summary>
    /// This is the <c>donos</c> table.
    /// </summary>
    public class DonoModel : BaseModel
    {
        /// <value>
        /// <c>nome</c> column.
        /// </value>
        public string? Nome { get; set; }
        /// <value>
        /// <c>numero_celular</c> column.
        /// </value>
        public long? NumeroCelular { get; set; }
        /// <value>
        /// <c>bag</c> of carros.
        /// </value>
        public ICollection<CarroModel>? Carros { get; set; }
        /// <value>
        /// bag of <c>servicos</c>.</value>
        public ICollection<ServicoModel>? Servicos { get; set; }
    }
}
