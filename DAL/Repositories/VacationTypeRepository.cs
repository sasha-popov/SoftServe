using System;
using System.Collections.Generic;
using System.Text;
using BLL.IRepositories;
using BLL.Models;
using DAL.Data;

namespace DAL.Repositories
{
    public class VacationTypeRepository : GenericRepository<VacationType>, IVacationTypeRepository
    {
        public VacationTypeRepository(ProjectContext context) : base(context) { }
    }
}