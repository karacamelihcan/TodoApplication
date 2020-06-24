using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApplication.Models
{
    public class TodoDbContext: DbContext
    { 
        public TodoDbContext(DbContextOptionsBuilder builder): base(builder.Options)
        {
            
        }
        public DbSet<TodoItem> TodoItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=MyDatabase.db");

    }
}
