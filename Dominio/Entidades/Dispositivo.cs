using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Table("Dispositivo")]
    public class Dispositivo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "El {0} debe tener minimo {2} letras y un maximo de {1}")]
        public string Nombre { get; set; }

        [Display(Name = "Tipo de Dispositivo")]

        public TipoDispositivo Tipo { get; set; }

        [ForeignKey("Tipo")]
        [Required]
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 200, MinimumLength = 20, ErrorMessage = "El {0} debe tener minimo {2} letras y un maximo de {1}")]
        public string Detalle { get; set; }

        [Display(Name = "Fecha Alta", Description = "Fecha que se ingreso al sistema")]
        public DateTime FecAlta { get; set; }

        [Display(Name = "Ultima Modificación", Description = "Fecha que se modificó")]
        public DateTime FecModificacion { get; set; }

        public Estacion Estacion { get; set; }

        [ForeignKey("Estacion")]
        [Required]
        public int IdEstacion { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        
        public float Valor { get; set; }
    }
}
