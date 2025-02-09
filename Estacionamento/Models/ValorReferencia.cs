using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamento.Models
{
    public class ValorReferencia
    {
        public ValorReferencia() {}

        public ValorReferencia(
            int id,
            decimal vlrHrInicial,
            decimal vlrHrAdicional,
            DateTime dtIniVigencia,
            DateTime dtFimVigencia
        ) 
        {
            this.Id = id;
            this.VlrHrInicial = vlrHrInicial;
            this.VlrHrAdicional = vlrHrAdicional;
            this.DtIniVigencia = dtIniVigencia;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal VlrHrInicial { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal VlrHrAdicional { get; set; }

        [Required]
        public DateTime DtIniVigencia { get; set; }
    }
}