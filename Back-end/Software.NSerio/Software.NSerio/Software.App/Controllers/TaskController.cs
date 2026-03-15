using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Software.Application.Interfaces;
using Software.Domain.Dtos;
using Software.Domain.Entities;
using Software.Infraestructure.Persistence;

namespace Software.NSerio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {

        private readonly ITask _service;

        public TaskController(ITask service)
        {
            _service = service;
        }

        [HttpPost("tasks")]

        public async Task<IResult> InsertInformationTask([FromBody] TaskModel model)
        {
                return Results.Ok(await _service.InsertInformationTask(model));
        }

        [HttpPut("{id}/status")]

        public async Task<IResult> UpdateInformationTask(int id,[FromBody] FieldsTaskModel model)
        {
            return Results.Ok(await _service.UpdateInformationTask(id,model));
        }

        [HttpGet("allTasks")]

        public async Task<IResult> GetAllTask()
        {
            return Results.Ok(await _service.GetAllTask());
        }

        [HttpGet("multiResult")]

        public async Task<IResult> multiResult()
        {
            return Results.Ok(await _service.GetInformationAllMulti());
        }

        [HttpGet("GetTasksById")]

        public async Task<IResult> GetTasksById(int id)
        {
            return Results.Ok(await _service.GetTasksById(id));
        }

    }
}
