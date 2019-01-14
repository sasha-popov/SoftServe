using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services
{
    public interface IVacationPoliciesService
    {
        List<VacationPolicyDTO> GetVacationPolicies();
        void DeleteVacationPolicy(int years, string vacationType, int payments);
        void SendVacationPolicy(VacationPolicyDTO newVacationPolicy);

    }
}
