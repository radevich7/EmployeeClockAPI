using AutoMapper;
using EmployeeClock.DTO.TimeTransactions;
using EmployeeClock.Entities;
using EmployeeClock.Repository.Helpers;

namespace EmployeeClock.API.Profiles
{
    public class TimeTransactionProfile : Profile
    {
        public TimeTransactionProfile()
        {
            CreateMap<TimeTransaction, TimeTransactionDTO>();
            CreateMap<TimeTransactionForCreationDTO, TimeTransaction>();
            CreateMap<TimeTransactionForUpdateDTO, TimeTransaction>();
            CreateMap<TimeTransaction, TimeTransactionForUpdateDTO>();



        }
    }
}
