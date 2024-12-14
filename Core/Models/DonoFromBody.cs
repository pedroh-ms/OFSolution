namespace Core.Models
{
    /// <summary>
    /// This is the class that maps the dono json from the body.
    /// </summary>
    public class DonoFromBody
    {
        /// <value>
        /// <c>nome</c> attribute.
        /// </value>
        public string? Nome { get; set; }
        /// <value>
        /// <c>numeroCelular</c> attribure.
        /// </value>
        public long? NumeroCelular { get; set; }
    }
}
