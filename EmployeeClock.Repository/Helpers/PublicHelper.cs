using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Repository.Helpers
{
    public static class PublicHelper
    {
        public static bool EqualsInsensitive(this string str, string value) => string.Equals(str, value, StringComparison.CurrentCultureIgnoreCase);

        public static int CalculateAge(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Now;
            int yearOfBirth = new DateTime(DateTime.Now.Subtract(dateOfBirth).Ticks).Year - 1;
            int monthOfBirth = dateOfBirth.Month;
            int age;
            if (monthOfBirth < now.Month)
            {
                age = yearOfBirth - 1;
            }
            else
            {
                age = yearOfBirth;
            }
            return age;
        }

    }
   
}
