using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage = "La {0} debe tener minimo {2} letras y un maximo de {1}")]
        [Display(Name = "Nombre de Usuario")]
        public string NomUsuario { get; set; }

        [Required(ErrorMessage = "La {0} es obligatoria")]
        [StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage = "La {0} debe tener minimo {2} letras y un maximo de {1}")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [EmailAddress(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage = "El {0} debe tener minimo {2} letras y un maximo de {1}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "El {0} debe tener minimo {2} letras y un maximo de {1}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "El {0} debe tener minimo {2} letras y un maximo de {1}")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 15, MinimumLength = 5, ErrorMessage = "El {0} debe tener minimo {2} letras y un maximo de {1}")]
        public string Rol { get; set; }
    }
}
