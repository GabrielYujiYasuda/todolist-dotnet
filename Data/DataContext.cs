using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todolist_dotnet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TaskModel> Tasks => Set<TaskMOdel>();
    }
}