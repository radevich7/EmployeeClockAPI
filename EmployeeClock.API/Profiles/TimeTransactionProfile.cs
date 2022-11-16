using AutoMapper;
using EmployeeClock.DTO.TimeTransactions;
using EmployeeClock.Entities;

namespace EmployeeClock.API.Profiles
{
    public class TimeTransactionProfile : Profile
    {
        public TimeTransactionProfile()
        {
            CreateMap<TimeTransaction, TimeTransactionDTO>();
        }
    }
}
