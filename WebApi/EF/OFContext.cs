using Microsoft.EntityFrameworkCore;

namespace WebApi.EF
{
    public partial class OFContext : DbContext
    {
        public OFContext(DbContextOptions<OFContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DonoModelCreating(modelBuilder);
            CarroModelCreating(modelBuilder);
            ServicoModelCreating(modelBuilder);
            MaterialCompradoModelCreating(modelBuilder);
        }
    }
}
