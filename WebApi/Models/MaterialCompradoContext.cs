using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class MaterialCompradoContext : DbContext
    {
        public DbSet<MaterialCompradoModel> MaterialComprados { get; set; }

        public MaterialCompradoContext(DbContextOptions<MaterialCompradoContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialCompradoModel>()
                .ToTable("material_comprados");

            modelBuilder.Entity<MaterialCompradoModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<MaterialCompradoModel>()
                .Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnOrder(1);

            modelBuilder.Entity<MaterialCompradoModel>()
                .Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(30)")
                .HasColumnOrder(2)
                .IsRequired();

            modelBuilder.Entity<MaterialCompradoModel>()
                .Property(x => x.Dia)
                .HasColumnName("dia")
                .HasColumnType("date")
                .HasColumnOrder(3)
                .IsRequired();

            modelBuilder.Entity<MaterialCompradoModel>()
                .Property(x => x.Preco)
                .HasColumnName("preco")
                .HasColumnType("numeric(6,2)")
                .HasColumnOrder(4)
                .IsRequired();

            modelBuilder.Entity<DonoModel>()
                .Property(x => x.InsertedAt)
                .HasColumnName("inserted_at")
                .HasColumnType("datetime")
                .HasColumnOrder(5)
                .IsRequired();

            modelBuilder.Entity<DonoModel>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime")
                .HasColumnOrder(6)
                .IsRequired();
        }
    }
}
