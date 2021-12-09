using EmployeesManagement.Core.Contract;
using EmployeesManagement.Repository.Repo;

namespace EmployeesManagement.APIs.Builder
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IEmployeesRepository GetEmployeesRepository()
        {
            return new EmployeesRepository();
        }
    }
}
