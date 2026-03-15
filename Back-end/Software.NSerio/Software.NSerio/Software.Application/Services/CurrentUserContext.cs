using Microsoft.AspNetCore.Http;
using Software.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Services
{
    public class CurrentUserContext : ICurrentUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserContext(IHttpContextAccessor httpContextAccessor) {

            this._httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor?.HttpContext?.User?.FindFirst("IdUnique")?.Value ?? string.Empty;

        public string Username => _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;

        public string Ip => _httpContextAccessor?.HttpContext.Connection.RemoteIpAddress.ToString() ?? string.Empty;
    }
}
