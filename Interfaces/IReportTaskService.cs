namespace ecotrack_backend.Interfaces
{
    public interface IReportTaskService
    {
        public Task<int> GetNumberTasks(int userId);
        public Task<int> GetNumberCompletedTasks(int userId);
        public Task<int> GetNumberPendingTasks(int userId);
    }
}
