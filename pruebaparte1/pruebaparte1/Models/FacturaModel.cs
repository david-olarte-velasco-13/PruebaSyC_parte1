using System.ComponentModel.DataAnnotations;
namespace pruebaparte1.Models
{
    public class FacturaModel
    {
        public int Idcliente { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set;}

        [Required(ErrorMessage = "El campo Documento es obligatorio")]
        public int? Documento { get; set; }

        [Required(ErrorMessage = "El campo Fecha es obligatorio")]
        public DateTime? Fecha_factura { get; set; }

        [Required(ErrorMessage = "El campo Valor es obligatorio")]
        public int Valor_factura { get; set;}

        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public int? Estado_Factura { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        public string? Descripcion { get; set; }
    }
}
