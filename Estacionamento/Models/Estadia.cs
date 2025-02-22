using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamento.Models
{
    public class Estadia
    {
        public Estadia() {}

        public Estadia(
            int veiculoId,
            DateTime dtHrEntrada,
            DateTime dtHrSaida,
            decimal vlrCalculado
        ) 
        {
            this.VeiculoId = veiculoId;
            this.DtHrEntrada = dtHrEntrada;
            this.DtHrSaida = dtHrSaida;
            this.VlrCalculado = vlrCalculado;
        }
        [Key]
        [ForeignKey("Veiculo")]
        public int VeiculoId { get; set; }

        public Veiculo Veiculo { get; set; }

        [Required]
        public DateTime DtHrEntrada { get; set; }

        public DateTime DtHrSaida { get; set; }

        [Column(TypeName = "decimal")]
        public decimal VlrCalculado { get; set; }
    }
}