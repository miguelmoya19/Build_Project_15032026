using Software.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Entities
{
    public class FilterTaskModel
    {
		public string Title { get; set; }
		public string Fullname { get; set; }
		public string Status { get; set; }
		public string Priority { get; set; }
		public int AssigneeId { get; set; }
		public int EstimatedComplexity { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime DueDate { get; set; }
    }
}

