using AutoMapper;
using Software.Application.Dtos;
using Software.Application.Interfaces;
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
    public class DeveloperService : IDev
    {

        private readonly IRepositoryDeveloper _dbHandlerDev;
        private readonly IMapper _mapper;
        public DeveloperService(IRepositoryDeveloper dbHandlerDev, IMapper mapper) {
        
            this._dbHandlerDev = dbHandlerDev;
            this._mapper = mapper;
        }

        public async Task<ResponseModel<IEnumerable<DevelopersDto>>> GetAllInformationDevActive()
        {
            var data = await _dbHandlerDev.GetAllInformationDev();

            return await Task.FromResult(new ResponseModel<IEnumerable<DevelopersDto>>
            {
                Data = _mapper.Map<IEnumerable<DevelopersDto>>(data),
                Message = "Ok correctamente",
                StatusCode = System.Net.HttpStatusCode.OK
            });
        }
    }
}
