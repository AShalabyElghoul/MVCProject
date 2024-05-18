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
    public class GenericRepo<T> : IGenericRepo<T> where T : ModelBase
    {
        private protected readonly ApplicationDbContext _dbContext;

        public GenericRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            if (entity is not null)
                _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
          =>  _dbContext.Set<T>().Update(entity);
  

        public void Delete(T entity)
          =>  _dbContext.Set<T>().Remove(entity);


        public T GetById(int id)
        {
            return _dbContext.Find<T>(id);
        }
        public IEnumerable<T> GetAll()
            => _dbContext.Set<T>().AsNoTracking().ToList();




    }
}
