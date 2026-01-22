using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleLoanController : ControllerBase
    {
        private readonly IVehicle_Loan _Loan;
        public VehicleLoanController(IVehicle_Loan Loan)
        {
            _Loan = Loan;
        }
        [HttpPost("Save")]
        public async Task<IActionResult> SaveVehicle_Loan(Vehicle_Loan Loan)
        {
            try
            {
                var result= await _Loan.SaveVehicle_Loan(Loan);
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

        public async Task<IActionResult> UpdateVehicle_Loan(int Id, Vehicle_Loan Loan)
        {
            try
            {
                var result=await _Loan.UpdateVehicle_Loan(Id, Loan);
                if (result.status == "OK")
                {
                    return Ok(result);
                }
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
        public async Task<IActionResult>DeleteVehicle_Loan(int Id)
        {
            try
            {
                var result= await _Loan.DeleteVehicle_Loan(Id);
                if(result.status == "OK")
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
        public async Task<IActionResult> ListVehicle_Loan()
        {
            try
            {
                var result=await _Loan.ListVehicle_Loan();
                if(result.status == "OK")
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

