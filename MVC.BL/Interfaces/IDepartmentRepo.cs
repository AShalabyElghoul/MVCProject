using MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BL.Interfaces
{
    public interface IDepartmentRepo
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        int Add (Department entity);
        int Update(Department entity);
        int Delete(Department entity);
    }
}
