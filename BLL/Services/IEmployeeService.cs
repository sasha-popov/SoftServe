﻿using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using BLL.Models;

namespace BLL.Services
{
   public interface IEmployeeService
    {
        void CreateEmployee(User user);
        void CreateVacationRequest(UserVacationRequestDTO userVacationRequestDTO);
        List<UserVacationRequestDTO> ShowUserVacationRequest(int id);
    }
}
