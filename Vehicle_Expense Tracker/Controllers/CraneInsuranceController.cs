using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraneInsuranceController : ControllerBase
    {
        private readonly ICrane_Insurance _Insurance;
        public CraneInsuranceController(ICrane_Insurance Insurance)
        {
            _Insurance = Insurance;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveCrane_Insurance(Crane_Insurance Crane_Insurance)
        {
            try
            {
                var result = await _Insurance.SaveCrane_Insurance(Crane_Insurance);
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
        public async Task<IActionResult> UpdateCrane_Insurance(int Id,Crane_Insurance Crane_Insurance)
        {
            try
            {
                var result= await _Insurance.UpdateCrane_Insurance(Id, Crane_Insurance);
                if(result.status=="OK")
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
        public async Task<IActionResult> DeleteCrane_Insurance(int Id)
        {
            try
            {
                var result = await _Insurance.DeleteCrane_Insurance(Id);
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
        public async Task<IActionResult> ListCrane_Insurance()
        {
            try
            {
                var result = await _Insurance.ListCrane_Insurance();
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
