using Azure.Core;
using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffMasterController : ControllerBase
    {
        private readonly IStaff_Master _Master;
        public StaffMasterController(IStaff_Master Master)
        {
            _Master = Master;
        }


        [HttpPost("Save")]
        public async Task<IActionResult> SaveStaff_Master(Staff_Master staff_Master)
        {
            try
            {
                var result = await _Master.SaveStaff_Master(staff_Master);
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
        public async Task<IActionResult> UpdateStaff_Master(int Id, Staff_Master staff_Master)
        {

            try
            {
                var result = await _Master.UpdateStaff_Master(Id, staff_Master);
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
        public async Task<IActionResult> DeleteStaff_Master(int Id)
        {
            try
            {
                var result = await _Master.DeleteStaff_Master(Id);
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
        public async Task<IActionResult> ListStaff_Master()
        {
            try
            {
                var result = await _Master.ListStaff_Master();
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
        public async Task<IActionResult> DetailStaff_Master(int Id)
        {
            try
            {
                var result = await _Master.DetailStaff_Master(Id);
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