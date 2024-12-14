namespace Core.Models
{
    /// <summary>
    /// This is the <c>material_comprados</c> table.
    /// </summary>
    public class MaterialCompradoModel : BaseModel
    {
        /// <value>
        /// <c>nome</c> column.
        /// </value>
        public string? Nome { get; set; }
        /// <value>
        /// <c>dia</c> column.
        /// </value>
        public DateTime? Dia { get; set; }
        /// <value>
        /// <c>preco</c> column.
        /// </value>
        public decimal? Preco { get; set; }
    }
}
