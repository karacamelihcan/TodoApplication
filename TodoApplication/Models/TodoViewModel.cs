using System.Collections.Generic;
namespace TodoApplication.Models
{
    public class TodoViewModel
    {
        public IEnumerable<TodoItem> Items { get; set; }
    }
}
