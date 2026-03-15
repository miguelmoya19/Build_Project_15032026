using Software.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Software.Application.Dtos
{
    public class DevelopersDto
    {
        [JsonPropertyName("Id")]
        public int DeveloperId { get; private set; }
        [JsonPropertyName("Nombre")]
        public string FirstName { get; private set; }
        public string? LastName { get; set; }
        [JsonPropertyName("Email")]
        public Email? Email { get; private set; }
        public bool? IsActive { get; private set; }

    }
}
