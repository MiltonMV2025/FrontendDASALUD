namespace FrontendDASALUD.Models
{
    public class EmpleadoDto
    {
        public int IdEmpleado { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string DUI { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
