using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApplication.Data;
using TodoApplication.Models;

namespace TodoApplication.Services
{
    public class RealTodoItemService : ITodoItemService
    {
        //TODO: DBContext bağımlılığı giderilecek(TAMAMLANDI)
        private readonly TodoDbContext context;
        public RealTodoItemService(TodoDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync()
        {
            var items = await context.TodoItems
                .Where(x => x.IsDone == false)
                .ToArrayAsync();

            return items;

        }
    }
}
