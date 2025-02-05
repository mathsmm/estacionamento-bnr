using Estacionamento.Data.Interfaces;
using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data.Services
{
    public class RepositorioEstadiaVeiculo : IRepositorioEstadiaVeiculo
    {
        private readonly DataContext _contexto;

        public RepositorioEstadiaVeiculo(DataContext contexto)
        {
            this._contexto = contexto;
        }

        public async Task<EstadiaVeiculo[]> ObterTodas()
        {
            IQueryable<EstadiaVeiculo> consulta = _contexto.EstadiaVeiculo;

            consulta = consulta.AsNoTracking()
                               .OrderBy(x => x.DtHrEntrada);

            return await consulta.ToArrayAsync();
        }

        public async Task<EstadiaVeiculo?> ObterUltimaPorPlaca(string placa)
        {
            IQueryable<EstadiaVeiculo> consulta = _contexto.EstadiaVeiculo;

            consulta = consulta.AsNoTracking()
                               .Where(x => x.Placa.ToUpper() == placa.ToUpper())
                               .OrderBy(x => x.DtHrEntrada);

            return await consulta.FirstOrDefaultAsync();
        }
    }
}