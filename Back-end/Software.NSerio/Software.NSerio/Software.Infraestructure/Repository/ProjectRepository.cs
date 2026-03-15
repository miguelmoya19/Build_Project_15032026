using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Software.Domain.Entities;
using Software.Domain.Interfaces.Repository;
using Software.Infraestructure.Persistence;
using Software.Infraestructure.Persistence.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Repository
{
    public class ProjectRepository : IRepositoryProjects
    {
        private readonly AppDbContext _context;
        private readonly int pageSize = 5;

        public ProjectRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<StatusProject>> GetAllProjects()
        {
            try
            {
                return await _context.StatusProjectView
                            .Select(v => new StatusProject
                            {
                                ProjectId = v.ProjectId,
                                Name = v.Name,
                                ClientName = v.ClientName,
                                TotalTasks = v.TotalTasks,
                                Status = v.Status,
                                AssigneeId = v.AssigneeId,
                                OpenTasks = v.OpenTasks,
                                CompletedTasks = v.CompletedTasks
                            })
                            .ToListAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<(IEnumerable<FilterTaskModel>,decimal)> GetAllProjectsFilter(int id,string status = "",int assigned = -1,int page = -1)
        {
            try
            {
                var data = await _context.FilterTaskModelReposiModel.FromSqlRaw("EXEC SP_FilterForTask @ProjectId", 
                    new SqlParameter("@ProjectId", id))
                   .ToListAsync();


                int count = data.Count();

                data = data.Skip(page).Take(pageSize).ToList();

                if (status != string.Empty)
                {
                    data = data.Where(s => s.Status == status).ToList();
                }

                if (assigned != -1)
                {
                    data = data.Where(s => s.AssigneeId == assigned).ToList();
                }

                var resultPagination = data.Select(s => new FilterTaskModel
                {
                    Status = s.Status,
                    Title = s.Title,
                    Priority = s.Priority,
                    AssigneeId = s.AssigneeId,
                    CreatedAt = s.CreatedAt,
                    DueDate = s.DueDate,
                    EstimatedComplexity = s.EstimatedComplexity,
                    Fullname = s.Fullname
                }).ToList();

                return (resultPagination, Math.Ceiling(count / 5m));
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //public async Task<Developers?> AuthenticationUser()
        //{
        //    try
        //    {
        //        return await _context.Developers.FirstAsync();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task ActivateSessionAsync(int id)
        //{
        //    try
        //    {
        //        var user = await _context.Developers.FirstAsync();

        //        //if(user != null)
        //        //{
        //        //    user.SessionActive = true;
        //        //    await _context.SaveChangesAsync();
        //        //}

        //    }
        //    catch (MySqlException ex)
        //    {
        //        throw;
        //    }
        //}


    }
}
