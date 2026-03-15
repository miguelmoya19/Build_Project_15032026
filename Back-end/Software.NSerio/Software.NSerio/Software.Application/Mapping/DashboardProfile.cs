using AutoMapper;
using Software.Application.Dtos;
using Software.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Mapping
{
    public class DashboardProfile : Profile
    {

        public DashboardProfile()
        {
            CreateMap<ChargeDeveloper, ChargeDeveloperDto>();
            CreateMap<ProjectOverview, ProjectOverviewDto>();
        }

    }
}
