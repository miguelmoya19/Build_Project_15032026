using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Software.Application.Dtos
{
    public class ChargeDeveloperDto
    {
        [JsonPropertyName("Desarollador")]
        public string FullName { get; set; }

        [JsonPropertyName("Tareas abiertas")]
        public string OpenTasksCount { get; set; }

        [JsonPropertyName("Complejidad")]
        public string AverageEstimatedComplexity { get; set; }
    }
}
