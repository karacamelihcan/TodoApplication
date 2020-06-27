using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Data;

namespace TodoApplication.Services
{
    public class RealTodoItemService : ITodoItemService
    {
        //TODO: DBContext bağımlılığı giderilecek(TAMAMLANDI)
        private readonly TodoDbContext _context;
        public RealTodoItemService(TodoDbContext context)
        {
           _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync()
        {
            var items = await _context.TodoItems
                .Where(x => x.IsDone == false)
                .ToArrayAsync();

            return items;

        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            var entity = new TodoItem
            {
                Id = Guid.NewGuid(),
                IsDone = false,
                Title = newItem.Title,
                DueAt = DateTimeOffset.Now.AddDays(3)//TODO:Viewa eklenecek
            };
            _context.TodoItems.Add(entity);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
