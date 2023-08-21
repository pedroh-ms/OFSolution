namespace WebApi.Views
{
    /// <summary>
    /// This is the view for servico.
    /// </summary>
    public class ServicoView
    {
        /// <value>
        /// <c>id</c> attribute.
        /// </value>
        public int? Id { get; set; }
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
