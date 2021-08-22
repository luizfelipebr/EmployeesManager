using AutoMapper;
using EmployeesManager.Domain.Contracts.Accounts;
using EmployeesManager.Domain.Entities.Accounts;

namespace EmployeesManager.Domain.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserCreatetRequest, User>()
                .ForMember(x => x.UserName, x => x.MapFrom(src => src.Email))
                .ForMember(x => x.Email, x => x.MapFrom(src => src.Email))
                .ForMember(x => x.EmployeeId, x => x.MapFrom(src => src.EmployeeId))
                .ForMember(x => x.Employee, x => x.Ignore())
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<User, UserCreateResponse>();
        }
    }
}
