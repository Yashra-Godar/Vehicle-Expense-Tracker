using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraneOilChangeLogController : ControllerBase
    {
        private readonly ICraneOilChangeLog _changeLog;
        public CraneOilChangeLogController(ICraneOilChangeLog changeLog)
        {
            _changeLog = changeLog;
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
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));

            }
        }

        [HttpPut("Update/{Id}")]

        public async Task<IActionResult> UpdateCraneOilChange(int Id, CraneOilChangeLog craneOilChangeLog)
        {
            try
            {
                var result = await _changeLog.UpdateCraneOilChange(Id, craneOilChangeLog);
                if (result.status == "OK")
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
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteCraneOilChange(int Id)
        {
            try
            {
                var result = await _changeLog.DeleteCraneOilChange(Id);
                if (result.status == "OK")
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
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }

        }
        [HttpGet("List")]
        public async Task<IActionResult> ListCraneOilChange()
        {
            try
            {
                var result = await _changeLog.ListOilChange();
                if (result.status == "OK")
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
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }


        }

        [HttpGet("Detail/{Id}")]
        public async Task<IActionResult> DetailCraneOilChange(int Id)
            {
                try
                {
                    var result = await _changeLog.DetailCraneOilChange(Id);
                    if (result.status == "OK")
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
                    return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
                }

            }

        }
    }

