using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("ConnectionUnico");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
