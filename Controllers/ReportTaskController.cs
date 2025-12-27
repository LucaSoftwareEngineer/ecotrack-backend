using ecotrack_backend.Dto;
using ecotrack_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecotrack_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTaskController : Controller
    {
        private readonly ReportTaskService _reportTaskService;

        public ReportTaskController(ReportTaskService reportTaskService)
        {
            _reportTaskService = reportTaskService;
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<ActionResult<ReportTaskResponse>> GetReport(int userId) {
            try
            {
                ReportTaskResponse res = new ReportTaskResponse
                {
                    TotalTasks = await _reportTaskService.GetNumberTasks(userId),
                    PendingTasks = await _reportTaskService.GetNumberPendingTasks(userId),
                    CompletedTasks = await _reportTaskService.GetNumberCompletedTasks(userId)
                };

                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
