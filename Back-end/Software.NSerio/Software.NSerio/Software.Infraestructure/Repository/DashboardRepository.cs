using Microsoft.EntityFrameworkCore;
using Software.Domain.Entities;
using Software.Domain.Interfaces.Repository;
using Software.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Repository
{
    public class DashboardRepository : IRepositoryDashboard
    {

        private readonly AppDbContext _context;

        public DashboardRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<ProjectOverview>> SP_GetStatusForProject()
        {
            try
            {
                var task = await _context.StatusForProject.FromSqlRaw("EXEC Sp_StatusForProJect").ToListAsync();
                return task.Select(v => new ProjectOverview
                {
                    ProjectId = v.ProjectId,
                    ClientName = v.ClientName,
                    Status = v.Status,
                    OpenTasks = v.OpenTasks,
                    CompletedTasks = v.CompletedTasks,
                    TotalTasks = v.TotalTasks,
                    Name = v.Name
                });

            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ChargeDeveloper>> GetWorkLoad()
        {
            try
            {
                var data = await _context.ChargeDeveloperView.
                    OrderBy(s => s.FullName).
                    ThenBy(s => s.OpenTasksCount).
                    Select(v => new ChargeDeveloper
                    {
                        AverageEstimatedComplexity = v.AverageEstimatedComplexity,
                        DeveloperId = v.DeveloperId,
                        FullName = v.FullName,
                        OpenTasksCount = v.OpenTasksCount
                    }).ToListAsync();

                return data;
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
