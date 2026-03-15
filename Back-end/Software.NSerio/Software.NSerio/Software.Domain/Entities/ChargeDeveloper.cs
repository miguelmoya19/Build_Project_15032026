using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Entities
{
    public class ChargeDeveloper
    {
        public int DeveloperId { get; set; }

        public string FullName { get; set; }
        public int OpenTasksCount { get; set; }
        public int AverageEstimatedComplexity { get; set; }
    }
}
