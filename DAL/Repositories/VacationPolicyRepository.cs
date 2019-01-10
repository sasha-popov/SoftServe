using System.Collections.Generic;
using System.Linq;
using BLL.IRepositories;
using BLL.Models;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class VacationPolicyRepository : GenericRepository<VacationPolicy>, IVacationPolicyRepository
    {
        public VacationPolicyRepository(ProjectContext context) : base(context) { }

        public IEnumerable<VacationPolicy> GetAllVacationPoliciesWithTypes()
        {
            return RepositoryContext.VacationPolicies.Include(x => x.VacationType);
        }

       public IEnumerable<VacationPolicy> FindWithTypes(UserVacationRequest userVacationRequest)
        {
            return RepositoryContext.VacationPolicies.Include(x => x.VacationType).Where(x => x.VacationType.Id == userVacationRequest.VacationType.Id);
        }

    }
}
