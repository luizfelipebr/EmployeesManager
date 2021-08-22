using EmployeesManager.Domain.Entities.Accounts;

namespace EmployeesManager.Domain.Interfaces.Services
{
    public interface IAccountsService
    {
        User GetCurrentUser();
    }
}
