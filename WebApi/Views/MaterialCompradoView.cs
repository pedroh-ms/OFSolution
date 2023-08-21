namespace WebApi.Views
{
    /// <summary>
    /// This is the view for material comprado.
    /// </summary>
    public class MaterialCompradoView
    {
        /// <value>
        /// <c>id</c> attribute.
        /// </value>
        public int? Id { get; set; }
        /// <value>
        /// <c>nome</c> attribute.
        /// </value>
        public string? Nome { get; set; }
        /// <value>
        /// <c>dia</c> attribute.
        /// </value>
        public DateTime? Dia { get; set; }
        /// <value>
        /// <c>preco</c> attribute.
        /// </value>
        public decimal? Preco { get; set; }
    }
}
