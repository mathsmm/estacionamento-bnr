using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opcoes) : base(opcoes) {}
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Estadia> Estadia { get; set; }
        public DbSet<ValorReferencia> ValorReferencia { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Veiculo>()
                .HasData(new List<Veiculo>(){
                    new Veiculo(1, "QBD9X92"),
                    new Veiculo(2, "LVR3P14")
                });
        }
    }
}