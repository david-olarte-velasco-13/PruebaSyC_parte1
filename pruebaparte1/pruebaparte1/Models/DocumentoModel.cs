using System.ComponentModel.DataAnnotations;


namespace pruebaparte1.Models
{
    public class DocumentoModel 
    {
        [Required(ErrorMessage = "El campo Documento es obligatorio")]
        public int? Documento { get; set; }

        public int Valor { get; set; }
    }

}