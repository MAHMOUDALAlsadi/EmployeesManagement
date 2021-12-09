using EmployeesManagement.Core;
using EmployeesManagement.Core.Contract;
using EmployeesManagement.UseCase.UseCases;
using EmployeesManagement.UseCase.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace EmployeesManagement.APIs
{
    public class Startup
    {
        private IContext _systemContext;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            IRepositoryFactory repositoryFactory = new RepositoryFactory();
            IJsonSerializer jsonSerializer = new JsonSerializer();
            var getUseCaseFactory = GetUseCaseFactory(repositoryFactory, jsonSerializer);
            var context = GetContext(getUseCaseFactory, jsonSerializer);
            services.AddSingleton(context);
            services.AddSingleton(context);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private IUseCaseFactory GetUseCaseFactory(IRepositoryFactory repositoryFactory, IJsonSerializer jsonSerializer)
        {
            IEmployeesUseCase employeesUseCase = new EmployeesUseCase(repositoryFactory);

            IUseCaseFactory useCaseFactory = UsecaseFactoryBuilder.PrepareContext()
                .WithEmployeesUseCase(employeesUseCase)
                .Build();
            return useCaseFactory;

        }

        private IContext GetContext(IUseCaseFactory useCaseFactory, IJsonSerializer jsonSerializer)
        {
            IContext context = ContextBuilder
                .PrepareContext()
                .WithConfiguration(Configuration)
                .WithJsonSerializer(jsonSerializer)
                .WithRepositoryFactory(new RepositoryFactory())
                .WithUseCaseFactory(useCaseFactory)
                .Build();
            _systemContext = context;
            return context;
        }

    }
}
