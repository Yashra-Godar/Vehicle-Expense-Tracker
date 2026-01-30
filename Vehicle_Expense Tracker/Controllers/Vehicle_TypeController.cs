using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Vehicle_TypeController : ControllerBase
    {
        private readonly IVehicle_Type _manageVehicle;
        public Vehicle_TypeController(IVehicle_Type manageVehicle)
        {
            _manageVehicle = manageVehicle;
        }
        [HttpPost("Save")]
        public async Task<IActionResult> SaveVehicle_Type(Vehicle_Type vehicle_Type)
        {
            try
            {
                var result = await _manageVehicle.SaveVehicle_Type(vehicle_Type);
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
        public async Task<IActionResult> UpdateVehicle_Type(int Id, Vehicle_Type vehicle_Type)
        {
            try
            {
                var result = await _manageVehicle.UpdateVehicle_Type(Id, vehicle_Type);
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
        public async Task<IActionResult> DeleteVehicle_Type(int Id)
        {
            try
            {
                var result = await _manageVehicle.DeleteVehicle_Type(Id);
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
        public async Task<IActionResult> ListVehicle_Type()
        {
            try
            {
                var result = await _manageVehicle.ListVehicle_Type();
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

