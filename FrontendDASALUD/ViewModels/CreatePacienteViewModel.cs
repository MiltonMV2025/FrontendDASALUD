using System.ComponentModel.DataAnnotations;

namespace FrontendDASALUD.ViewModels
{
    public class CreatePacienteViewModel
    {
        [Required]
        [StringLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string Dui { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [StringLength(10)]
        public string TipoSangre { get; set; } = string.Empty;

        [Range(0, 1000, ErrorMessage = "Peso inválido")]
        public decimal Peso { get; set; }

        // EN METROS, igual que el backend (ej: 1.75)
        [Range(0, 200, ErrorMessage = "Altura inválida")]
        public decimal Altura { get; set; }
    }
}
