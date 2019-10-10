using System;
using System.Collections.Generic;
using System.Text;
using TodoApi.Contracts.Domain.Initializers;
using TodoApi.Contracts.Domain.Seeders;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Domain.Initializers
{
    internal class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ITodoContext todoContext;
        private readonly ISeeder seeder;

        public DatabaseInitializer(ITodoContext todoContext, ISeeder seeder)
        {
            this.todoContext = todoContext;
            this.seeder = seeder;
        }

        public void Initialize()
        {
            if (todoContext.Database.EnsureCreated())
            {
                seeder.Seed();
            }
        }
    }
}
