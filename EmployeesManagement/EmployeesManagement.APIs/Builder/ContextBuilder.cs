using EmployeesManagement.Core.Contract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagement.APIs.Builder
{
    public class ContextBuilder
    {

        private IJsonSerializer _jsonSerializer;
        private IConfiguration _configuration;
        private IRepositoryFactory _repositoryFactory;
        private IUseCaseFactory _useCaseFactory;

        public ContextBuilder WithConfiguration(IConfiguration configuration)
        {
            this._configuration = configuration;
            return this;
        }
        public ContextBuilder WithJsonSerializer(IJsonSerializer jsonSerializer)
        {
            this._jsonSerializer = jsonSerializer;
            return this;
        }


        public ContextBuilder WithRepositoryFactory(IRepositoryFactory repositoryFactory)
        {
            this._repositoryFactory = repositoryFactory;
            return this;
        }

        public ContextBuilder WithUseCaseFactory(IUseCaseFactory useCaseFactory)
        {
            this._useCaseFactory = useCaseFactory;
            return this;
        }
        public IContext Build()
        {
            return new Context(this);
        }

        public static ContextBuilder PrepareContext()
        {
            return new ContextBuilder();
        }

        private class Context : IContext
        {
            private readonly IJsonSerializer _jsonSerializer;
            private readonly IConfiguration _configuration;
            private readonly IRepositoryFactory _repositoryFactory;
            private readonly IUseCaseFactory _useCaseFactory;

            public Context(ContextBuilder contextBuilder)
            {
                this._configuration = contextBuilder._configuration;
                this._jsonSerializer = contextBuilder._jsonSerializer;
                this._repositoryFactory = contextBuilder._repositoryFactory;
                this._useCaseFactory = contextBuilder._useCaseFactory;
            }

            public IConfiguration GetConfiguration()
            {
                return _configuration;
            }

            public IJsonSerializer GetJsonSerializer()
            {
                return _jsonSerializer;
            }

            public IUseCaseFactory GetUseCaseFactory()
            {
                return _useCaseFactory;
            }
            public IRepositoryFactory GetRepositoryFactory()
            {
                return _repositoryFactory;
            }
        }

    }
}
