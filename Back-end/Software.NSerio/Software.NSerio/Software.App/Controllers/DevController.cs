using Microsoft.AspNetCore.Mvc;
using Software.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Software.NSerio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevController : ControllerBase
    {
        private IDev _service;

        public DevController(IDev service)
        {
            this._service = service;
        }

        [HttpGet("developers")]

        public async Task<IResult> GetAllInformationDevActive()
        {
            return Results.Ok(await _service.GetAllInformationDevActive());
        }
    }
}
