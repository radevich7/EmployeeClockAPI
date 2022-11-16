using EmployeeClock.API.ResourseParameters;
using EmployeeClock.Entities;
using EmployeeClock.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Repository.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<PagedList<Employee>> GetAllEmployeesAsync(EmployeeResourceParameters resourceParameters );
        Task<Employee> GetEmployeeAsync(Guid employeeID, bool includeTimetransaction = false);

        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);

        Task<bool> EmployeeExistAsync(Guid employeeID);

        Task<bool> SaveChangesAsync();

    }
}
