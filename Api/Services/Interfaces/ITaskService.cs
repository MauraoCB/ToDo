using TopDown_API.Models;

namespace TopDown_API.Services.Interfaces
{
    public interface ITaskService
    {
        void SaveTask(Models.Task task);
        Task GetTask(int id);
    }
}
