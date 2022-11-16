using AutoMapper;
using EmployeeClock.DTO.Employees;
using EmployeeClock.Entities;
using EmployeeClock.Repository.Helpers;

namespace EmployeeClock.API.Profiles
{
    public class EmployeeProfile : Profile
    {

        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => PublicHelper.CalculateAge(src.DateOfBirth)));
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeWithTransactionsDTO>();
            CreateMap<EmployeeForCreationDTO, Employee>();
            CreateMap<EmployeeForUpdateDTO, Employee>();
            CreateMap<Employee, EmployeeForUpdateDTO>();

        }

       
    }
}
