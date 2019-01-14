using System;
using System.Collections.Generic;
using System.Text;
using BLL.Models;

namespace BLL.IRepositories
{
    public interface IVacationPolicyRepository : IGenericRepository<VacationPolicy>
    {
        IEnumerable<VacationPolicy> GetAllVacationPoliciesWithTypes();
        List<VacationPolicy> FindCurrentVacationPolicy(UserVacationRequest userVacationRequest);

        VacationPolicy FindForDelete(int years, string vacationType, int payments);
    }
}
