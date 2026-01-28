using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraneOtherExpensesController : ControllerBase
    {
        private readonly ICraneOtherExpenses _otherExpenses;
        public CraneOtherExpensesController(ICraneOtherExpenses otherExpenses)
        {
            _otherExpenses = otherExpenses;
        }
        [HttpPost("Save")]
        public async Task<IActionResult> SaveCraneOtherExpenses(CraneOtherExpenses craneOtherExpenses)
        {
            try
            {
                var result = await _otherExpenses.SaveCraneOtherExpenses(craneOtherExpenses);
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

        public async Task<IActionResult> UpdateCraneOtherExpenses(int Id, CraneOtherExpenses craneOtherExpenses)
        {
            try
            {
                var result = await _otherExpenses.UpdateCraneOtherExpenses(Id, craneOtherExpenses);
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

        public async Task<IActionResult> DeleteCraneOtherExpenses(int Id)
        {
            try
            {
                var result = await _otherExpenses.DeleteCraneOtherExpenses(Id);
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

        [HttpGet("List")]

        public async Task<IActionResult> ListCraneOtherExpenses()
        {
            try
            {
                var result = await _otherExpenses.ListCraneOtherExpenses();
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

        public async Task<IActionResult> DetailCraneOtherExpenses(int Id)
        {
            try
            {
                var result = await _otherExpenses.DetailCraneOtherExpenses(Id);
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