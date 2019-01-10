using System;
using System.Collections.Generic;
using System.Text;
using BLL.Models;

namespace BLL.IRepositories
{
    public interface IVacationPolicyRepository : IGenericRepository<VacationPolicy>
    {
        IEnumerable<VacationPolicy> GetAllVacationPoliciesWithTypes();
        IEnumerable<VacationPolicy> FindWithTypes(UserVacationRequest vacationtype);
    }
}
