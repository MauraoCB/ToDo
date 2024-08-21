using System.Collections.Generic;
using TopDown_API.Models;

namespace TopDown_API.Services.Interfaces
{
    public interface ITaskService
    {
        public void AddTask(Task task);
        public void UpdateTask(Task task);
        public Task GetTask(int id);
        public List<Task> GetAll();
        public void DeleteTask(int id);
    }
}
