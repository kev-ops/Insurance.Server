using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Insurance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Insurance.Application.Interfaces.Persistence;
using Insurance.Infrastructure.Repositories;
using Insurance.Application.Interfaces.Services;
using Insurance.Infrastructure.Services;
using Insurance.Application;
using Insurance.Application.Interfaces;
using Insurance.Infrastructure.Classes;

namespace Insurance.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("insuranceConnectionString");
            services.AddDbContext<InsuranceDbContext>(options => options.UseSqlServer(connString,
                                                        x => x.MigrationsAssembly(typeof(InsuranceDbContext).Assembly.FullName)));
            services.AddScoped<IClock, Clock>();
            services.AddScoped<IHelper, Helper>();

            services.AddScoped<DbContext, InsuranceDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IInsuranceSetupRepository, InsuranceSetupRepository>();
            services.AddScoped<IConsumerRepository, ConsumerRepository>();
            services.AddScoped<IBenefitDetailRepository, BenefitDetailRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IInsuranceSetupService, InsuranceSetupService>();
            services.AddScoped<IConsumerService, ConsumerService>();


            return services;
           
        }
    

    }
}
