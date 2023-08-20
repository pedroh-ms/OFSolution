namespace WebApi.Models
{
    /// <summary>
    /// Base model inherited by all models.
    /// </summary>
    public abstract class BaseModel
    {
        /// <value>
        /// id column.
        /// </value>
        public int? Id { get; set; }
        /// <value>
        /// inserted_at column.
        /// </value>
        public DateTime? InsertedAt { get; set; }
        /// <value>
        /// updated_at column.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
    }
}
