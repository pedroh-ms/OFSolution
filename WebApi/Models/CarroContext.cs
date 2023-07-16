using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class CarroContext : DbContext
    {
        public DbSet<CarroModel> Carros { get; set; }
        public DbSet<DonoModel> Donos { get; set; }

        public CarroContext(DbContextOptions<CarroContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarroModel>()
                .ToTable("carros");

            modelBuilder.Entity<CarroModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CarroModel>()
                .Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnOrder(1);

            modelBuilder.Entity<CarroModel>()
                .HasOne<DonoModel>(x => x.Dono)
                .WithMany(x => x.Carros)
                .HasForeignKey(x => x.DonoId);

            modelBuilder.Entity<CarroModel>()
                .Property(x => x.DonoId)
                .HasColumnName("dono_id")
                .HasColumnOrder(2);

            modelBuilder.Entity<CarroModel>()
                .Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(30)")
                .HasColumnOrder(3)
                .IsRequired();

            modelBuilder.Entity<CarroModel>()
                .Property(x => x.Cor)
                .HasColumnName("cor")
                .HasColumnType("varchar(20)")
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
