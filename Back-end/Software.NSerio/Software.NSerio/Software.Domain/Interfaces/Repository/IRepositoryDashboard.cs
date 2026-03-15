using Software.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Interfaces.Repository
{
    public interface IRepositoryDashboard
    {
        public Task<IEnumerable<ChargeDeveloper>> GetWorkLoad();

        public Task<IEnumerable<ProjectOverview>> SP_GetStatusForProject();
    }
}
