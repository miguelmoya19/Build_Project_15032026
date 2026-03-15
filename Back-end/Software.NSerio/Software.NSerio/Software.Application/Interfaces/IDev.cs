using Software.Application.Dtos;
using Software.Domain.Entities;
using Software.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Interfaces
{
    public interface IDev
    {
        public Task<ResponseModel<IEnumerable<DevelopersDto>>> GetAllInformationDevActive();
    }
}
