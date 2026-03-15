
using Software.Domain.Dtos;
using Software.Domain.Entities;
using Software.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Software.Domain.Interfaces.Repository
{
    public interface IRepositoryTask
    {
        public Task<int> InsertAsyncTask(TaskModel model);
        public Task<int> UpdateAsyncTask(int id,FieldsTaskModel model);
        public Task<IEnumerable<AllTasksViewModel>> AllTasks();
        public Task<string> GetMultiResultInformation();
        public Task<IEnumerable<TaskModel>> GetTasksById(int id);

    }
}
