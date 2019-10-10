using System;
using System.Collections.Generic;
using System.Text;
using TodoApi.Contracts.Domain.Seeders;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;
using TodoApi.Models;

namespace TodoApi.Domain.Seeders
{
    internal class Seeder : ISeeder
    {
        private readonly ITodoContext context;

        public Seeder(ITodoContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            
            context.TodoItems.Add(new TodoItem
            {
                Name = "Note 1",
                IsComplete = false
            });

            context.SaveChanges();
        }
    }
}