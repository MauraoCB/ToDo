using TopDown_API.Infra;
using TopDown_API.Models;
using TopDown_API.Repositories.Interfaces;
using System.Linq;

namespace TopDown_API.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        public Task GetTask(int id)
        {
            using (TaskContext context = new())
            {
                var task = context.TaskInfo
               .Where(c => c.Id == id).FirstOrDefault();
               
                return task;
            }
        }

        public void SaveTask(Task task)
        {
            using (TaskContext context = new())
            {
                context.Entry<Task>(task).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
