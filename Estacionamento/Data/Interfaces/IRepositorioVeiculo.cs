using Estacionamento.Models;

namespace Estacionamento.Data.Interfaces
{
    public interface IRepositorioVeiculo
    {
        Task<Veiculo[]> ObterTodos();
        Task<Veiculo?> ObterPorPlaca(string placa);
    }
}