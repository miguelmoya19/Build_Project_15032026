using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Software.Application.Dtos
{
    public class AllTasksViewDto
    {
        
        public int TaskId { get; set; }

        [JsonPropertyName("Proyecto")]
        public string Name { get; set; }
        [JsonPropertyName("Título")]
        public string Title { get; set; }
        [JsonPropertyName("Descripción")]
        public string Description { get; set; }
        [JsonPropertyName(" Asignado a")]
        public string Assignee { get; set; }
        [JsonPropertyName("Estado")]
        public string Status { get; set; }
        [JsonPropertyName("Prioridad")]
        public string Priority { get; set; }
        [JsonPropertyName("Complejidad estimada")]
        public int EstimatedComplexity { get; set; }
        [JsonPropertyName("Fecha de vencimiento")]
        public DateTime DueDate { get; set; }
    }
}
