namespace WebApi.Models
{
    public abstract class AbstractModel
    {
        public int? Id { get; set; }
        public DateTime? InsertedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
