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
    public class DepartmentRepo :GenericRepo<Department> ,IDepartmentRepo
    {
        public DepartmentRepo(ApplicationDbContext dbContext):base(dbContext)
        {
            
        }
    }
}
