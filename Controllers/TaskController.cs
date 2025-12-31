using ecotrack_backend.Dto;
using ecotrack_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecotrack_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("all/{userId}")]
        [Authorize]
        public async Task<List<GetTasksResponse>> GetTasks(int userId)
        {
            return await _taskService.GetTasks(userId);
        }
    }
}
