using EmployeeClock.API.ResourseParameters;
using EmployeeClock.DTO.Employees;
using EmployeeClock.Entities;
using EmployeeClock.Repository.DBContext;
using EmployeeClock.Repository.Helpers;
using EmployeeClock.Repository.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Repository.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeClockContext _context;
        private readonly IPropertyMappingService _propertyMappingService;


        public EmployeeRepository(EmployeeClockContext context, IPropertyMappingService propertyMappingService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService)); ;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.OrderBy(temp => temp.FirstName).ToListAsync();
        }

        public async Task<PagedList<Employee>> GetAllEmployeesAsync(EmployeeResourceParameters resourceParameters)
        {


            var collection = _context.Employees as IQueryable<Employee>;

            if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
            {
                var trimmedSearchQuery = resourceParameters.SearchQuery.Trim();
                collection = collection.Where(temp =>
                temp.FirstName.Contains(trimmedSearchQuery) || temp.LastName.Contains(trimmedSearchQuery));
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
            {

                var employeePropertyMappingDictionary = _propertyMappingService.GetPropertyMapping<EmployeeDTO, Employee>();

                collection = collection.ApplySort(resourceParameters.OrderBy, employeePropertyMappingDictionary);
            }

            return await PagedList<Employee>.CreateAsync(collection, resourceParameters.PageNumber, resourceParameters.PageSize); 

        }




        public async Task<Employee> GetEmployeeAsync(Guid employeeID, bool includeTimetransaction = false)
        {
            if (includeTimetransaction)
            {
                return await _context.Employees.Include(temp => temp.TimeTransactions).Where(temp => temp.EmployeeID == employeeID).FirstOrDefaultAsync();
            }

            return await _context.Employees.Where(temp => temp.EmployeeID == employeeID).FirstOrDefaultAsync();
        }

        public void CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
        }


        public async Task<bool> EmployeeExistAsync(Guid employeeID)
        {
            return _context.Employees.Any(temp => temp.EmployeeID == employeeID);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
