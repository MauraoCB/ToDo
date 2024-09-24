using Microsoft.EntityFrameworkCore;
using ToDo_API.Models;

namespace ToDo_API.Infra
{
    public class TaskContext : DbContext
    {
        public virtual DbSet<Task> Task { get; set; }
        public TaskContext()
        {
                
        }
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
