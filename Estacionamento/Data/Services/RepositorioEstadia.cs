using Estacionamento.Data.Interfaces;
using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data.Services
{
    public class RepositorioEstadia : IRepositorioEstadia
    {
        private readonly DataContext _contexto;

        public RepositorioEstadia(DataContext contexto)
        {
            this._contexto = contexto;
        }

        public async Task<Estadia[]> ObterTodas()
        {
            // Escalabilidade: implementar paginação
            IQueryable<Estadia> consulta = _contexto.Estadia;

            consulta = consulta.AsNoTracking()
                               .OrderBy(x => x.DtHrEntrada);

            return await consulta.ToArrayAsync();
        }

        public async Task<Estadia?> ObterPorPlacaEDataHora(string placa, DateTime dataHora)
        {
            IQueryable<Estadia> consulta = _contexto.Estadia;

            consulta = consulta.AsNoTracking()
                               .Include(x => x.Veiculo)
                               .Where(x => x.Veiculo.Placa.ToUpper() == placa.ToUpper()
                                      &&   x.DtHrEntrada <= dataHora)
                               .OrderBy(x => x.DtHrEntrada);

            return await consulta.FirstOrDefaultAsync();
        }
    }
}