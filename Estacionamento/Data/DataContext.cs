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
    }
}