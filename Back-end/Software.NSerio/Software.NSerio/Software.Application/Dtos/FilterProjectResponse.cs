
using Software.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Application.Dtos
{
    public class FilterProjectResponse
    {
        public IEnumerable<FilterTaskModelReposiDTO> Items { get; set; }
        public decimal? PageSize { get; set; }
    }
}
