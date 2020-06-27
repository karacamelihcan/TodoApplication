using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApplication.Data;
using TodoApplication.Models;

namespace TodoApplication.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(); //async
        Task<bool> AddItemAsync (TodoItem newItem);
        Task<bool> MarkDoneAsync(Guid id);
    }
}