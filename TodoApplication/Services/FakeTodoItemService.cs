using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Models;

namespace TodoApplication.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<IEnumerable<TodoItem>> GetIncompleteItemAsync()
        {
            //Return an array of TodoItems
            IEnumerable<TodoItem> items = new[]
            {
                new TodoItem // object initializer
                {
                    Title="Learn ASP.NET Core",
                    DueAt= DateTimeOffset.Now.AddDays(1)
                },
                new TodoItem
                {
                    Title="Build awesome apps",
                    DueAt=DateTimeOffset.Now.AddDays(2)
                }
            };

            return Task.FromResult(items);
        }

    }
}
