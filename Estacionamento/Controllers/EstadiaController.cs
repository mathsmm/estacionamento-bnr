using Estacionamento.Data.Interfaces;
using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadiaController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        private readonly IRepositorioEstadia _repositorioEstadia;

        public EstadiaController(
            IRepositorio repositorio,
            IRepositorioEstadia repositorioEstadia
        )
        {
            this._repositorio = repositorio;
            this._repositorioEstadia = repositorioEstadia;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    await _repositorioEstadia.ObterTodas()
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todas as estadias, ocorreu o erro: {ex.Message}");
            }
        }

        // FORMATO: yyyy-MM-ddTHH:mm:ss
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#the-sortable-s-format-specifier
        [HttpGet("placa={placa}&dataHora={dataHora}")]
        public async Task<IActionResult> GetPorPlacaEDataHora(string placa, string dataHora)
        {
            try
            {
                DateTime dataHoraDT = DateTime.Parse(dataHora);
                return Ok(
                    await _repositorioEstadia.ObterPorPlacaEDataHora(placa, dataHoraDT)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter a última estadia do veículo, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Estadia estadia)
        {
            try
            {
                _repositorio.Adicionar(estadia);
                if (await this._repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(estadia);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar a estadia, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        // FORMATO: yyyy-MM-ddTHH:mm:ss
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#the-sortable-s-format-specifier
        [HttpPut("placa={placa}&dataHora={dataHora}")]
        public async Task<IActionResult> Put(string placa, string dataHora, Estadia estadia)
        {
            try
            {
                DateTime dataHoraDT = DateTime.Parse(dataHora);
                var estadiaCadastrada = await _repositorioEstadia.ObterPorPlacaEDataHora(placa, dataHoraDT);
                if (estadiaCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Atualizar(estadia);
                if (await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(estadia);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao atualizar a estadia, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        // FORMATO: yyyy-MM-ddTHH:mm:ss
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#the-sortable-s-format-specifier
        [HttpDelete("placa={placa}&dataHora={dataHora}")]
        public async Task<IActionResult> Delete(string placa, string dataHora)
        {
            try
            {
                DateTime dataHoraDT = DateTime.Parse(dataHora);
                var estadiaCadastrada = await _repositorioEstadia.ObterPorPlacaEDataHora(placa, dataHoraDT);
                if (estadiaCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Deletar(estadiaCadastrada);
                if (await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(
                        new {
                            message="Removida!"
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao remover a estadia, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }
    }
}