using Software.Application.Dtos;
using Software.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Interfaces
{
    public interface IDashDeveloper
    {

        public Task<ResponseModel<IEnumerable<ChargeDeveloperDto>>> GetWorkLoadAll();
        public Task<ResponseModel<IEnumerable<ProjectOverviewDto>>> GetProjectOverview();
    }
}
