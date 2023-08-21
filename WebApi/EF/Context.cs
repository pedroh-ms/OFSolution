using Microsoft.EntityFrameworkCore;

namespace WebApi.EF
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
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
