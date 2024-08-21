using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopDown_API.Models;
using Microsoft.EntityFrameworkCore;

namespace TopDown_API.Infra
{
    public class TaskContext : DbContext
    {
        public virtual DbSet<Models.Task> TaskInfo { get; set; }
 
        public TaskContext()
        { }
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
