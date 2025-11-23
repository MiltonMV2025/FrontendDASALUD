using System;

namespace FrontendDASALUD.Models
{
    public class CitaDto
    {
        public int Id { get; set; }
        public string IdConsulta { get; set; } = string.Empty;
        public string AtendidoPor { get; set; } = string.Empty;
        public string Paciente { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public decimal Costo { get; set; }
        public string Estado { get; set; } = "Pendiente";
    }

    public class PacienteDto
    {
        public int IdPaciente { get; set; }
        public string FullName { get; set; } = string.Empty;
    }

    public class DoctorDto
    {
        public int IdEmpleado { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
    }

    public class EstadoDto
    {
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
    }

    public class EditCitaDto
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public string PacienteNombre { get; set; } = string.Empty;
        public int IdEmpleado { get; set; }
        public string EmpleadoNombre { get; set; } = string.Empty;
        public DateTime FechaCita { get; set; }
        public decimal Costo { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
