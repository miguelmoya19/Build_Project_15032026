using Software.Domain.Common;
using Software.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Persistence
{
    public class TaskModel : BaseEntity
    {

        public int? TaskId { get; set; }
        public int? ProjectId { get; set;  }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? AssigneeId { get; set; }
        public int? Status { get; set; }
        public int Priority { get; set; }
        public int EstimatedComplexity { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }


    }
}
