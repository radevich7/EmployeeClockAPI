﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeClock.Repository.ResourseParameters;


namespace EmployeeClock.API.ResourseParameters
{
    public class EmployeeResourceParameters : ResourceParameters
    {
        public string OrderBy { get; set; } = "Name";
    }
}
