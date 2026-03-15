using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Common
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }


}
