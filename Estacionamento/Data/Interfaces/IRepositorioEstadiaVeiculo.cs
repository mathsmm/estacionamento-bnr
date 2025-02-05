using Estacionamento.Models;

namespace Estacionamento.Data.Interfaces
{
    public interface IRepositorioEstadiaVeiculo
    {
        Task<EstadiaVeiculo[]> ObterTodas();
        Task<EstadiaVeiculo> ObterUltimaPorPlaca(string placa);
    }
}