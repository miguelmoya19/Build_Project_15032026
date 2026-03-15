using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Persistence
{
    public class StatusForProjectReposiModel
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string Status { get; set; }
        public int OpenTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int TotalTasks { get; set; }
    }
}
