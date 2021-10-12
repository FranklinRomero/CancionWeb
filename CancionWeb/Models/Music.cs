using System.ComponentModel.DataAnnotations;

namespace CancionWeb.Models
{
    public class Music
    {
        [Key]
        public string Cancion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese un autor!")]
        [StringLength(60,MinimumLength = 2, ErrorMessage = "Mínimo 2 caracteres!")]
        [Display(Name = "Nombre completo del autor")]
        public string Autor { get; set; }
        [Display(Name = "Letra de la canción")]
        public string Letra { get; set; }
        [Url]
        [Required]
        [Display(Name = "URL de la canción")]
        public string Enlace { get; set; }

    }
}
