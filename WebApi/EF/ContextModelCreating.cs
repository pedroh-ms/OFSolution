using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace WebApi.EF
{
    public partial class Context : DbContext
    {
        public void DonoModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonoModel>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.Id).HasColumnName("id").HasColumnOrder(1);
                e.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(40)").HasColumnOrder(2).IsRequired();
                e.Property(x => x.NumeroCelular).HasColumnName("numero_celular").HasColumnType("numeric(11,0)").HasColumnOrder(3).IsRequired();
                e.Property(x => x.InsertedAt).HasColumnName("inserted_at").HasColumnType("timestamp").HasColumnOrder(4).IsRequired();
                e.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp").HasColumnOrder(5).IsRequired();
                
                e.ToTable("donos");
            });
        }

        public void CarroModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarroModel>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.Id).HasColumnName("id").HasColumnOrder(1);
                e.Property(x => x.DonoId).HasColumnName("dono_id").HasColumnOrder(2);
                e.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(30)").HasColumnOrder(3).IsRequired();
                e.Property(x => x.Cor).HasColumnName("cor").HasColumnType("varchar(20)").HasColumnOrder(4).IsRequired();
                e.Property(x => x.InsertedAt).HasColumnName("inserted_at").HasColumnType("timestamp").HasColumnOrder(5).IsRequired();
                e.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp").HasColumnOrder(6).IsRequired();
                
                e.HasOne<DonoModel>(x => x.Dono).WithMany(x => x.Carros).HasForeignKey(x => x.DonoId);

                e.ToTable("carros");
            });
        }

        public void ServicoModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicoModel>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.Id).HasColumnName("id").HasColumnOrder(1);
                e.Property(x => x.DonoId).HasColumnName("dono_id").HasColumnOrder(2);
                e.Property(x => x.CarroId).HasColumnName("carro_id").HasColumnOrder(3);
                e.Property(x => x.DataEntrega).HasColumnName("data_entrega").HasColumnType("date").HasColumnOrder(4).IsRequired();
                e.Property(x => x.Preco).HasColumnName("preco").HasColumnType("numeric(6,2)").HasColumnOrder(5).IsRequired();
                e.Property(x => x.Observacao).HasColumnName("observacao").HasColumnType("text").HasColumnOrder(6).IsRequired();
                e.Property(x => x.InsertedAt).HasColumnName("inserted_at").HasColumnType("timestamp").HasColumnOrder(7).IsRequired();
                e.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp").HasColumnOrder(8).IsRequired();
                
                e.HasOne<DonoModel>(x => x.Dono).WithMany(x => x.Servicos).HasForeignKey(x => x.DonoId);
                e.HasOne<CarroModel>(x => x.Carro).WithMany(x => x.Servicos).HasForeignKey(x => x.CarroId);

                e.ToTable("servicos");
            });
        }

        public void MaterialCompradoModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialCompradoModel>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.Id).HasColumnName("id").HasColumnOrder(1);
                e.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(30)").HasColumnOrder(2).IsRequired();
                e.Property(x => x.Dia).HasColumnName("dia").HasColumnType("date").HasColumnOrder(3).IsRequired();
                e.Property(x => x.Preco).HasColumnName("preco").HasColumnType("numeric(6,2)").HasColumnOrder(4).IsRequired();
                e.Property(x => x.InsertedAt).HasColumnName("inserted_at").HasColumnType("timestamp").HasColumnOrder(5).IsRequired();
                e.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp").HasColumnOrder(6).IsRequired();

                e.ToTable("material_comprados");
            });
        }
    }
}
