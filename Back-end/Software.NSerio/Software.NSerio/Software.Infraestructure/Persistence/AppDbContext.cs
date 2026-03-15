using Microsoft.EntityFrameworkCore;
using Software.Domain.Common;
using Software.Domain.Entities;
using Software.Infraestructure.Persistence.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
        }

        #region Tables into BD
        public DbSet<Developers> Developers { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<StatusProjectView> StatusProjectView { get; set; }
        public DbSet<ProjectWithTaskFilterView> ProjectWithTaskListFilter { get; set; }
        public DbSet<ChargeDeveloperView> ChargeDeveloperView { get; set; }
        public DbSet<StatusForProjectReposiModel> StatusForProject { get; set; }
        public DbSet<TaskModel> Task { get; set; }
        public DbSet<AllTasksView> AllTasksView { get; set; }
        public DbSet<FilterTaskModelReposi> FilterTaskModelReposiModel { get; set; }
        public DbSet<TaskModel> TaskModel { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}
