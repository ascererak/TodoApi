using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Contracts.Models;

namespace TodoApi.Contracts.Domain.Repositories
{
    public interface ITodoRepository
    {
        Task<IReadOnlyCollection<TodoItemModel>> Get();

        Task<TodoItemModel> Get(long itemId);

        Task Add(TodoItemModel todoItem);

        Task Update(TodoItemModel todoItem);

        Task Delete(long itemId);
    }
}
