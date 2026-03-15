using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Software.Application.Dtos
{
    public class FilterTaskModelReposiDTO
    {
        [JsonPropertyName("Titulo")]
        public string Title { get; set; }
        [JsonPropertyName("Nombre")]
        public string Fullname { get; set; }
        [JsonPropertyName("Estado")]
        public string Status { get; set; }
        [JsonPropertyName("Prioridad")]
        public string Priority { get; set; }
        [JsonPropertyName("Complejidad estimada")]
        public int EstimatedComplexity { get; set; }
        [JsonPropertyName("Creado a")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("Fecha de vencimiento")]
        public DateTime DueDate { get; set; }
    }
}
