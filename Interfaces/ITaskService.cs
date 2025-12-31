using ecotrack_backend.Dto;

namespace ecotrack_backend.Interfaces
{
    public interface ITaskService
    {
        public Task<List<GetTasksResponse>> GetTasks(int userId);
    }
}
