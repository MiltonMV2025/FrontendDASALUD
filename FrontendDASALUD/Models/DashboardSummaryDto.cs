using System.Collections.Generic;

namespace FrontendDASALUD.Models
{
    public class DashboardSummaryDto
    {
        public int PacientesAtendidos { get; set; }
        public int ConsultasPendientes { get; set; }
        public int TotalConsultas { get; set; }
        public List<DashboardMesItem> ConsultasPorMes { get; set; } = new();
        public List<DashboardEspecialidadItem> ConsultasPorEspecialidad { get; set; } = new();
    }

    public class DashboardMesItem
    {
        public string Mes { get; set; } = string.Empty;
        public int Cantidad { get; set; }
    }

    public class DashboardEspecialidadItem
    {
        public string Especialidad { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public int Cantidad { get; set; }
    }
}
