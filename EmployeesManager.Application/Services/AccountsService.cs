using AutoMapper;
using EmployeesManager.Domain.Contracts.Accounts;
using EmployeesManager.Domain.Entities.Accounts;
using EmployeesManager.Domain.Exceptions;
using EmployeesManager.Domain.Interfaces.Repositories;
using EmployeesManager.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EmployeesManager.Application.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public AccountsService(
            IUserRepository userRepository,
            IHttpContextAccessor httpContext,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _httpContextAccessor = httpContext;
        }

        public async Task<UserCreateResponse> CreateUser(UserCreatetRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
                throw new BusinessException("The Email field cannot be null", nameof(request.Email));

            if (string.IsNullOrEmpty(request.Password))
                throw new BusinessException("The Password field cannot be null", nameof(request.Password));

            var entity = _mapper.Map<User>(request);

            var newUser = await _userRepository.Add(entity, request.Password);

            var response = _mapper.Map<UserCreateResponse>(newUser);

            return response;
        }

        public User GetCurrentUser()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = _userRepository.GetByEmail(userName).GetAwaiter().GetResult();

            return user;
        }
    }
}
