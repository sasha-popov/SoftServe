using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BLL.IRepositories;
using BLL.Models;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserVacationRequestRepository : GenericRepository<UserVacationRequest>, IUserVacationRequestRepository
    {
        public UserVacationRequestRepository(ProjectContext context) : base(context) { }

        public IEnumerable<UserVacationRequest> FindByConditionWithUser(Expression<Func<UserVacationRequest, bool>> expression)
        {
            return this.RepositoryContext.UserVacantionRequests.Include(x=>x.User).Include(x=>x.VacationType).Where(expression);
        }
    }
}
