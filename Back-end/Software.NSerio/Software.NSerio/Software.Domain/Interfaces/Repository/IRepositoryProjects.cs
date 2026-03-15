
using Software.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Interfaces.Repository
{
    public interface IRepositoryProjects
    {
        public Task<IEnumerable<StatusProject>> GetAllProjects();
        public Task<(IEnumerable<FilterTaskModel>, decimal)> GetAllProjectsFilter(int id,string status = "", int assigned = -1 ,int page = -1);
    }
}
