using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IDepartmentRepo DepartmentRepo { get; set; }
        public IEmployeeRepo EmployeeRepo { get; set; }

        public int Complete();
    }
}
