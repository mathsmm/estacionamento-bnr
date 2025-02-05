using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamento.Models
{
    public class ValorReferencia
    {
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
            this.DtFimVigencia = dtFimVigencia;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public decimal VlrHrInicial { get; set; }
        [Required]
        public decimal VlrHrAdicional { get; set; }
        [Required]
        public DateTime DtIniVigencia { get; set; }
        public DateTime DtFimVigencia { get; set; }


    }
}