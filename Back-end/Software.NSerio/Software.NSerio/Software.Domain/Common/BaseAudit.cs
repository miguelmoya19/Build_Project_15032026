using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Common
{
    public class BaseAudit
    {
        public string IpAddress { get; set; }
        public string Action { get; set; }

        public string TableName { get; set; }
        public string? Data { get;set; }

        public string? Username { get; set; }
        public DateTime? auditDate { get; } = DateTime.UtcNow;
    }
}
