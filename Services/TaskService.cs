using ecotrack_backend.Dto;
using ecotrack_backend.Interfaces;
using ecotrack_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ecotrack_backend.Services
{
    public class TaskService : ITaskService
    {

        private readonly AppDbContext _appDbContext;

        public TaskService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<GetTasksResponse>> GetTasks(int userId)
        {
            var tasks = await _appDbContext.Tasks.Where(t => t.UserId == userId).ToListAsync();
            List<GetTasksResponse> res = new List<GetTasksResponse>();
            foreach (var t in tasks)
            {
                GetTasksResponse resT = new GetTasksResponse();
                resT.Id = t.Id;
                resT.Title = t.Title;
                resT.Description = t.Description;
                resT.StartDate = t.StartDate;
                resT.DueDate = t.DueDate;
                resT.IsCompleted = t.IsCompleted;
                res.Add(resT);
            }
            return res;
        }
    }
}
