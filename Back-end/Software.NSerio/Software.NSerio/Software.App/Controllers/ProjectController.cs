using Microsoft.AspNetCore.Mvc;
using Software.Application.Interfaces.Usuario;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Software.NSerio.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProject _service;
        public ProjectController(IProject service)
        {
            this._service = service;
        }

        [HttpGet("")]

        public async Task<IResult> ProjectListAll()
        {
            return Results.Ok(await _service.GetAllProjectInformation());
        }


        [HttpGet("{id}/tasks")]

        public async Task<IResult> ProjectListAllFilter(int id, [FromQuery] string status = "", [FromQuery] int assigneeId = -1, [FromQuery] int page = -1)
        {
            return Results.Ok(await _service.FilterGetAllProject(id,status,assigneeId, page));
        }


    }
}
