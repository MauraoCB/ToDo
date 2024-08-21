using TopDown_API.Models;

namespace TopDown_API.Repositories.Interfaces
{
    public   interface ITaskRepository
    {
        public void SaveTask(Task task);
        Task GetTask(int id);
    }
}
