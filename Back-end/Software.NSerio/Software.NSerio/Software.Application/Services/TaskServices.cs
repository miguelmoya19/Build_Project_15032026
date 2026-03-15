using AutoMapper;
using Software.Application.Dtos;
using Software.Application.Interfaces;
using Software.Domain.Dtos;
using Software.Domain.Entities;
using Software.Domain.Interfaces.Repository;
using Software.Domain.Rules;
using Software.Infraestructure.Persistence;
using Software.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Software.Application.Services
{
    public class TaskServices : ITask
    {
        private readonly IRepositoryTask _dbHandlerTask;
        private readonly IMapper _mapper;

        public TaskServices(IRepositoryTask dbHandlerTask, IMapper mapper) {
        
             this._dbHandlerTask = dbHandlerTask;
             this._mapper = mapper;
        }

        public async Task<ResponseModel<IEnumerable<AllTasksViewDto>>> GetAllTask()
        {

            var data = await _dbHandlerTask.AllTasks();
            return await Task.FromResult(new ResponseModel<IEnumerable<AllTasksViewDto>>
            {
                Data = _mapper.Map<IEnumerable<AllTasksViewDto>>(data),
                Message = "",
                StatusCode = System.Net.HttpStatusCode.OK
            });
        }

        public async Task<ResponseModel<CodeGenericModel>> GetInformationAllMulti()
        {
            var result = await _dbHandlerTask.GetMultiResultInformation();
            var convertResultJson = JsonSerializer.Deserialize<CodeGenericModel>(result);

            var project = convertResultJson.Projects ?? new List<modelProject>();
            var priority = convertResultJson.Priority ?? new List<ModelPriority>();
            var dev = convertResultJson.Developers ?? new List<ModelDeveloper>();
            var task = convertResultJson.Tasks ?? new List<ModelTask>();

            return await Task.FromResult(new ResponseModel<CodeGenericModel>()
            {
                Data = new CodeGenericModel
                {
                    Developers = dev,
                    Priority = priority,
                    Projects = project,
                    Tasks = task
                },
                Message = "",
                StatusCode = System.Net.HttpStatusCode.OK
            });
        }



        public async Task<ResponseModel<int>> InsertInformationTask(TaskModel model)
        {
            TaskValidator.ValidateFieldDescription(model.Description ?? "");
            TaskValidator.ValidatorLengthTitle(model!.Title ?? "");
            TaskValidator.ValidatorLengthStatus(model!.Status ?? -1);
            TaskValidator.ValidatorEstimatedComplexity(model.EstimatedComplexity);
            TaskValidator.ValidatorFkProjectAndDev(model.AssigneeId, model.ProjectId);
            await _dbHandlerTask.InsertAsyncTask(model);

            return await Task.FromResult(new ResponseModel<int>
            {
                Data = 1,
                Message = "Se inserto correctamente la tarea."
            });
        }

        public async Task<ResponseModel<int>> UpdateInformationTask(int id, FieldsTaskModel model)
        {
            await _dbHandlerTask.UpdateAsyncTask(id, model);
            return await Task.FromResult(new ResponseModel<int>
            {
                Data = 1,
                Message = "Se actualizaco correctamente la tarea"
            });
        }




        public async Task<IEnumerable<TaskModel>> GetTasksById(int id)
        {

            var data = await _dbHandlerTask.GetTasksById(id);
            return data;
        }

    }
}
