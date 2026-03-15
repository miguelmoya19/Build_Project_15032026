using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Persistence.View
{
    public class StatusForProject
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string Status { get; set; }

        public int AssigneeId { get; set; }
        public int? OpenTasks { get; set; }
        public int? CompletedTasks { get; set; }
        public int? TotalTasks { get; set; }
    }
}
