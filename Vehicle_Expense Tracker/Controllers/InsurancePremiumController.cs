using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePremiumController : ControllerBase
    {
        private readonly IInsurance_Premium _Premium;
        public InsurancePremiumController(IInsurance_Premium Premium)
        {
            _Premium = Premium;
        }
        [HttpPost("Save")]
        public async Task<IActionResult> SaveInsurance_Premium(Insurance_Premium insurance_Premium)
        {
            try
            {
                var result = await _Premium.SaveInsurance_Premium(insurance_Premium);
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
        public async Task<IActionResult> UpdateInsurance_Premium(int Id, Insurance_Premium insurance_Premium)
        {
            try
            {
                var result = await _Premium.UpdateInsurance_Premium(Id, insurance_Premium);
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
        public async Task<IActionResult> DeleteInsurance_Premium(int Id)
        {
            try
            {
                var result = await _Premium.DeleteInsurance_Premium(Id);
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
        public async Task<IActionResult> ListInsurance_Premium()
        {
            try
            {
                var result = await _Premium.ListInsurance_Premium();
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
        public async Task<IActionResult> DetailInsurance_Premium(int Id)
        {
            try
            {
                var result = await _Premium.DetailInsurance_Premium(Id);
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

        [HttpGet("Report")]
        public async Task<IActionResult> Insurance_PremiumReport([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            try
            {
                var result = await _Premium.Insurance_PremiumReport(fromDate, toDate);

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

        [HttpGet("PremiumDetail/{Id}")]
        public async Task<IActionResult> GetInsurance_Premium(int Id,Insurance_Premium insurance_Premium)
        {
            try
            {
                var result = await _Premium.GetInsurance_Premium(Id, insurance_Premium);

                if (result.status == "OK")
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }

        }
    }
}