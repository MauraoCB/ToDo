using ToDo_API.Infra;
using ToDo_API.Models;
using ToDo_API.Repositories.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ToDo_API.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        public List<Task> GetAll()
        {
            using (TaskContext context = new())
            {
                return context.Task.ToList();
            }
        }

        public Task GetTask(int id)
        {
            using (TaskContext context = new())
            {
                var task = context.Task
               .Where(c => c.Id == id).FirstOrDefault();
               
                return task;
            }
        }

        public void AddTask(Task task)
        {
            using (TaskContext context = new())
            {
                context.Entry<Task>(task).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateTask(Task task)
        {
            using (TaskContext context = new())
            {
                Task taskUnchanged = context.Task.First(c => c.Id == task.Id);

                if (taskUnchanged != null)
                {
                    throw new Exception("Tarefa não encontrada");
                }

                context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteTask(int id)
        {
            using (TaskContext context = new())
            {
                Task task = context.Task.First(c => c.Id==id);
                context.Remove(task.Id = task.Id);
                context.SaveChanges();
            }
        }
    }
}
