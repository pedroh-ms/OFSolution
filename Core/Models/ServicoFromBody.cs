namespace Core.Models
{
    /// <summary>
    /// This is the class that maps the servico json from the body.
    /// </summary>
    public class ServicoFromBody
    {
        /// <value>
        /// <c>donoId</c> attribute.
        /// </value>
        public int? DonoId { get; set; }
        /// <value>
        /// <c>carroId</c> attribute.
        /// </value>
        public int? CarroId { get; set; }
        /// <value>
        /// <c>dataEntrega</c> attribute.
        /// </value>
        public DateTime? DataEntrega { get; set; }
        /// <value>
        /// <c>preco</c> attribute.
        /// </value>
        public decimal? Preco { get; set; }
        /// <value>
        /// <c>observacao</c> attribute.
        /// </value>
        public string? Observacao { get; set; }
    }
}
