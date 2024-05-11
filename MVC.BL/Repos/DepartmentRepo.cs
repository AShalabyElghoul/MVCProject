using Microsoft.EntityFrameworkCore;
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
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepo(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public int Add(Department entity)
        {
            if (entity is not null)
            {
                _dbContext.Add(entity);
                return _dbContext.SaveChanges();
            }
            return _dbContext.SaveChanges();
        }

        public int Update(Department entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public Department GetById(int id)
        {
            return _dbContext.Find<Department>(id);
        }
        public IEnumerable<Department> GetAll()
            => _dbContext.Departments.AsNoTracking().ToList();
       

       

    }
}
