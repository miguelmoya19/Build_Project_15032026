using Software.Application.Dtos;
using Software.Domain.Entities;
using Software.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Interfaces.Usuario
{
    public interface IProject
    {
        public Task<IEnumerable<StatusProjectDto>> GetAllProjectInformation();

        public Task<ResponseModel<FilterProjectResponse>> FilterGetAllProject(int id, string status = "", int assigned = -1, int page = -1);
    }
}
