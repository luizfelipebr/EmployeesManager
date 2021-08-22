using AutoMapper;
using EmployeesManager.Domain.Contracts.Employees;
using EmployeesManager.Domain.Entities.Employees;

namespace EmployeesManager.Domain.Mappers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<EmployeePostRequest, Employee>();

            CreateMap<EmployeePutRequest, Employee>();

            CreateMap<Employee, EmployeeResponse>()
                .ForMember(x => x.Leader, x => x.MapFrom(
                    src => new LeaderResponse(src.LeaderId, src.Leader.GetFullName())));
        }
    }
}
