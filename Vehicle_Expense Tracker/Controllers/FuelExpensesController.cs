using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelExpensesController : ControllerBase
    {
        private readonly IFuel_Expenses _Expenses;
        public FuelExpensesController(IFuel_Expenses Expenses)
        {
            _Expenses = Expenses;
        }
        [HttpPost("Save")]
        public async Task<IActionResult> SaveFuel_Expenses(Fuel_Expenses fuelExpenses)
        {
            try
            {
                var result = await _Expenses.SaveFuel_Expenses(fuelExpenses);
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
        public async Task<IActionResult> UpdateFuel_Expenses(int Id, Fuel_Expenses fuel_Expenses)
        {
            try
            {
                var result = await _Expenses.UpdateFuel_Expenses(Id, fuel_Expenses);
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

        public async Task<IActionResult> DeleteFuel_Expenses(int Id)
        {
            try
            {
                var result = await _Expenses.DeleteFuel_Expenses(Id);
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

        public async Task<IActionResult>ListFuel_Expenses()
        {
            try
            {
                var result= await _Expenses.ListFuel_Expenses();
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