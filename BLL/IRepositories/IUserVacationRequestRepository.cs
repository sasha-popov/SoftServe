using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using BLL.Models;

namespace BLL.IRepositories
{
    public interface IUserVacationRequestRepository : IGenericRepository<UserVacationRequest>
    {
        IEnumerable<UserVacationRequest> FindByConditionWithUser(Expression<Func<UserVacationRequest, bool>> expression);
    }
}
