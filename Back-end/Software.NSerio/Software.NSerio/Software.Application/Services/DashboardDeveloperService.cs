using AutoMapper;
using Software.Application.Dtos;
using Software.Application.Interfaces;
using Software.Domain.Interfaces.Repository;
using Software.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Services
{
    public class DashboardDeveloperService : IDashDeveloper
    {
        private readonly IRepositoryDashboard _dbHandlerDashDeveloper;
        private readonly IMapper _mapper;

        public DashboardDeveloperService(IRepositoryDashboard dbHandlerDashDeveloper, IMapper mapper) { 
        
             this._dbHandlerDashDeveloper = dbHandlerDashDeveloper;
            this._mapper = mapper;
        }

        public async Task<ResponseModel<IEnumerable<ProjectOverviewDto>>> GetProjectOverview()
        {
            var information = await _dbHandlerDashDeveloper.SP_GetStatusForProject();

            return await Task.FromResult(new ResponseModel<IEnumerable<ProjectOverviewDto>>
            {
                Data = _mapper.Map<IEnumerable<ProjectOverviewDto>>(information),
                Message = "Success load.",
                StatusCode = System.Net.HttpStatusCode.OK
            });
        }

        public async Task<ResponseModel<IEnumerable<ChargeDeveloperDto>>> GetWorkLoadAll()
        {
            var information = await _dbHandlerDashDeveloper.GetWorkLoad();

            return await Task.FromResult(new ResponseModel<IEnumerable<ChargeDeveloperDto>>
            {
                Data = _mapper.Map<IEnumerable<ChargeDeveloperDto>>(information),
                Message = "Success load.",
                StatusCode = System.Net.HttpStatusCode.OK
            });
        }
    }
}
