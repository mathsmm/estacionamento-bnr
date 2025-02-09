using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamento.Models
{
    public class Veiculo
    {
        public Veiculo() {}

        public Veiculo(
            int id,
            string placa
        )
        {
            this.Id = id;
            this.Placa = placa;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(7)")]
        [StringLength(7, ErrorMessage = "A placa deve conter 7 caracteres alfanuméricos")]
        [Required]
        public string Placa { get; set; }

        public IEnumerable<Estadia> Estadias { get; set; }
    }
}