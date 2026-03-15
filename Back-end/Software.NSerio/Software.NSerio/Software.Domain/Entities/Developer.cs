using Software.Domain.Common;
using Software.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Entities
{
    public class Developers : BaseEntity
    {
        public int DeveloperId { get; private set; }
        public string FirstName { get; private set; }
        public string? LastName { get; set; }
        public Email? Email { get; private set; }
        public bool? IsActive { get; private set; }
       
    }
}
