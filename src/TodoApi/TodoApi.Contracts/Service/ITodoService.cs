using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Contracts.Models;

namespace TodoApi.Contracts.Service
{
    public interface ITodoService
    {
        Task<IReadOnlyCollection<TodoItemModel>> Get();

        Task<TodoItemModel> Get(long itemId);

        Task Add(TodoItemModel todoItem);

        Task Update(TodoItemModel todoItem);

        Task Delete(long itemId);
    }
}
