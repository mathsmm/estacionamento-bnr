using Estacionamento.Data.Interfaces;
using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data.Services
{
    public class RepositorioVeiculo : IRepositorioVeiculo
    {
        private readonly DataContext _contexto;

        public RepositorioVeiculo(DataContext contexto)
        {
            this._contexto = contexto;
        }

        public async Task<Veiculo[]> ObterTodos()
        {
            IQueryable<Veiculo> consulta = _contexto.Veiculo;

            consulta = consulta.AsNoTracking()
                               .OrderBy(x => x.Id);

            return await consulta.ToArrayAsync();
        }

        public async Task<Veiculo?> ObterPorPlaca(string placa)
        {
            IQueryable<Veiculo> consulta = _contexto.Veiculo;

            consulta = consulta.AsNoTracking()
                               .Where(x => x.Placa == placa);

            return await consulta.FirstOrDefaultAsync();
        }
    }
}