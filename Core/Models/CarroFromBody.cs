namespace Core.Models
{
    /// <summary>
    /// This is the class that maps the carro json from the body.
    /// </summary>
    public class CarroFromBody
    {
        /// <value>
        /// <c>donoId</c> attribute.
        /// </value>
        public int? DonoId { get; set; }
        /// <value>
        /// <c>nome</c> attribute.
        /// </value>
        public string? Nome { get; set; }
        /// <value>
        /// <c>cor</c> attribute.
        /// </value>
        public string? Cor { get; set; }
    }
}
