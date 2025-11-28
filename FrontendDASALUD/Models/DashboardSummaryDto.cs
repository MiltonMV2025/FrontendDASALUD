using System.Collections.Generic;

namespace FrontendDASALUD.Models
{
    public class DashboardSummaryDto
    {
        
        public int PacientesAtendidos { get; set; }
        public int ConsultasPendientes { get; set; }
        public int TotalConsultas { get; set; }

        public decimal TotalIngresos { get; set; }
        public List<ConcurrenciaDataDto> DataConcurrencia { get; set; } = new();

        public List<ConsultasPorMesDto> ConsultasPorMes { get; set; } = new();
        public List<ConsultasPorEspecialidadDto> ConsultasPorEspecialidad { get; set; } = new();
    }

    public class ConcurrenciaDataDto
    {
        public string Especialidad { get; set; } = string.Empty;
        public int[] Data { get; set; } = Array.Empty<int>();
        public string Color { get; set; } = string.Empty;
    }

    public class ConsultasPorMesDto
    {
        public string Mes { get; set; } = string.Empty;
        public int Cantidad { get; set; }
    }

    public class ConsultasPorEspecialidadDto
    {
        public string Especialidad { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public int Cantidad { get; set; }
    }
}