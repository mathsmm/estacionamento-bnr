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
        private readonly IRepositorioValorReferencia _repositorioValorReferencia;
        private readonly IRepositorioVeiculo _repositorioVeiculo;

        public EstadiaController(
            IRepositorio repositorio,
            IRepositorioEstadia repositorioEstadia,
            IRepositorioValorReferencia repositorioValorReferencia,
            IRepositorioVeiculo repositorioVeiculo
        )
        {
            this._repositorio = repositorio;
            this._repositorioEstadia = repositorioEstadia;
            this._repositorioValorReferencia = repositorioValorReferencia;
            this._repositorioVeiculo = repositorioVeiculo;
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

        [HttpGet("placa={placa}")]
        public async Task<IActionResult> GetPorPlacaEDataHora(string placa)
        {
            try
            {
                return Ok(
                    await _repositorioEstadia.ObterUltimaPorPlaca(placa)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter a última estadia do veículo, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPost("placa={placa}")]
        public async Task<IActionResult> Post(string placa)
        {
            try
            {
                var estadiaCadastrada = await _repositorioEstadia.ObterUltimaPorPlaca(placa);
                if ((estadiaCadastrada != null) && (estadiaCadastrada.DtHrSaida == default))
                {
                    return BadRequest($"Já existe uma estadia ativa para esse veículo");
                }
                var veiculoCadastrado = await this._repositorioVeiculo.ObterPorPlaca(placa);
                if (veiculoCadastrado == null)
                {
                    veiculoCadastrado = new Veiculo(0, placa);
                }
                Estadia estadia = new Estadia();
                estadia.Veiculo = veiculoCadastrado;
                estadia.DtHrEntrada = DateTime.Now;
                estadia.DtHrSaida = default;
                estadia.VlrCalculado = default;
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

        [HttpPut("placa={placa}")]
        public async Task<IActionResult> Put(string placa)
        {
            try
            {
                var estadiaCadastrada = await _repositorioEstadia.ObterUltimaPorPlaca(placa);
                if (estadiaCadastrada == null)
                {
                    return NotFound();
                }
                DateTime dtAtual = DateTime.Now;
                estadiaCadastrada.DtHrSaida = dtAtual;

                // Calcula valor final
                var vlrReferencia = await this._repositorioValorReferencia.ObterPorData(dtAtual);
                if (vlrReferencia == null)
                {
                    return BadRequest("Não há valor de referência cadastrado");
                }
                TimeSpan difTempo = estadiaCadastrada.DtHrSaida - estadiaCadastrada.DtHrEntrada;
                if (difTempo.TotalMinutes <= 30.0)
                {
                    estadiaCadastrada.VlrCalculado = vlrReferencia.VlrHrInicial / 2;
                }
                else
                if (difTempo.TotalMinutes > 30.0)
                {
                    double minutosSobrando = difTempo.TotalMinutes - 70.0;
                    if (minutosSobrando <= 0.0)
                    {
                        estadiaCadastrada.VlrCalculado = vlrReferencia.VlrHrInicial;
                    }
                    else
                    {
                        estadiaCadastrada.VlrCalculado = 
                            vlrReferencia.VlrHrInicial + 
                            vlrReferencia.VlrHrAdicional *
                            (((int)minutosSobrando + 60) / 60);
                    }
                }

                _repositorio.Atualizar(estadiaCadastrada);
                if (await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(estadiaCadastrada);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Ao atualizar a estadia, ocorreu o erro: " + ex.Message);
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