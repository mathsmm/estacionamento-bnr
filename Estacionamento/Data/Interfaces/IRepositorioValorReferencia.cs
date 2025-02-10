using Estacionamento.Models;

namespace Estacionamento.Data.Interfaces
{
    public interface IRepositorioValorReferencia
    {
        Task<ValorReferencia[]> ObterTodas();
        Task<ValorReferencia?> ObterPorData(DateTime data);
    }
}