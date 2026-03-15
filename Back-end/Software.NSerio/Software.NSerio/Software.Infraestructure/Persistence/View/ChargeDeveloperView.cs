using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Persistence.View
{
    public class ChargeDeveloperView
    {
        [Key]
        public int DeveloperId { get; set; }
        public string FullName { get; set; }
        public int OpenTasksCount { get; set; }
        public int AverageEstimatedComplexity { get; set; }
    }
}
