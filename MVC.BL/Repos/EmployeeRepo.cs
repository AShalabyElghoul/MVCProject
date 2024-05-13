using MVC.BL.Interfaces;
using MVC.DAL.Data;
using MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BL.Repos
{
    public class EmployeeRepo :GenericRepo<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(ApplicationDbContext dbContext):base(dbContext)
        {

        }
        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
            return _dbContext.Employees.Where(E => E.Address.ToLower() == address);
        }
    }
}
