using EmployeeClock.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Test
{
    public class EmployeeTests
    {
        [Fact]
        public async Task EmployeeExist_CheckByEmployeeID_MustBeTrue()
        {
            //Arrange
            var employeeService = new EmployeeRepositoryService();

            //Act
            bool employeeExist = await employeeService.EmployeeExistAsync(Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            //Assert

            Assert.True(employeeExist);

        }



    }
}
