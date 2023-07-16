using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class ServicoContext : DbContext
    {
        public DbSet<ServicoModel> Servicos { get; set; }

        public ServicoContext(DbContextOptions<ServicoContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicoModel>()
                .ToTable("servicos");

            modelBuilder.Entity<ServicoModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ServicoModel>()
                .Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnOrder(1);

            modelBuilder.Entity<ServicoModel>()
                .HasOne<DonoModel>(x => x.Dono)
                .WithMany(x => x.Servicos)
                .HasForeignKey(x => x.DonoId);

            modelBuilder.Entity<ServicoModel>()
                .Property(x => x.DonoId)
                .HasColumnName("dono_id")
                .HasColumnOrder(2);

            modelBuilder.Entity<ServicoModel>()
                .HasOne<CarroModel>(x => x.Carro)
                .WithMany(x => x.Servicos)
                .HasForeignKey(x => x.CarroId);

            modelBuilder.Entity<ServicoModel>()
                .Property(x => x.CarroId)
                .HasColumnName("carro_id")
                .HasColumnOrder(3);

            modelBuilder.Entity<ServicoModel>()
                .Property(x => x.DataEntrega)
                .HasColumnName("data_entrega")
                .HasColumnType("date")
                .HasColumnOrder(4)
                .IsRequired();

            modelBuilder.Entity<ServicoModel>()
                .Property(x => x.Preco)
                .HasColumnName("preco")
                .HasColumnType("numeric(6,2)")
                .HasColumnOrder(5)
                .IsRequired();

            modelBuilder.Entity<ServicoModel>()
                .Property(x => x.Observacao)
                .HasColumnName("observacao")
                .HasColumnType("text")
                .HasColumnOrder(6)
                .IsRequired();

            modelBuilder.Entity<DonoModel>()
                .Property(x => x.InsertedAt)
                .HasColumnName("inserted_at")
                .HasColumnType("datetime")
                .HasColumnOrder(7)
                .IsRequired();

            modelBuilder.Entity<DonoModel>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime")
                .HasColumnOrder(8)
                .IsRequired();
        }
    }
}
