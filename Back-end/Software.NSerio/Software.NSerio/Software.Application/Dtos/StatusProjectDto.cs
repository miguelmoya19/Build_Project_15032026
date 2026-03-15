using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Software.Application.Dtos
{
    public class StatusProjectDto
    {
        //[JsonPropertyName("Proyecto ID")]
        public int ProjectId { get; set; }
        //[JsonPropertyName("Nombre")]
        public string Name { get; set; }
        //[JsonPropertyName("Nombre del cliente ")]
        public string ClientName { get; set; }
        //[JsonPropertyName("Estado")]
        public string Status { get; set; }
        //[JsonPropertyName("Desarollador")]
        public int AssigneeId { get; set; }
        public int? OpenTasks { get; set; }
        public int? CompletedTasks { get; set;  }
        public int? TotalTasks { get; set; } 
    }
}
