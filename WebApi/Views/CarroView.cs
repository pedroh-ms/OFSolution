namespace WebApi.Views
{
    /// <summary>
    /// This is the view for carro.
    /// </summary>
    public class CarroView
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
        /// <c>nome</c> attribute.
        /// </value>
        public string? Nome { get; set; }
        /// <value>
        /// <c>cor</c> attribute.
        /// </value>
        public string? Cor { get; set; }
    }
}
