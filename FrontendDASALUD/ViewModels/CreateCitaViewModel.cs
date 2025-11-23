using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrontendDASALUD.ViewModels
{
    public class SelectionItem { public int Id { get; set; } public string Text { get; set; } = string.Empty; }

    public class CreateCitaViewModel
    {
        [Required]
        public int IdPaciente { get; set; }
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public decimal Costo { get; set; }
        [Required]
        public DateTime FechaCita { get; set; }

        public List<SelectionItem>? Pacientes { get; set; }
        public List<SelectionItem>? Empleados { get; set; }
    }
}
