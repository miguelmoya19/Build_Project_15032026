using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Dtos
{
    public class FieldsTaskModel
    {
        public int Status { get; set; }
        public int Priority { get; set; }

        public int EstimatedComplexily { get; set; }
    }
}
