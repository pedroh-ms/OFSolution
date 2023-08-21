namespace WebApi.Models
{
    /// <summary>
    /// This is the <c>servicos</c> table.
    /// </summary>
    public class ServicoModel : BaseModel
    {
        /// <value>
        /// <c>dono_id</c> column.
        /// </value>
        public int? DonoId { get; set; }
        /// <value>
        /// <c>carro_id</c> column.
        /// </value>
        public int? CarroId { get; set; }
        /// <value>
        /// <c>data_entrega</c> column.
        /// </value>
        public DateTime? DataEntrega { get; set; }
        /// <value>
        /// <c>preco</c> column.
        /// </value>
        public decimal? Preco { get; set; }
        /// <value>
        /// <c>observacao</c> column.
        /// </value>
        public string? Observacao { get; set; }
        /// <value>
        /// <c>dono</c> object.
        /// </value>
        public DonoModel? Dono { get; set; }
        /// <value>
        /// <c>carro</c> object.
        /// </value>
        public CarroModel? Carro { get; set; }
    }
}
