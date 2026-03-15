using Software.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Entities
{
    public class Projects
    {
        public int ProjectId { get; private set; }
        public string Name { get; private set; }
        public string? ClientName { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string? Status { get; private set; }


    }
}
