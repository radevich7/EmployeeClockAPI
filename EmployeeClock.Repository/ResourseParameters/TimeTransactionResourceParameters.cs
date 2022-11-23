using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeClock.Repository.ResourseParameters;

namespace EmployeeClock.Repository.ResourseParameters
{
    public class TimeTransactionResourceParameters : ResourceParameters
    {
        public string OrderBy { get; set; } = "Date";

    }
}
