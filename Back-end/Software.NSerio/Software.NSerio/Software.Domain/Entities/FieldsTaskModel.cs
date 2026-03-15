using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Dtos
{
    public class FieldsTaskModel
    {
        public string Status { get; set; }
        public string Priority { get; set; }

        public int EstimatedComplexity { get; set; }
    }
}
