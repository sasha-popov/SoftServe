using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BLL.DTO;
using BLL.IRepositories;
using BLL.Models;

namespace BLL.Services
{
  public  class VacationPoliciesService: IVacationPoliciesService
    {
        private IVacationTypeRepository _vacationTypeRepository;
        private IVacationPolicyRepository _vacationPolicyRepository;
        private IUserRepository _userRepository;
        private IEmployeeService _employeeService;
        private readonly IMapper _mapper;


        public VacationPoliciesService(IMapper mapper, IVacationTypeRepository vacationTypeRepository, IVacationPolicyRepository vacationPolicyRepository, IUserRepository userRepository, IEmployeeService employeeService)
        {
            _vacationTypeRepository = vacationTypeRepository;
            _vacationPolicyRepository = vacationPolicyRepository;
            _userRepository = userRepository;
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public void SendVacationPolicy(VacationPolicyDTO newVacationPolicy)
        {
            var result = _mapper.Map<VacationPolicy>(newVacationPolicy);
            result.VacationType = _vacationTypeRepository.FindByCondition(y => y.Name == newVacationPolicy.VacationType).First();
            _vacationPolicyRepository.Create(result);
            _vacationPolicyRepository.Save();
        }

        public List<VacationPolicyDTO> GetVacationPolicies()
        {
            List<VacationPolicy> allVacationPolicy = _vacationPolicyRepository.GetAllVacationPoliciesWithTypes().ToList();
            var resultDTO = _mapper.Map<List<VacationPolicyDTO>>(allVacationPolicy);
            return resultDTO;
        }

        public void DeleteVacationPolicy(int years, string vacationType, int payments)
        {
            var currentVacationPolicy = _vacationPolicyRepository.FindForDelete(years, vacationType, payments);
            _vacationPolicyRepository.Delete(currentVacationPolicy);
            _vacationPolicyRepository.Save();
        }
    }
}
