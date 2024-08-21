using Microsoft.EntityFrameworkCore;
using TopDown_API.Models;

namespace TopDown_API.Infra
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
