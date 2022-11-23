using EmployeeClock.Entities;
using EmployeeClock.Repository.Helpers;
using EmployeeClock.Repository.ResourseParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Repository.TimeTransactionRepository
{
    public interface ITransactionRepository
    {
        Task<TimeTransaction> GetTimeTransactionAsync(Guid transactionID);
        Task<PagedList<TimeTransaction>> GetTimeTransactionsAsync(TimeTransactionResourceParameters resourceParameters);
        Task<PagedList<TimeTransaction>> GetTimeTransactionsAsync(Guid employeeID, TimeTransactionResourceParameters resourceParameters);
       void CreateTransaction(TimeTransaction transaction);
        Task<bool> SaveChangesAsync();


       bool TransactionExists(Guid transactionID);
    
    }
}
