using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class DonoContext : DbContext
    {
        public DbSet<DonoModel> Donos { get; set; }

        public DonoContext(DbContextOptions<DonoContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonoModel>()
                .ToTable("donos");

            modelBuilder.Entity<DonoModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<DonoModel>()
                .Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnOrder(1);

            modelBuilder.Entity<DonoModel>()
                .Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(40)")
                .HasColumnOrder(2)
                .IsRequired();

            modelBuilder.Entity<DonoModel>()
                .Property(x => x.NumeroCelular)
                .HasColumnName("numero_celular")
                .HasColumnType("numeric(11,0)")
                .HasColumnOrder(3)
                .IsRequired();

            modelBuilder.Entity<DonoModel>()
                .Property(x => x.InsertedAt)
                .HasColumnName("inserted_at")
                .HasColumnType("datetime")
                .HasColumnOrder(4)
                .IsRequired();

            modelBuilder.Entity<DonoModel>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime")
                .HasColumnOrder(5)
                .IsRequired();
        }
    }
}
