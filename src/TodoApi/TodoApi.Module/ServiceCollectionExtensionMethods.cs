using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Contracts.Domain.Initializers;
using TodoApi.Contracts.Domain.Repositories;
using TodoApi.Contracts.Domain.Seeders;
using TodoApi.Contracts.Service;
using TodoApi.Domain.Initializers;
using TodoApi.Domain.Interfaces;
using TodoApi.Domain.Repositories;
using TodoApi.Domain.Seeders;
using TodoApi.Models;
using TodoApi.Service;

namespace TodoApi.Module
{
    public static class ServiceCollectionExtensionMethods
    {
        public static IConfiguration Configuration { get; }

        public static void AddTodoList(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            serviceCollection.AddTransient<ITodoContext, TodoContext>();
            serviceCollection.AddTransient<ITodoService, TodoService>();
            serviceCollection.AddTransient<ITodoRepository, TodoRepository>();
            serviceCollection.AddTransient<ISeeder, Seeder>();

            serviceCollection.AddDbContext<TodoContext>(cfg =>
                {
                    cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });
        }
    }
}
