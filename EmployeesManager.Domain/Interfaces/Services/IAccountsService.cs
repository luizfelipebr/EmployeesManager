using EmployeesManager.Domain.Contracts.Accounts;
using EmployeesManager.Domain.Entities.Accounts;
using System.Threading.Tasks;

namespace EmployeesManager.Domain.Interfaces.Services
{
    public interface IAccountsService
    {
        User GetCurrentUser();
        Task<UserCreateResponse> CreateUser(UserCreatetRequest request);
    }
}
