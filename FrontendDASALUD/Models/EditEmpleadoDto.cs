namespace FrontendDASALUD.Models
{
    public class EditEmpleadoDto
    {
        public int IdEmpleado { get; set; }

        public string Usuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;
        public string DUI { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

        public int IdRol { get; set; }
        public int IdEspecialidad { get; set; }

        public bool Activo { get; set; }
    }
}
