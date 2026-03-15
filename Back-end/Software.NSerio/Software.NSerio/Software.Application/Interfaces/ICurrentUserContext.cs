using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Interfaces
{
    public interface ICurrentUserContext
    {
        string UserId { get; }
        string Username { get; }
        string Ip { get; }
    }
}
