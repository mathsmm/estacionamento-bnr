using Estacionamento.Data.Interfaces;
using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        private readonly IRepositorioVeiculo _repositorioVeiculo;

        public VeiculoController(
            IRepositorio repositorio,
            IRepositorioVeiculo repositorioVeiculo
        )
        {
            this._repositorio = repositorio;
            this._repositorioVeiculo = repositorioVeiculo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    await _repositorioVeiculo.ObterTodos()
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os veículos, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("placa={placa}")]
        public async Task<IActionResult> GetPorPlaca(string placa)
        {
            try
            {
                return Ok(
                    await _repositorioVeiculo.ObterPorPlaca(placa)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os veículos, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Veiculo veiculo)
        {
            try
            {
                _repositorio.Adicionar(veiculo);
                if (await this._repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(veiculo);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar o veículo, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("placa={placa}")]
        public async Task<IActionResult> Put(string placa, Veiculo veiculo)
        {
            try
            {
                var veiculoCadastrado = await _repositorioVeiculo.ObterPorPlaca(placa);
                if (veiculoCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Atualizar(veiculo);
                if (await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(veiculo);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao atualizar o veículo, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("placa={placa}")]
        public async Task<IActionResult> Delete(string placa)
        {
            try
            {
                var veiculoCadastrado = await _repositorioVeiculo.ObterPorPlaca(placa);
                if (veiculoCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Deletar(veiculoCadastrado);
                if (await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(
                        new {
                            message="Removido!"
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao remover o veículo, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

    }
}