using AutoMapper;
using Software.Application.Dtos;
using Software.Application.Interfaces;
using Software.Application.Interfaces.Usuario;
using Software.Domain.Entities;
using Software.Domain.Interfaces.Repository;
using Software.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Services
{
    public class ProjectService : IProject
    {

        private readonly IRepositoryProjects _handlerProject;
        private readonly IMapper _mapper;

        public ProjectService(IRepositoryProjects handlerProject, IMapper mapper)
        {
            this._handlerProject = handlerProject;
            this._mapper = mapper;
        }


        #region Consult

        /// <summary>
        /// Se obtiene la información de los projectos requeridos
        /// </summary>
        /// <returns>Se retorna información de tipo mutable.</returns>

        public async Task<IEnumerable<StatusProjectDto>?> GetAllProjectInformation()
        {
            var data = await _handlerProject.GetAllProjects();
            return _mapper.Map<IEnumerable<StatusProjectDto>>(data) ?? Enumerable.Empty<StatusProjectDto>();
        }

        /// <summary>
        /// Se crea función para hacer paginacion dependiendo del filtro.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="assigned"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<ResponseModel<FilterProjectResponse>> FilterGetAllProject(int id, string status = "", int assigned = -1,int page = -1)
        {

            var information = await _handlerProject.GetAllProjectsFilter(id,status,assigned,page);

            return await Task.FromResult(new ResponseModel<FilterProjectResponse>()
            {
                Data = new FilterProjectResponse
                {
                    Items = _mapper.Map<IEnumerable<FilterTaskModelReposiDTO>>(information.Item1),
                    PageSize = information.Item2
                },
                Message = "Success data.",
                StatusCode = System.Net.HttpStatusCode.OK,
            });
        }

        #endregion
    }
}
