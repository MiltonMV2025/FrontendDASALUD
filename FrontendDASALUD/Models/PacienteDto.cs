namespace FrontendDASALUD.Models
{
    public class PacienteDtos
    {
        public int IdPaciente { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string FullName => $"{Nombres} {Apellidos}".Trim();
        public string Dui { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        public string? TipoSangre { get; set; }

        // EN KG, puede venir null
        public decimal? Peso { get; set; }

        // EN METROS, puede venir null (1.75, 1.60, etc.)
        public decimal? Altura { get; set; }
    }
}
