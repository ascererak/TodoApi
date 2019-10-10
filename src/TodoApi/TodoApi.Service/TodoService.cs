using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Contracts.Domain.Repositories;
using TodoApi.Contracts.Models;
using TodoApi.Contracts.Service;

namespace TodoApi.Service
{
    internal class TodoService : ITodoService
    {
        private readonly ITodoRepository repository;

        public TodoService(ITodoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IReadOnlyCollection<TodoItemModel>> Get() =>
            await repository.Get();

        public async Task<TodoItemModel> Get(long itemId) =>
            await repository.Get(itemId);

        public async Task Add(TodoItemModel todoItem) => 
            await repository.Add(todoItem);


        public async Task Update(TodoItemModel todoItem) =>
            await repository.Update(todoItem);

        public async Task Delete(long itemId) =>
            await repository.Delete(itemId);
    }
}
