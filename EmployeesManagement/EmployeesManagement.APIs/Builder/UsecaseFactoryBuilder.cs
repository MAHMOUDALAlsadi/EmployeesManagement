using EmployeesManagement.Core.Contract;

namespace EmployeesManagement.APIs.Builder
{
    public class UsecaseFactoryBuilder
    {
        private IEmployeesUseCase _employeesUseCase;

        public static UsecaseFactoryBuilder PrepareContext()
        {
            return new UsecaseFactoryBuilder();
        }

        public UsecaseFactoryBuilder WithEmployeesUseCase(IEmployeesUseCase employeesUseCase)
        {
            this._employeesUseCase = employeesUseCase;
            return this;
        }

        public IUseCaseFactory Build()
        {
            return new UseCaseFactory(this);
        }
        private class UseCaseFactory : IUseCaseFactory
        {
            private IEmployeesUseCase _employeesUseCase;

            public UseCaseFactory(UsecaseFactoryBuilder useCaseFactoryBuilder)
            {
                _employeesUseCase = useCaseFactoryBuilder._employeesUseCase;
            }

            public IEmployeesUseCase GetEmployeesUseCase()
            {
                return _employeesUseCase;
            }
        }
    }
}
