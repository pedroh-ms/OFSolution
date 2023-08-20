namespace WebApi.Models
{
    /// <summary>
    /// This is the class that maps the material comprado json from the body.
    /// </summary>
    public class MaterialCompradoFromBody
    {
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
