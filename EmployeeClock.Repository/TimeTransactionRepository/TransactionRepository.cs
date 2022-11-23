using EmployeeClock.Entities;
using EmployeeClock.Repository.DBContext;
using EmployeeClock.Repository.Helpers;
using EmployeeClock.Repository.ResourseParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Repository.TimeTransactionRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly EmployeeClockContext _context;


        public TransactionRepository(EmployeeClockContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<PagedList<TimeTransaction>> GetTimeTransactionsAsync(TimeTransactionResourceParameters resourceParameters)
        {
            var collection = _context.TimeTransactions as IQueryable<TimeTransaction>;

            //Searching
            //OrderingBy




            return await PagedList<TimeTransaction>.CreateAsync(collection, resourceParameters.PageNumber, resourceParameters.PageSize);
        }

        public async Task<PagedList<TimeTransaction>> GetTimeTransactionsAsync(Guid employeeID, TimeTransactionResourceParameters resourceParameters)
        {

            var collection = await _context.TimeTransactions.Where(temp => temp.EmployeeID == employeeID).ToListAsync();

            return await PagedList<TimeTransaction>.CreateAsync(collection, resourceParameters.PageNumber, resourceParameters.PageSize);

        }
        public void CreateTransaction(TimeTransaction transaction)
        {
            _context.TimeTransactions.Add(transaction);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public bool TransactionExists(Guid transactionID)
        {
            return _context.TimeTransactions.Any(temp => temp.TransactionID == transactionID);
        }

        public async Task<TimeTransaction> GetTimeTransactionAsync(Guid transactionID)
        {
           return await _context.TimeTransactions.Where(temp=>temp.TransactionID == transactionID).FirstOrDefaultAsync();
        }
    }
}
