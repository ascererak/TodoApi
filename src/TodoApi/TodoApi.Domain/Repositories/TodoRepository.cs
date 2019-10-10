using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Contracts.Domain.Repositories;
using TodoApi.Contracts.Models;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Domain.Repositories
{
    internal class TodoRepository : ITodoRepository
    {
        private readonly ITodoContext context;

        public TodoRepository(ITodoContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyCollection<TodoItemModel>> Get() =>
            Map(await context.TodoItems.ToListAsync());

        public async Task<TodoItemModel> Get(long itemId) =>
            Map(await context.TodoItems.FirstOrDefaultAsync(item => item.Id == itemId));

        public async Task Add(TodoItemModel todoItem)
        {
            await context.TodoItems.AddAsync(Map(todoItem));

            context.SaveChanges();
        }

        public async Task Update(TodoItemModel todoItem)
        {
            var itemToUpdate = await context.TodoItems.FirstOrDefaultAsync(item => item.Id == todoItem.Id);

            itemToUpdate.Name = todoItem.Name;
            itemToUpdate.IsComplete = todoItem.IsComplete;

            context.SaveChanges();
        }

        public async Task Delete(long itemId)
        {
            var itemToDelete = await context.TodoItems.FirstOrDefaultAsync(item => item.Id == itemId);

            context.TodoItems.Remove(itemToDelete);

            context.SaveChanges();
        }

        private TodoItemModel Map(TodoItem item) =>
            new TodoItemModel
            {
                Id = item.Id,
                Name = item.Name,
                IsComplete = item.IsComplete
            };

        private TodoItem Map(TodoItemModel item) =>
            new TodoItem
            {
                Id = item.Id,
                Name = item.Name,
                IsComplete = item.IsComplete
            };

        private IReadOnlyCollection<TodoItemModel> Map(IReadOnlyCollection<TodoItem> todoItems) =>
            todoItems.Select(Map).ToList();
    }
}
