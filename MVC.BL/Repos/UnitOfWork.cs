using Microsoft.EntityFrameworkCore;
using MVC.BL.Interfaces;
using MVC.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BL.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDepartmentRepo DepartmentRepo { get; set; }
        public IEmployeeRepo EmployeeRepo { get; set; }
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
            DepartmentRepo = new DepartmentRepo(dbContext);
            EmployeeRepo= new EmployeeRepo(dbContext);
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
