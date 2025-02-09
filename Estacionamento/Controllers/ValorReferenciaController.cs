using Estacionamento.Data.Interfaces;
using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValorReferenciaController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        private readonly IRepositorioValorReferencia _repositorioValorReferencia;

        public ValorReferenciaController(
            IRepositorio repositorio,
            IRepositorioValorReferencia repositorioValorReferencia
        )
        {
            this._repositorio = repositorio;
            this._repositorioValorReferencia = repositorioValorReferencia;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    await _repositorioValorReferencia.ObterTodas()
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todas as referências de valores, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("data={data}")]
        public async Task<IActionResult> GetPorData(string data)
        {
            try
            {
                DateTime dataDT = DateTime.Parse(data);
                return Ok(
                    await _repositorioValorReferencia.ObterPorData(dataDT)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter a referência de valor, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ValorReferencia valorReferencia)
        {
            try
            {
                _repositorio.Adicionar(valorReferencia);
                if (await this._repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(valorReferencia);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar a referência de valor, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("data={data}")]
        public async Task<IActionResult> Put(string data, ValorReferencia valorReferencia)
        {
            try
            {
                DateTime dataDT = DateTime.Parse(data);
                var valorReferenciaCadastrada = await _repositorioValorReferencia.ObterPorData(dataDT);
                if (valorReferenciaCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Atualizar(valorReferencia);
                if (await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(valorReferencia);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao atualizar a referência de valor, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("data={data}")]
        public async Task<IActionResult> Delete(string data)
        {
            try
            {
                DateTime dataDT = DateTime.Parse(data);
                var valorReferenciaCadastrada = await _repositorioValorReferencia.ObterPorData(dataDT);
                if (valorReferenciaCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Deletar(valorReferenciaCadastrada);
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
                return BadRequest($"Ao remover a referência de valor, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }
    }
}