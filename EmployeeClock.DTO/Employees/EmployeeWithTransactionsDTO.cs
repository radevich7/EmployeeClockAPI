using EmployeeClock.DTO.TimeTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.DTO.Employees
{
    public class EmployeeWithTransactionsDTO:EmployeeDTO
    {
        public ICollection<TimeTransactionDTO> TimeTransactions { get; set; } = new List<TimeTransactionDTO>();
    }
}
