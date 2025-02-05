using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opcoes) : base(opcoes) {}
        public DbSet<ValorReferencia> ValorReferencia { get; set; }
        public DbSet<EstadiaVeiculo> EstadiaVeiculo { get; set; }
    }
}