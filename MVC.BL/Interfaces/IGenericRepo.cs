using MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BL.Interfaces
{
    public interface IGenericRepo<T> where T : ModelBase
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add (T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
