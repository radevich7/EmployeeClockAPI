using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeClock.Entities;

namespace EmployeeClock.Entities
{
    public class TimeTransaction
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransactionID { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }
        public Guid EmployeeID { get; set; }

    }


}
