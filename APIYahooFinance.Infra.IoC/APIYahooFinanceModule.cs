using APIYahooFinance.Application.Mapper;
using APIYahooFinance.Domain.Ativo.Interfaces;
using APIYahooFinance.Infra.Data.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIYahooFinance.Infra.IoC
{
    public static class APIYahooFinanceModule
    {
        private static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration config)
        {

            services.AddSingleton(new RepositoryConfiguration
            {
                ConnectionString = config.GetValue<string>("DB_CONNECTION")
            });
            services.AddSingleton<IVariacaoAtivoService, IVariacaoAtivoService>();

            return services;
        }
        

    }
}
