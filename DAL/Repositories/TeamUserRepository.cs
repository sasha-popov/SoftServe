using System;
using System.Collections.Generic;
using System.Text;
using BLL.IRepositories;
using BLL.Models;
using DAL.Data;

namespace DAL.Repositories
{
    public class TeamUserRepository : GenericRepository<TeamUser>, ITeamUserRepository
    {
        public TeamUserRepository(ProjectContext context) : base(context) { }
    }
}
