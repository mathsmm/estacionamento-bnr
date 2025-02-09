using Estacionamento.Data.Interfaces;
using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data.Services
{
    public class RepositorioValorReferencia : IRepositorioValorReferencia
    {
        private readonly DataContext _contexto;

        public RepositorioValorReferencia(DataContext contexto)
        {
            this._contexto = contexto;
        }

        public async Task<ValorReferencia[]> ObterTodas()
        {
            // Escalabilidade: implementar paginação
            IQueryable<ValorReferencia> consulta = _contexto.ValorReferencia;

            consulta = consulta.AsNoTracking()
                               .OrderBy(x => x.DtIniVigencia);

            return await consulta.ToArrayAsync();
        }

        public async Task<ValorReferencia> ObterPorData(DateTime data)
        {
            // Consultar valor que esteja entre duas datas
            IQueryable<ValorReferencia> consulta = _contexto.ValorReferencia;

            consulta = consulta.AsNoTracking()
                               .Where(x => x.DtIniVigencia <= data)
                               .OrderBy(x => x.DtIniVigencia);

            return await consulta.FirstAsync();
        }
    }
}