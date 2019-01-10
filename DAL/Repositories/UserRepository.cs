using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IRepositories;
using BLL.Models;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context) { }

        public User GetWithUserRoles(string name, string password)
        {
            return RepositoryContext.Users.Include(x => x.UserRoles).Where(x => x.Name == name && x.Password == password).FirstOrDefault();
        }
    }
}
