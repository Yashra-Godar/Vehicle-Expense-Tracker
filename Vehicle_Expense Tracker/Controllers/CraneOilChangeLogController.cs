using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraneOilChangeLogController : ControllerBase
    {
        private readonly ICraneOilChangeLog _changeLog;
        public CraneOilChangeLogController(ICraneOilChangeLog changeLog)
        {
            _changeLog=changeLog;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveCraneOilChange(CraneOilChangeLog craneOilChangeLog)
        {
            try
            {
                var result = await _changeLog.SaveCraneOilChange(craneOilChangeLog);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult("Internal Error", ex.Message));
            }
        }
    }
}
