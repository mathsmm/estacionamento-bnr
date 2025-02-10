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

            builder.Entity<Estadia>()
                .HasData(new List<Estadia>(){
                    new Estadia(1, DateTime.Parse("2015-06-01T13:45:30"), DateTime.Parse("2015-06-01T13:45:45"), (decimal)0.0),
                    new Estadia(2, DateTime.Parse("2015-06-01T13:46:00"), DateTime.Parse("2015-06-01T13:46:15"), (decimal)0.0)
                });

            builder.Entity<ValorReferencia>()
                .HasData(new List<ValorReferencia>(){
                    new ValorReferencia(1, (decimal)3.0, (decimal)5.0, DateTime.Parse("2015-06-01T13:45:30")),
                });
        }
    }
}