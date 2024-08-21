using System;
using TopDown_API.Models;
using TopDown_API.Repositories.Interfaces;
using TopDown_API.Services.Interfaces;

namespace TopDown_API.Services
{
    public class TaskService: ITaskService
    {

        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task GetTask(int id)
        {
            var task = _taskRepository.GetTask(id);

            return task;
        }

        public  void SaveTask(Models.Task task)
        {
            if (task.DueDate == DateTime.MinValue)
            {
                task.DueDate = DateTime.Now.AddDays(5);
            }
             
            _taskRepository.SaveTask(task);
        }
    }
}
