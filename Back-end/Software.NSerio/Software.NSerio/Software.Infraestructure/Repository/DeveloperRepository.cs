using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Software.Application.Interfaces;
using Software.Domain.Entities;
using Software.Domain.Interfaces.Repository;
using Software.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Repository
{
    public class DeveloperRepository : IRepositoryDeveloper
    {
        private readonly AppDbContext _context;
        

        public DeveloperRepository(AppDbContext context) {
        
            _context = context;
        }

        public async Task<IEnumerable<Developers>> GetAllInformationDev()
        {
            try
            {
                return await _context.Developers.Where(s => s.IsActive == true).ToListAsync();
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
