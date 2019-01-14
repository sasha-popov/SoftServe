using System;
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

       public List<VacationPolicy> FindCurrentVacationPolicy(UserVacationRequest userVacationRequest)
        {
            int workingYears = DateTime.Now.Year - userVacationRequest.User.DateRecruitment.Year;
            return RepositoryContext.VacationPolicies.Include(x => x.VacationType).Where(x => x.VacationType.Id == userVacationRequest.VacationType.Id).Where(x => x.WorkingYear >= workingYears).ToList().OrderBy(x => x.WorkingYear).Take(2).ToList(); ;
        }

        public VacationPolicy FindForDelete(int years, string vacationType, int payments)
        {
            return RepositoryContext.VacationPolicies.Include(x => x.VacationType).Where(x => x.WorkingYear == years && x.VacationType.Name == vacationType && x.Payments == payments).First();
        }

    }
}
