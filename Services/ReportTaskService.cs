using ecotrack_backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ecotrack_backend.Services
{
    public class ReportTaskService : IReportTaskService
    {
        private readonly AppDbContext _appDbContext;

        public ReportTaskService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> GetNumberCompletedTasks(int userId)
        {
            int conteggio = 0;
            conteggio += await _appDbContext.Tasks.Where(t => t.UserId == userId && t.IsCompleted).CountAsync();
            return conteggio;
        }

        public async Task<int> GetNumberPendingTasks(int userId)
        {
            int conteggio = 0;
            conteggio += await _appDbContext.Tasks.Where(t => t.UserId == userId && !t.IsCompleted).CountAsync();
            return conteggio;
        }

        public async Task<int> GetNumberTasks(int userId)
        {
            int conteggio = 0;
            conteggio += await _appDbContext.Tasks.Where(t => t.UserId == userId).CountAsync();
            return conteggio;
        }
    }
}
