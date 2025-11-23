using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FrontendDASALUD.ViewModels
{
    public class EditCitaViewModel
    {
        [JsonPropertyName("idCita")]
        public int IdCita { get; set; }
        
        [Required]
        [JsonPropertyName("idPaciente")]
        public int IdPaciente { get; set; }
        
        [Required]
        [JsonPropertyName("idEmpleado")]
        public int IdEmpleado { get; set; }
        
        [Required]
        [JsonPropertyName("costo")]
        public decimal Costo { get; set; }
        
        [Required]
        [JsonPropertyName("fechaCita")]
        public DateTime FechaCita { get; set; }
        
        [Required]
        [JsonPropertyName("idEstado")]
        public int IdEstado { get; set; }

        [JsonPropertyName("pacientes")]
        public List<SelectionItem>? Pacientes { get; set; }
        
        [JsonPropertyName("empleados")]
        public List<SelectionItem>? Empleados { get; set; }
        
        [JsonPropertyName("estados")]
        public List<SelectionItem>? Estados { get; set; }
    }
}
