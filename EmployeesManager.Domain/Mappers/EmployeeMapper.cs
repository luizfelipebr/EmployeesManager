using AutoMapper;
using EmployeesManager.Domain.Contracts.v1;
using EmployeesManager.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Mappers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<EmployeePostRequest, Employee>()
                .ForMember(x => x.PasswordHash, x => x.Ignore())
                .ForMember(x => x.Email, x => x.MapFrom(scr => scr.Email))
                .ForMember(x => x.UserName, x => x.MapFrom(scr => scr.Email))
                .ForMember(x => x.FirstName, x => x.MapFrom(scr => scr.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(scr => scr.LastName));

            CreateMap<EmployeePutRequest, Employee>()
                .ForMember(x => x.PasswordHash, x => x.Ignore())
                .ForMember(x => x.FirstName, x => x.MapFrom(scr => scr.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(scr => scr.LastName));

            CreateMap<Employee, EmployeeResponse>()
                .ForMember(x => x.Leader, x => x.MapFrom(
                    src => new LeaderResponse()
                    {
                        LeaderId = src.Id,
                        FullName = src.GetFullName()
                    }))
                .ReverseMap();
        }
    }
}
