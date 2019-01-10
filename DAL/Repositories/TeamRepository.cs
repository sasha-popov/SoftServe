using System;
using System.Collections.Generic;
using System.Text;
using BLL.IRepositories;
using BLL.Models;
using DAL.Data;

namespace DAL.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(ProjectContext context) : base(context) { }

        
    }
}
