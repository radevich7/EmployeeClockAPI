using EmployeeClock.API.ResourseParameters;
using EmployeeClock.Entities;
using EmployeeClock.Repository.EmployeeRepository;
using EmployeeClock.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Test.Services
{
    public class EmployeeRepositoryService : IEmployeeRepository
    {
        private List<Employee> _listOfEmployees;

        public EmployeeRepositoryService()
        {
            Thread.Sleep(3000);

            _listOfEmployees = new()
            {

                  new Employee("Berry", "Griffin Beak Eldritch", "Legacy Gate SE", "4033077577", "test@gmail.com")
                 {
                     EmployeeID = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                     DateOfBirth = new DateTime(1993, 7, 23),
                     DateOfHire = new DateTime(2022, 1, 24),
                     EmergencyContactName = "Bob",
                     EmergencyContactPhone = "4033077997",

                 },
                 new Employee("Vladislav", "Bordick", "Shevcheko Str", "4033071277", "vladislav@gmail.com")
                 {
                     EmployeeID = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb23f9b23"),
                     DateOfBirth = new DateTime(1980, 12, 23),
                     DateOfHire = new DateTime(2021, 1, 1),
                     EmergencyContactName = "Vika",
                     EmergencyContactPhone = "4033012997",

                 },
                  new Employee("Anrew", "Borisuk", "Bow River", "4033071111", "andrew@gmail.com")
                  {
                      EmployeeID = Guid.Parse("d28888e9-2cd1-473a-a23f-e38cb23f9b23"),
                      DateOfBirth = new DateTime(1990, 3, 23),
                      DateOfHire = new DateTime(2019, 4, 6),
                      EmergencyContactName = "Kira",
                      EmergencyContactPhone = "4031112997",
                  }

            };


        }


        public void CreateEmployee(Employee employee)
        {
            _listOfEmployees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            var existingEmployee = _listOfEmployees.Where(temp => temp.EmployeeID == employee.EmployeeID).FirstOrDefault();

            if (existingEmployee != null)
            {
                _listOfEmployees.Remove(existingEmployee);
            }
            throw new ArgumentNullException(nameof(existingEmployee));
        }

        public Task<bool> EmployeeExistAsync(Guid employeeID)
        {
            var existingEmployee = _listOfEmployees.Where(temp => temp.EmployeeID == employeeID).FirstOrDefault();
            if (existingEmployee == null)
                return Task.FromResult(false);

            return Task.FromResult(true);
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Employee>> GetAllEmployeesAsync(EmployeeResourceParameters resourceParameters)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeAsync(Guid employeeID, bool includeTimetransaction = false)
        {
            var existingEmployee = _listOfEmployees.Where(temp => temp.EmployeeID == employeeID).FirstOrDefault();

            return Task.FromResult(existingEmployee);
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
