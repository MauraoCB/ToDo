using System;
using System.Collections.Generic;
using ToDo_API.Models;
using ToDo_API.Repositories.Interfaces;
using ToDo_API.Services.Interfaces;

namespace ToDo_API.Services
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

        public  void AddTask(Task task)
        {
            if (task.DueDate == DateTime.MinValue)
            {
                task.DueDate = DateTime.Now.AddDays(5);
            }
             
            _taskRepository.AddTask(task);
        }

        public void UpdateTask(Task task)
        {
            _taskRepository.UpdateTask(task);
        }

        public List<Task> GetAll()
        {
           return _taskRepository.GetAll();
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }

        public void UpdateStatus(int id, string status)
        {
            _taskRepository.UpdateStatus(id, status);
        }
    }
}
