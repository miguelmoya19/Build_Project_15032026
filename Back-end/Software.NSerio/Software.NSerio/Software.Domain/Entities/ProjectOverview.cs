using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Entities
{
    public class ProjectOverview
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string Status { get; set; }
        public int OpenTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int TotalTasks { get; set; }

    }
}
