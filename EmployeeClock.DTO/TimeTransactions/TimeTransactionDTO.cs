using EmployeeClock.DTO.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.DTO.TimeTransactions
{
    public class TimeTransactionDTO
    {
        public Guid TransactionID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

    }
}
