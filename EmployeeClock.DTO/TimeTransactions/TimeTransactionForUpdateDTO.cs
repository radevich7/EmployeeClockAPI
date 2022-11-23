using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.DTO.TimeTransactions
{
    public class TimeTransactionForUpdateDTO : TimeTransactionForManipulationDTO
    {
        public Guid TransactionID { get; set; }
        public Guid EmployeeID { get; set; }

    }
}
