using Estacionamento.Models;

namespace Estacionamento.Data.Interfaces
{
    public interface IRepositorioEstadia
    {
        Task<Estadia[]> ObterTodas();
        Task<Estadia?> ObterPorPlacaEDataHora(string placa, DateTime dataHora);
    }
}