using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamento.Models
{
    public class EstadiaVeiculo
    {
        public EstadiaVeiculo(
            string placa,
            DateTime dtHrEntrada,
            DateTime dtHrSaida
        ) 
        {
            this.Placa = placa;
            this.DtHrEntrada = dtHrEntrada;
            this.DtHrSaida = dtHrSaida;
        }
        [Key]
        [Column(TypeName = "Varchar(7)")]
        [StringLength(7, ErrorMessage = "A placa deve conter 7 caracteres alfanuméricos")]
        public string Placa { get; set; }
        [Required]
        public DateTime DtHrEntrada { get; set; }
        public DateTime DtHrSaida { get; set; }
    }
}