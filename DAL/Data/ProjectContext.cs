using System;
using System.Collections.Generic;
using System.Text;
using BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
        public ProjectContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserVacationRequest> UserVacantionRequests { get; set; }
        public DbSet<VacationPolicy> VacationPolicies { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }

        public DbSet<CompanyHoliday> CompanyHolidays { get; set; }
    }
}
