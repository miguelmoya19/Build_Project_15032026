using Microsoft.AspNetCore.Mvc;
using Software.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Software.NSerio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashDeveloper _service;

        public DashboardController(IDashDeveloper service)
        {
            this._service = service;
        }

        [HttpGet("dashboard/developer-workload")]

        public async Task<IResult> GetDeveloperWorkLoad()
        {
            return Results.Ok(await _service.GetWorkLoadAll());
        }

        [HttpGet("dashboard/project-health")]

        public async Task<IResult> GetProjectOVerView()
        {
            return Results.Ok(await _service.GetProjectOverview());
        }
    }
}
