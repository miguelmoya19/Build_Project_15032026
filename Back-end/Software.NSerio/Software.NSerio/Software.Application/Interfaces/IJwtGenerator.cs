using Software.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Interfaces
{
    public interface IJwtGenerator
    {
        public Task GeneratorToken(Developers dev);
    }
}
