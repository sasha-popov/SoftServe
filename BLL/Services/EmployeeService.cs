using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BLL.DTO;
using BLL.IRepositories;
using BLL.Models;
using BLL.Statuses;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IUserRoleRepository _userRoleRepository;
        private IUserVacationRequestRepository _userVacationRequestRepository;
        private IVacationTypeRepository _vacationTypeRepository;
        private IVacationPolicyRepository _vacationPolicyRepository;
        private ICompanyHolidayRepository _companyHolidayRepository;

        public EmployeeService(IUserRepository userRepository, 
            IRoleRepository roleRepository, 
            IUserRoleRepository userRoleRepository, 
            IUserVacationRequestRepository userVacationRequestRepository,
            IVacationTypeRepository vacationTypeRepository,
            IVacationPolicyRepository vacationPolicyRepository,
            ICompanyHolidayRepository companyHolidayRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _userVacationRequestRepository = userVacationRequestRepository;
            _vacationTypeRepository = vacationTypeRepository;
            _vacationPolicyRepository = vacationPolicyRepository;
            _companyHolidayRepository = companyHolidayRepository;
        }


        public void CreateVacationRequest(UserVacationRequestDTO userVacationRequestDTO)
        {
            Mapper.Reset();
            Mapper.Initialize(x => x.CreateMap<UserVacationRequestDTO, UserVacationRequest>()
            .ForMember("VacationType", opt => opt.MapFrom(c => _vacationTypeRepository.FindByCondition(y => y.Name == userVacationRequestDTO.VacationType).First()))
            .ForMember("User", opt => opt.MapFrom(user => _userRepository.GetById(userVacationRequestDTO.User)))
            .ForMember("Status", opt => opt.MapFrom(statuses => 1))
            );
            var result = Mapper.Map<UserVacationRequestDTO, UserVacationRequest>(userVacationRequestDTO);

            if (userVacationRequestDTO.StartDate < userVacationRequestDTO.EndDate)
            {
                List<bool> checkOverlaps = CheckDublicate(result);
                var daysForVacation = CheckVacationPolicies(result);
                if (!checkOverlaps.Contains(true) && daysForVacation != null)
                {
                    result.Payment = daysForVacation.Payments;
                    _userVacationRequestRepository.Create(result);
                    _userVacationRequestRepository.Save();
                }
            }
        }

        public List<UserVacationRequestDTO> ShowUserVacationRequest(int id)
        {
            var userVacationRequests = _userVacationRequestRepository.FindByConditionWithUser(x => x.User.Id == id).ToList();
            Mapper.Reset();
            Mapper.Initialize(x => x.CreateMap<UserVacationRequest, UserVacationRequestDTO>()
            .ForMember("VacationType", opt => opt.MapFrom(c => c.VacationType.Name))
            .ForMember("User", opt => opt.MapFrom(user => user.User.Id))
            .ForMember("Status", opt => opt.MapFrom(statuses => Enum.GetName(typeof(RequestStatuses),statuses.Status))));
            var result = Mapper.Map<List<UserVacationRequest>, List<UserVacationRequestDTO>>(userVacationRequests);
            return result;
        }

        private List<bool> CheckDublicate(UserVacationRequest newRequest)
        {
            var currentRequests = _userVacationRequestRepository.FindByConditionWithUser(x => x.User.Id == newRequest.User.Id).ToList();

            List<bool> checkOverlaps = new List<bool>();
            if (currentRequests.Count == 0) {
                checkOverlaps.Add(false);
            }else {
                foreach (var request in currentRequests)
                {
                    checkOverlaps.Add((request.StartDate < newRequest.EndDate && newRequest.StartDate < request.EndDate));
                }
            }
            return checkOverlaps;
        }

        private CountOfVacationDTO CheckVacationPolicies(UserVacationRequest newrequest)
        {
            var allvacations = _userVacationRequestRepository.FindByConditionWithUser(x => x.User.Id == newrequest.User.Id).Where(x => (x.StartDate.Year == 2019) && (x.VacationType.Name == newrequest.VacationType.Name)).ToList();
            var allHolidays = _companyHolidayRepository.FindByCondition(x => x.Date.Year == DateTime.Now.Year);
            List<DateTime> allDatesPrev = new List<DateTime>();

            if (allvacations.Count != 0) {
                //count prev days without sat and sun
                foreach (var vacation in allvacations)
                {
                    for (DateTime date = vacation.StartDate; date <= vacation.EndDate; date = date.AddDays(1))
                        if (date.DayOfWeek.ToString() != "Saturday" && date.DayOfWeek.ToString() != "Sunday")
                        {
                            allDatesPrev.Add(date);
                        }
                }
                //count prev days without company holidays
                allDatesPrev= GetListDaysWithoutCompanyHolidays(allDatesPrev);
                //foreach (var checkHoliday in allHolidays)
                //{
                //    var item = allDatesPrev.SingleOrDefault(x => x.DayOfYear == checkHoliday.Date.DayOfYear);
                //    if (item != null)
                //    {
                //        allDatesPrev.Remove(item);
                //    }
                //}
            }                     

            //count days of current request
            List<DateTime> allDatesForCurrentRequest = new List<DateTime>();
            for (DateTime date = newrequest.StartDate; date <= newrequest.EndDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek.ToString() != "Saturday" && date.DayOfWeek.ToString() != "Sunday")
                {
                    allDatesForCurrentRequest.Add(date);
                }
            }
            //count days of current request without company holiday
            allDatesForCurrentRequest= GetListDaysWithoutCompanyHolidays(allDatesForCurrentRequest);
            //foreach (var checkHoliday in allHolidays)
            //{
            //    var item = allDatesForCurrentRequest.SingleOrDefault(x => x.DayOfYear == checkHoliday.Date.DayOfYear);
            //    if (item != null)
            //    {
            //        allDatesForCurrentRequest.Remove(item);
            //    }
            //}

            //get vacation policy for category        
            List<VacationPolicy> currentVacationPolicy = _vacationPolicyRepository.FindCurrentVacationPolicy(newrequest);
            int commonCountOfday = currentVacationPolicy[0].Count + currentVacationPolicy[0].Count;

            //it check if is dates yet
            int countAllDatesForCurrentRequest = allDatesForCurrentRequest.Count;
            int countAllDatesPrev = allDatesPrev.Count;
            if (commonCountOfday>= countAllDatesForCurrentRequest + countAllDatesPrev)
            {
                VacationPolicy PolicyWithPay = currentVacationPolicy.Find(x => x.Payments == x.Count);
                int remainderPayDays = PolicyWithPay.Count - (countAllDatesForCurrentRequest + countAllDatesPrev);

                if (remainderPayDays >= 0)
                {
                    return new CountOfVacationDTO { Payments = countAllDatesForCurrentRequest, Free = 0 };
                }
                else if (countAllDatesPrev > PolicyWithPay.Count)
                {
                    return new CountOfVacationDTO { Payments = 0, Free = countAllDatesForCurrentRequest };
                }
                else if (countAllDatesPrev < PolicyWithPay.Count)
                {
                    return new CountOfVacationDTO { Payments = allDatesForCurrentRequest.Count + remainderPayDays, Free = -remainderPayDays };
                }
            }
            return null;
        }

        private List<DateTime> GetListDaysWithoutCompanyHolidays(List<DateTime> allDateTimes)
        {
            var allHolidays = _companyHolidayRepository.FindByCondition(x => x.Date.Year == DateTime.Now.Year);
            List<DateTime> result= new List<DateTime>();
            foreach (var checkHoliday in allHolidays)
            {
                var item = allDateTimes.SingleOrDefault(x => x.DayOfYear == checkHoliday.Date.DayOfYear);
                if (item != null)
                {
                    allDateTimes.Remove(item);
                }
            }
            return allDateTimes;
        }

    }
}
