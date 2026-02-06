using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMasterController : ControllerBase
    {
        private readonly IAdmin_Master _Master;
        public AdminMasterController(IAdmin_Master Master)
        {
            _Master = Master;
        }

        [HttpPost("Save")]

        public async Task<IActionResult> SaveAdmin_Master(Admin_Master admin_Master)
        {
            try
            {
                var result = await _Master.SaveAdmin_Master(admin_Master);
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

        public async Task<IActionResult> UpdateAdmin_Master(int Id, Admin_Master admin_Master)
        {
            try
            {
                var result = await _Master.UpdateAdmin_Master(Id, admin_Master);
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

        public async Task<IActionResult> DeleteAdmin_Master(int Id)
        {
            {
                try
                {
                    var result = await _Master.DeleteAdmin_Master(Id);
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


        [HttpGet("List")]
        public async Task<IActionResult> ListAdmin_Master()
        {
            try
            {
                var result = await _Master.ListAdmin_Master();
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

        [HttpGet("Welcome")]
        public IActionResult welcome()
        {
            try
            {
                return Ok("Welcome to Amrit Crane Vehicle Expense Tracker");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }
        }


        [HttpGet("Detail/{Id}")]
        public async Task<IActionResult> DetailAdmin_Master(int Id)
        {
            try
            {
                var result = await _Master.DetailAdmin_Master(Id);
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