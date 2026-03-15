using Software.Application.Dtos;
using Software.Domain.Dtos;
using Software.Domain.Entities;
using Software.Infraestructure.Persistence;
using Software.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Interfaces
{
    public interface ITask
    {
        public Task<ResponseModel<int>> InsertInformationTask(TaskModel model);
        public Task<ResponseModel<int>> UpdateInformationTask(int id, FieldsTaskModel model);
        public Task<ResponseModel<IEnumerable<AllTasksViewDto>>> GetAllTask();

        public Task<ResponseModel<CodeGenericModel>> GetInformationAllMulti();

        public Task<IEnumerable<TaskModel>> GetTasksById(int id);
    }
}
