using System.ComponentModel.DataAnnotations;

namespace Productos.Entities
{
    public class EProduct
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="La propiedad {0} es requerida")]
        [StringLength(30, MinimumLength =5,ErrorMessage ="La propiedad {0} debe ser de minimo 5 caracteres y maximo 30")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La propiedad {0} es requerida")]
        public string? Peso { get; set; }
        [Required(ErrorMessage = "La propiedad {0} es requerida")]
        [Range(1, int.MaxValue, ErrorMessage ="La {0} debe ser mayor que 0")]
        public int Cantidad { get; set; }
    }
}
