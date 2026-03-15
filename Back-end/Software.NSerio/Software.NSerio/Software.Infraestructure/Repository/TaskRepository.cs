using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Software.Domain.Dtos;
using Software.Domain.Entities;
using Software.Domain.Interfaces.Repository;
using Software.Infraestructure.Persistence;
using Software.Infraestructure.Persistence.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Software.Infraestructure.Repository
{
    public class TaskRepository : IRepositoryTask
    {

        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllTasksViewModel>> AllTasks()
        {

            var data = await _context.AllTasksView.ToListAsync();

            return data.Select(s => new AllTasksViewModel
            {
                TaskId = s.TaskId,
              Assignee = s.Assignee,
              Description = s.Description,
              DueDate = s.DueDate,
              EstimatedComplexity = s.EstimatedComplexity,
              Name = s.Name,
              Priority = s.Priority,    
              Title = s.Title,
              Status = s.Status
            }).ToList();


        }

        public async Task<string> GetMultiResultInformation()
        {
            using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "LoadInformationInitial";
            command.CommandType = CommandType.StoredProcedure;

            using var reader = await command.ExecuteReaderAsync();

            StringBuilder sb = new StringBuilder();

            if (await reader.ReadAsync())
            {
                sb.Append(reader.GetString(0));

                return sb.ToString();
            }

            return string.Empty;

        }

    

        public async Task<int> InsertAsyncTask(TaskModel model)
        {
                await _context.Database.ExecuteSqlInterpolatedAsync($@"
                                                EXEC SP_InsertTask 
                                                    @ProjectId={model.ProjectId},
                                                    @Title={model.Title},
                                                    @Description={model.Description},
                                                    @AssigneeId={model.AssigneeId},
                                                    @Status={model.Status},
                                                    @Priority={model.Priority},
                                                    @EstimatedComplexity={model.EstimatedComplexity},
                                                    @DueDate={model.DueDate},
                                                    @CompletionDate={model.CompletionDate}
                                            ");
                return await Task.FromResult(1);

        }

        public async Task<int> UpdateAsyncTask(int id, FieldsTaskModel model)
        {
         
                var firstTask = await _context.Task.FirstOrDefaultAsync(s => s.TaskId == id);

                if (firstTask is null) throw new Exception("Task no encontrado.");

                firstTask.Status = model.Status;
                firstTask.Priority = model.Priority;
                firstTask.EstimatedComplexity = model.EstimatedComplexily;

                await _context.SaveChangesAsync();

                return await Task.FromResult(1);

        }

        public async Task<IEnumerable<TaskModel>> GetTasksById(int id)
        {
            var data = await _context.TaskModel.Where(t => t.TaskId == id).ToListAsync();
            return data;
        }
    }
}
